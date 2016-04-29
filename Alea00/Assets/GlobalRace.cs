using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GlobalRace : MonoBehaviour {

    public GameObject Plan;
    public GameObject Gate;
    public int gatesnumber;
    public static int gatesleft;
    public int gatesleftdisplay;

    // Use this for initialization
    void Start ()
    {
        gatesleft = gatesnumber;

        Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion

        //Instantiate(Gate, new Vector3(1000, 200, 2100), new Quaternion(0, 0, 90, 0)); 
    }
	
	// Update is called once per frame
	void Update ()
    {
        gatesleftdisplay = gatesleft;
        if (gatesleft <= 0)
        {
            Application.LoadLevel("Win") ;
        }
    }
}
