﻿using UnityEngine;
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

    public float timer = 0;

    // Style de texte (style de vitesse et altitude)
    public GUIStyle styleText;
    public Texture Compteur;

    void OnGUI()
    {
        //Compteur
        GUI.DrawTexture(new Rect(0, Screen.height - 130, 130, 130), Compteur);
        // Vitesse
        GUI.TextArea(new Rect(10, Screen.height - 60, 100, 100), ((int)speed).ToString() + " km/h", styleText);
        // Altitude
        GUI.TextArea(new Rect(10, Screen.height - 30, 100, 100), ((int)(transform.position.y - Terrain.activeTerrain.SampleHeight(transform.position))).ToString() + " m", styleText);
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("plane pilot script added to : " + gameObject.name); //permet de tester que le script est bien chargé par unity
        team = 1;
        GameObject.Find("Mitraillette").transform.GetComponent<Tire>().team = team;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float bias = 0.90f;
        
        Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;   //gestion de la camera : camera stable

        Camera.main.transform.position = Camera.main.transform.position * bias + (1.0f - bias) * moveCamTo;     //bias = ralentissement de la camera (entre 0 et 1) : 0.96 ou 0.70 ou 0.50
        Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);               //le "+ transform.forward * xf" sert a pointer la camera non pas vers l'avion mais vers ou il va
                                                                                                    //pour la camera subjective, enlever les 3 lignes et mettre Main Camera dans PlaneWhole

        transform.position += transform.forward * Time.deltaTime * speed;                           //deplacement : le vecteur unitaire tangent * le tps écoulé entre 2 frames * la vitesse
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
            || transform.position.x > 3000 || transform.position.z > 3000
            || transform.position.y < 0 || transform.position.y > 1000)                                          //si l'avion est sous le terrain ou dépasse les limites
        {
            Destroy(gameObject);                                                                    //ajouter ici les pbs de l'avion en cas de collision avec le sol

            Application.LoadLevel("GameOver") ;
        }        
	}

    void OnTriggerStay(Collider obj)
    {
        if(obj.gameObject.tag != "gate")
        {
            Destroy(this.gameObject);
            // A ajouter un effet d'explosion ici
            Application.LoadLevel("GameOver");
        }
    }
}
