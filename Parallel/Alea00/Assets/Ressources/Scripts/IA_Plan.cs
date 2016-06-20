using UnityEngine;
using System.Collections;

public class IA_Plan : MonoBehaviour {

    public string playerPlaneName;
    public GameObject bullet; // Gameobject de la balle

    public float speed;
    public float reduce;

    public bool isAlive;

    public float timer;

    GameObject player;

    public float cadenceInter1;
    public float cadenceInter2;

    // Use this for initialization
    void Start()
    {
        isAlive = true;
        Debug.Log("plane pilot script added to : " + gameObject.name);                              //permet de tester que le script est bien chargé par unity
        timer = 0;
        cadenceInter1 = 2.0f; // Difficulte normal
        cadenceInter2 = 8.0f; // Difficulte normal
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int planetype = PlayerPrefs.GetInt("Plane");

        if (planetype == 0)
        {
            playerPlaneName = "Fighter(Clone)";
        }
        else if (planetype == 1)
        {
            playerPlaneName = "Sprinter(Clone)";
        }
        else if (planetype == 2)
        {
            playerPlaneName = "SmallConqueror(Clone)";
        }
        else if (planetype == 3)
        {
            playerPlaneName = "Conqueror(Clone)";
        }
        else
        {
            playerPlaneName = "Prototype(Clone)";
        }

        Vector3 planPosition = GameObject.Find(playerPlaneName).transform.position;

        if (Vector3.Distance(planPosition, transform.position) > 180 / reduce)
        {
            planPosition += GameObject.Find(playerPlaneName).transform.forward * Vector3.Distance(planPosition, this.transform.position) / 2;
            speed = 50f; //35
        }
        else
        {
            speed = 60f; //40
            if (Time.time - timer >= Random.Range(cadenceInter1, cadenceInter2)) // Si le temps entre 2 tir est respecté
            {
                Debug.Log("Tire de l'IA");
                timer = Time.time; // On modifi le timer pour le prochain tir
                Instantiate(bullet, transform.position + transform.forward, transform.rotation);
            }
        }

        Vector3 direction = planPosition - transform.position;
        direction.Normalize();
        if (Vector3.Distance(transform.position, new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z)) < 20 / reduce)
        {
            transform.position += direction * speed * Time.deltaTime / reduce + new Vector3(0, 20, 0) / reduce;
        }
        else
        {
            transform.position += direction * speed * Time.deltaTime / reduce;
        }
        transform.LookAt(planPosition);

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);     //hauteur du terrain sous l'avion

        if (terrainHeightWhereWeAre > transform.position.y && isAlive)                                          //si l'avion est sous le terrain
        {
            isAlive = false;
            Destroy(gameObject);
            GlobalSolo.enemiesleft--;                                                                    //utiliser pour la victoire         
        }
    }

    void OnTriggerStay(Collider obj)
    {
        if (obj.gameObject.tag != "player" && isAlive)                                                          //empecher le mode kamikaze
        {
            isAlive = false;
            GlobalSolo.enemiesleft--;                                                                    //utiliser pour la victoire
        }

        Destroy(this.gameObject);
        // A ajouter un effet d'explosion ici
    }
}
