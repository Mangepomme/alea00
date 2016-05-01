using UnityEngine;
using System.Collections;

public class IA_Plan : MonoBehaviour {

    public string playerPlaneName;
    public GameObject bullet; // Gameobject de la balle
    float speed;
    //float speedMax = 150.0f;
    //float speedMin = 10.0f;
    //float boost = 30.0f;
    //float boostSpeedMax = 100.0f;                                                                   //vitesse max que peut faire atteindre le boost
    //float maneuverability = 1.0f;
    public bool isAlive;

    public float timer;

    public float cadenceInter1;
    public float cadenceInter2;

    // Use this for initialization
    void Start()
    {
        isAlive = true;
        Debug.Log("plane pilot script added to : " + gameObject.name);                              //permet de tester que le script est bien chargé par unity

        speed = 50f;
        timer = 0;
        cadenceInter1 = 2.0f; // Difficulte normal
        cadenceInter2 = 8.0f; // Difficulte normal
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 planPosition = GameObject.Find(playerPlaneName).transform.position;

        planPosition += GameObject.Find(playerPlaneName).transform.forward * Vector3.Distance(planPosition, this.transform.position) / 2;

        if (Time.time - timer >= Random.Range(cadenceInter1, cadenceInter2)) // Si le temps entre 2 tir est respecté
        {
            Debug.Log("Tire de l'IA");
            timer = Time.time; // On modifi le timer pour le prochain tir
            Instantiate(bullet, transform.position - new Vector3(0, 10, 0), transform.rotation);
        }

        Vector3 direction = planPosition - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(planPosition);

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);     //hauteur du terrain sous l'avion

        if (terrainHeightWhereWeAre > transform.position.y && isAlive)                                          //si l'avion est sous le terrain
        {
            isAlive = false;
            Destroy(gameObject);
            Global.enemiesleft--;                                                                    //utiliser pour la victoire         
        }
    }

    void OnTriggerStay(Collider obj)
    {
        Destroy(this.gameObject);
        // A ajouter un effet d'explosion ici

        if (obj.gameObject.tag != "player" && isAlive)                                                          //empecher le mode kamikaze
        {
            isAlive = false;
            Global.enemiesleft--;                                                                    //utiliser pour la victoire
        }
    }
}
