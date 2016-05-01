using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GlobalRace : MonoBehaviour {

    public GameObject Plan;
    public GameObject Gate;
    public GameObject Fighter;
    public GameObject Battleship;
    public GameObject Sprinter;
    public GameObject Prototype;
    public string planetype;
    public int gatesnumber;
    public static int gatesleft;
    public int gatesleftdisplay;
    public int timeleft;

    // Use this for initialization
    void Start ()
    {
        PlayerPrefs.SetString("Level", "race");

        planetype = PlayerPrefs.GetString("PlaneType");

        gatesleft = gatesnumber;

        timeleft = 3000;

        if (planetype == "Prototype")
        {
            Plan = Prototype;
            Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion
        }
        else if (planetype == "Battleship")
        {
            Plan = Battleship;
            Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion
        }
        else if (planetype == "Sprinter")
        {
            Plan = Sprinter;
            Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion
        }
        else
        {
            Plan = Fighter;
            Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        timeleft--;
        if (timeleft <= 0)
        {
            Application.LoadLevel("GameOver");
        }

        gatesleftdisplay = gatesleft;
        if (gatesleft <= 0)
        {
            Application.LoadLevel("Win");
        }
    }
}
