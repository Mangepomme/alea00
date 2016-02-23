using UnityEngine;
using System.Collections;

public class PlanePilot : MonoBehaviour {
    float speed = 60.0f;
    float speedMax = 150.0f;
    float speedMin = 10.0f;
    float boost = 30.0f;
    float boostSpeedMax = 100.0f;                                                                   //vitesse max que peut faire atteindre le boost
    float maneuverability = 1.0f;

	// Use this for initialization
	void Start () {
        Debug.Log("plane pilot script added to : " + gameObject.name);                              //permet de tester que le script est bien chargé par unity
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float bias = 0.90f;
        
        Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;   //gestion de la camera : camera stable
        //Vector3 moveCamTo = transform.position - transform.forward * 10.0f + transform.up * 5.0f;   //gestion de la camera : camera partiellement subjective

        //Camera.main.transform.position = moveCamTo;
        Camera.main.transform.position = Camera.main.transform.position * bias + (1.0f - bias) * moveCamTo;     //bias = ralentissement de la camera (entre 0 et 1) : 0.96 ou 0.70 ou 0.50
        Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);               //le "+ transform.forward * xf" sert a pointer la camera non pas vers l'avion mais vers ou il va
                                                                                                    //pour la camera subjective, enlever les 3 lignes et mettre Main Camera dans PlaneWhole

        transform.position += transform.forward * Time.deltaTime * speed;                           //deplacement : le vecteur unitaire tangent * le tps écoulé entre 2 frames * la vitesse
        transform.Rotate(Input.GetAxis("Vertical") * maneuverability,                               //rotation de l'avion en fonction des commandes de Unity (les touches qui gerent les différents virages : vertical, horizontal)
                                        0.0f * maneuverability,
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

        if(terrainHeightWhereWeAre > transform.position.y)                                          //si l'avion est sous le terrain
        {
                                                                                                    //ajouter ici les pbs de l'avion en cas de collision avec le sol

            transform.position = new Vector3(transform.position.x,
                                                terrainHeightWhereWeAre,
                                                transform.position.z) ;
        }
	}
}
