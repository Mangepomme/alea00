using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {

    public float bulletSpeed; // Vitesse de la balle
    public float lifeTime = 5f; // Durée de vie de la balle
    public int team;
    public float reduce = 30;

    // Use this for initialization
    void Start ()
    {
        team = 0;
        AudioSource audio = GetComponent<AudioSource>(); // On récupère le son de l'objet bullet
        audio.Play(); // On joue le son
        Destroy(this.gameObject, lifeTime); // On prévoi la destruction de la balle

        Debug.Log("Tire Effectué team : " + team.ToString());
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime / reduce); // Permet le déplacement de la balle
    }

    void OnTriggerStay(Collider obj)
    {
        Debug.Log("collision!");
        if (obj.gameObject.tag != "gate")
        {
            Destroy(this.gameObject);
        }
    }
}
