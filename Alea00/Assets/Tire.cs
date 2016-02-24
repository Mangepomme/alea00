using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tire : MonoBehaviour {

    public KeyCode TrigerKey = KeyCode.Space;
    public GameObject bullet;

    // Use this for initialization
    void Start ()
    {
        Debug.Log("Tire initialisé");

    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if (Input.GetKey(TrigerKey))
        {
            Debug.Log("Tire Effectué");
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
