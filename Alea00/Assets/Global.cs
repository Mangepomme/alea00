using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Global : MonoBehaviour {

    public GameObject Plan;
    
    // Use this for initialization
    void Start ()
    {
        Instantiate(Plan, transform.position, new Quaternion(0, 0, 0, 0)); // On instantie l'avion
    }
	
	// Update is called once per frame
	void Update ()
    {

    }
}
