using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MultiPilot : NetworkBehaviour
{

    public float speed;
    public float speedMax;
    public float speedMin;
    public float boost;
    public float boostSpeedMax;                                                                   //vitesse max que peut faire atteindre le boost
    public float maneuverability;

    //gestion de la réduction de taille (même si c'est pas la taille qui compte :) eh oui c'est le gout!)
    public float reduce = 30;

    //gestion de la caméra
    public float cameraBias;
    public float cameraSetback;
    public float cameraHeight;

    //Shooting
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    //Life
    [SyncVar]
    public int life = 5;

    //Connections
    private GameObject[] players;
    private int connected;

    //Race mode
    public int nbgatetot = 11;
    public int nbgatetaken;

    //public float timer = 0;

    // Use this for initialization
    void Start ()
    {
        Debug.Log("plane pilot script added to : " + gameObject.name); //permet de tester que le script est bien chargé par unity
        players = GameObject.FindGameObjectsWithTag("player");
        //team = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
            return;



        float bias = cameraBias;

        Vector3 moveCamTo = transform.position - transform.forward * cameraSetback / reduce + Vector3.up * cameraHeight / reduce;   //gestion de la camera : camera stable

        Camera.main.transform.position = Camera.main.transform.position * bias + (1.0f - bias) * moveCamTo;     //bias = ralentissement de la camera (entre 0 et 1) : 0.96 ou 0.70 ou 0.50
        Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);               //le "+ transform.forward * xf" sert a pointer la camera non pas vers l'avion mais vers ou il va
                                                                                                    //pour la camera subjective, enlever les 3 lignes et mettre Main Camera dans PlaneWhole

        transform.position += transform.forward * Time.deltaTime * speed / reduce;                           //deplacement : le vecteur unitaire tangent * le tps écoulé entre 2 frames * la vitesse
        transform.Rotate(Input.GetAxis("Vertical") * maneuverability,                               //rotation de l'avion en fonction des commandes de Unity (les touches qui gerent les différents virages : vertical, horizontal)
                                        Input.GetAxis("Steering") * maneuverability * 0.3f,
                                        Input.GetAxis("Horizontal") * 2.0f * maneuverability);

        speed -= transform.forward.y * Time.deltaTime * 50.0f;                                      //gestion de la vitesse en fonction de l'inclinaison de l'avion
        float accel = Input.GetAxis("Accelerate");
        if (speed < boostSpeedMax && accel > 0.0f)
        {
            speed += accel * Time.deltaTime * boost;
        }
        else if (accel < 0.0f)
        {
            speed += accel * Time.deltaTime * boost;
        }

        if (speed > speedMax)                                                                        //gestion de la vitesse max
        {
            speed = speedMax;
        }
        if (speed < speedMin)                                                                        //gestion de la vitesse min
        {
            speed = speedMin;
        }

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);     //hauteur du terrain sous l'avion

        if (terrainHeightWhereWeAre > transform.position.y
            || transform.position.x < 0 || transform.position.z < 0
            || transform.position.x > 500 || transform.position.z > 500
            || transform.position.y < 0 || transform.position.y > 200)                                          //si l'avion est sous le terrain ou dépasse les limites
        {
            Debug.Log("Out of bounds !");
            /*Destroy(gameObject);                                                                    //ajouter ici les pbs de l'avion en cas de collision avec le sol

            PlayerPrefs.SetString("End", "Lose");
            Application.LoadLevel("End");*/
            if (isLocalPlayer)
            {
                life--;
                if (life > 0)
                {
                    RpcRespawn();
                }
                else
                {
                    Destroy(this.gameObject);
                    Camera.main.transform.position = new Vector3(50, 25, 10);
                    Camera.main.transform.rotation = new Quaternion(0, 0, 0, 0);
                }
                
            }
        }

        //Fire bullet
        if (Input.GetKeyDown(KeyCode.Space))
            CmdFire();

        bool end = true;
        int i = 0;
        while (i < players.Length && end)
        {
            end = players[i].GetComponent<MultiPilot>().life == 0;
            i++;
        }

        if (end)
        {
            Network.Disconnect();
            Application.LoadLevel("MultiEnd");
        }
        
        if (GameObject.FindGameObjectsWithTag("gate").Length <= 0)
        {
            PlayerPrefs.SetInt("score", nbgatetaken);
            Network.Disconnect();
            Application.LoadLevel("MultiEnd");
        }

    }

    [Command]
    void CmdFire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 5.0f);
    }

    public void CollisionBullet()
    {
        if (!isServer)
            return;

        life--;
        if (life > 0)
        {
            RpcRespawn();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            transform.position = new Vector3(55, 28, 67);
            speed = 60;
        }
    }

    void OnPlayerConnected()
    {
        players = GameObject.FindGameObjectsWithTag("player");
    }

}
