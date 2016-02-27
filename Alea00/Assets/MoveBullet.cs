using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {

    public static float speedBullet = 250f; // Vitesse de la balle
    public float lifeTime = 5f; // Durée de vie de la balle

    // Use this for initialization
    void Start ()
    {
        AudioSource audio = GetComponent<AudioSource>(); // On récupère le son de l'objet bullet
        audio.Play(); // On joue le son
        Destroy(this.gameObject, lifeTime); // On prévoi la destruction de la balle
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * speedBullet * Time.deltaTime); // Permet le déplacement de la balle
    }
}
