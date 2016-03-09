using UnityEngine;
using System.Collections;

public class IA_Plan : MonoBehaviour {

    float speed = 30f;
    //float speedMax = 150.0f;
    //float speedMin = 10.0f;
    //float boost = 30.0f;
    //float boostSpeedMax = 100.0f;                                                                   //vitesse max que peut faire atteindre le boost
    //float maneuverability = 1.0f;

    public float timer = 0;

    // Use this for initialization
    void Start()
    {
        Debug.Log("plane pilot script added to : " + gameObject.name);                              //permet de tester que le script est bien chargé par unity
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 planPosition = GameObject.Find("PlaneWhole(Clone)").transform.position;
        Vector3 direction = planPosition - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(planPosition);

        //Debug.Log(planPosition);
        /*
        transform.position += transform.forward * Time.deltaTime * speed;                           //deplacement : le vecteur unitaire tangent * le tps écoulé entre 2 frames * la vitesse
        transform.Rotate(Input.GetAxis("Vertical") * maneuverability,                               //rotation de l'avion en fonction des commandes de Unity (les touches qui gerent les différents virages : vertical, horizontal)
                                        0.0f * maneuverability,
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
        */

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);     //hauteur du terrain sous l'avion

        if (terrainHeightWhereWeAre > transform.position.y)                                          //si l'avion est sous le terrain
        {
            Destroy(gameObject);                                                                     //ajouter ici les pbs de l'avion en cas de collision avec le sol

            /*transform.position = new Vector3(transform.position.x,
                                                terrainHeightWhereWeAre,
                                                transform.position.z);*/
        }
    }
}
