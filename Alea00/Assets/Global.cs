﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Global : MonoBehaviour {

    public GameObject Plan;
    public GameObject IA_Plan;
    public float timer;
    public float delaySpawn = 3f;
    public bool tem = true;
    public static int enemiesleft; //a modifier en fonction du niveau (faire des if sur le niveau)
    public int enemiescheck;

    // Use this for initialization
    void Start ()
    {
        enemiesleft = 1;
        timer = Time.time;
        Instantiate(Plan, transform.position, new Quaternion(0, 0, 0, 0)); // On instantie l'avion
    }
	
	// Update is called once per frame
	void Update ()
    {
        enemiescheck = enemiesleft;
        if(Time.time - timer >= delaySpawn && tem)
        {
            Instantiate(IA_Plan, transform.position, new Quaternion(0, 0, 0, 0)); // On instantie l'avion enemie
            tem = false;
        }

        if (enemiesleft <= 0)
        {
            Application.LoadLevel("Win") ;
        }
    }
}
