using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tire : MonoBehaviour {

    public KeyCode TrigerKey = KeyCode.Space; // Touche pour tirer
    public GameObject bullet; // Gameobject de la balle
    public float timer = 0; // Banal timer
    public float cadence = 0.5f; // Cadence de tir (intervale entre 2 tir)
    public static int team;

    // Use this for initialization
    void Start ()
    {
        Debug.Log("Tire initialisé");
        timer = Time.time; // Initialisation du timer
        team = 1;

    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if (Input.GetKey(TrigerKey)) // Si la touche de tir a était appuyé
        {
            if (Time.time - timer >= cadence) // Si le temps entre 2 tir est respecté
            {
                timer = Time.time; // On modifi le timer pour le prochain tir
                Instantiate(bullet, transform.position, transform.rotation); // On instantie la balle
            }
        }
    }
}
