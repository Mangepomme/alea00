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

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);     //hauteur du terrain sous l'avion

        if (terrainHeightWhereWeAre > transform.position.y)                                          //si l'avion est sous le terrain
        {
            Destroy(gameObject);
            Global.enemiesleft--;                                                                    //utiliser pour la victoire         
        }
    }

    void OnTriggerStay(Collider obj)
    {
        Destroy(this.gameObject);
        // A ajouter un effet d'explosion ici

        if (obj.gameObject.tag != "player")                                                          //empecher le mode kamikaze
        {
            Global.enemiesleft--;                                                                    //utiliser pour la victoire
        }
    }
}
