using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlanePilot : MonoBehaviour
{
    public float speed;
    public float speedMax;
    public float speedMin;
    public float boost;
    public float boostSpeedMax;                                                                   //vitesse max que peut faire atteindre le boost
    public float maneuverability;
    public int team;

    //gestion de la réduction de taille (même si c'est pas la taille qui compte :)
    public float reduce = 30;

    //gestion de la caméra
    public float cameraBias;
    public float cameraSetback;
    public float cameraHeight;

    public float timer = 0;

    //pour les menus de victoire et de fin
    public GameObject MenuGameOver;

    // Style de texte (style de vitesse et altitude)
    public GUIStyle styleText;
    public Texture Compteur;

    void OnGUI()
    {
        //Compteur
        GUI.DrawTexture(new Rect(0, Screen.height - 150, 150, 150), Compteur);
        // Vitesse
        GUI.TextArea(new Rect(5, Screen.height - 25, 100, 100), "Vitesse : " +  ((int)speed).ToString() + " km/h", styleText);
        // Altitude absolut
        GUI.TextArea(new Rect(5, Screen.height - 50, 100, 100), "Alt (abs) : " + ((int)transform.position.y).ToString() + "  m", styleText);
        // Altitude relative
        GUI.TextArea(new Rect(5, Screen.height - 75, 100, 100), "Alt (rel) : " + ((int)(transform.position.y - Terrain.activeTerrain.SampleHeight(transform.position))).ToString() + " m", styleText);
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("plane pilot script added to : " + gameObject.name); //permet de tester que le script est bien chargé par unity
        team = 1;
        //GameObject.Find("Mitraillette").transform.GetComponent<Tire>().team = team;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float bias = cameraBias;
        
        Vector3 moveCamTo = transform.position - transform.forward * cameraSetback / reduce + Vector3.up * cameraHeight / reduce;   //gestion de la camera : camera stable

        Camera.main.transform.position = Camera.main.transform.position * bias + (1.0f - bias) * moveCamTo;     //bias = ralentissement de la camera (entre 0 et 1) : 0.96 ou 0.70 ou 0.50
        Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);               //le "+ transform.forward * xf" sert a pointer la camera non pas vers l'avion mais vers ou il va
                                                                                                    //pour la camera subjective, enlever les 3 lignes et mettre Main Camera dans PlaneWhole

        transform.position += transform.forward * Time.deltaTime * speed / reduce;                           //deplacement : le vecteur unitaire tangent * le tps écoulé entre 2 frames * la vitesse
        transform.Rotate(Input.GetAxis("Vertical") * maneuverability,                               //rotation de l'avion en fonction des commandes de Unity (les touches qui gerent les différents virages : vertical, horizontal)
                                        Input.GetAxis("Steering") * maneuverability * 0.3f, 
                                        Input.GetAxis("Horizontal") * 2.0f * maneuverability);

        speed -= transform.forward.y * Time.deltaTime * 50.0f ;                                      //gestion de la vitesse en fonction de l'inclinaison de l'avion
        float accel = Input.GetAxis("Accelerate");
        if (speed < boostSpeedMax && accel > 0.0f)
        {
            speed += accel * Time.deltaTime * boost;
        }
        else if(accel < 0.0f)
        {
            speed += accel * Time.deltaTime * boost ;
        }

        if(speed > speedMax)                                                                        //gestion de la vitesse max
        {
            speed = speedMax;
        }
        if(speed < speedMin)                                                                        //gestion de la vitesse min
        {
            speed = speedMin;
        }

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);     //hauteur du terrain sous l'avion

        if(terrainHeightWhereWeAre > transform.position.y
            || transform.position.x < 0 || transform.position.z < 0
            || transform.position.x > 500 || transform.position.z > 500
            || transform.position.y < 0 || transform.position.y > 200)                                          //si l'avion est sous le terrain ou dépasse les limites
        {
            Debug.Log("Out of bounds !");
            Destroy(gameObject);                                                                    //ajouter ici les pbs de l'avion en cas de collision avec le sol

            PlayerPrefs.SetString("End", "Lose");
            Application.LoadLevel("End");
        }        
	}

    void OnTriggerStay(Collider obj)
    {
        Debug.Log("collision!") ;
        if(obj.gameObject.tag != "gate")
        {
            Destroy(this.gameObject);
            // A ajouter un effet d'explosion ici
            PlayerPrefs.SetString("End", "Lose");
            Application.LoadLevel("End") ;
        }
    }
}
