using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tire : MonoBehaviour {

    public GameObject bullet; // Gameobject de la balle
    public float timer = 0; // Banal timer
    public float cadence = 0.5f; // Cadence de tir (intervale entre 2 tir)
    public int team; // Equipe de la balle

    // Use this for initialization
    void Start ()
    {
        Debug.Log("Tire initialisé");
        timer = Time.time; // Initialisation du timer
        team = 0;

    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if (Input.GetAxis("Shoot") != 0) // Si la touche de tir a était appuyé
        {
            if (Time.time - timer >= cadence) // Si le temps entre 2 tir est respecté
            {
                timer = Time.time; // On modifi le timer pour le prochain tir
                Instantiate(bullet, transform.position, transform.rotation); // On instantie la balle
                bullet.transform.GetComponent<MoveBullet>().team = team; // On initialise l'equipe de la balle

                Debug.Log("Tire tire team : " + team.ToString());
            }
        }

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeightWhereWeAre > transform.position.y) //si la balle touche le sol
        {
            Destroy(gameObject);
        }  
    }
}
