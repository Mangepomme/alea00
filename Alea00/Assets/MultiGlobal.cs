using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MultiGlobal : MonoBehaviour
{

    public GameObject Plan;
    public GameObject Fighter; 
    public GameObject Battleship;
    public GameObject Sprinter;
    public GameObject Prototype;
    public GameObject IA_Plan1;
    public GameObject IA_Plan2;
    public GameObject IA_Plan3;
    public float timer;
    public float delaySpawn = 3f;
    public static int enemiesleft;
    public int enemiescheck;

    public bool summon1;
    public bool summon2;
    public bool summon3;

    public string planetype;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetString("Level", "fight");

        planetype = PlayerPrefs.GetString("PlaneType");

        enemiesleft = 0;
        enemiescheck = enemiesleft;
        timer = Time.time;

        if (planetype == "Prototype")
        {
            Plan = Prototype;
            Instantiate(Plan, transform.position, new Quaternion(0, 0, 0, 0)); // On instantie l'avion
        }
        else if (planetype == "Battleship")
        {
            Plan = Battleship;
            Instantiate(Plan, transform.position, new Quaternion(0, 0, 0, 0)); // On instantie l'avion
        }
        else if (planetype == "Sprinter")
        {
            Plan = Sprinter;
            Instantiate(Plan, transform.position, new Quaternion(0, 0, 0, 0)); // On instantie l'avion
        }
        else
        {
            Plan = Fighter;
            Instantiate(Plan, transform.position, new Quaternion(0, 0, 0, 0)); // On instantie l'avion
        }

        //summon1 = true;
        //summon2 = false;
        //summon3 = false;
    }

    // Update is called once per frame
    void Update()
    {



        Vector3 pos = transform.position - transform.forward * 30.0f;

        /*enemiescheck = enemiesleft;
        if (Time.time - timer >= delaySpawn && summon1)
        {
            Instantiate(IA_Plan1, pos, new Quaternion(0, 0, 0, 0)); // On instantie l'avion enemie 1
            Debug.Log("1");
            timer = Time.time;
            summon1 = false;
            summon2 = true;
        }
        else if (Time.time - timer >= delaySpawn && summon2)
        {
            Instantiate(IA_Plan2, pos, new Quaternion(0, 0, 0, 0)); // On instantie l'avion enemie 2
            Debug.Log("2");
            timer = Time.time;
            summon2 = false;
            summon3 = true;
        }
        else if (Time.time - timer >= delaySpawn && summon3)
        {
            Instantiate(IA_Plan3, pos, new Quaternion(0, 0, 0, 0)); // On instantie l'avion enemie 3
            Debug.Log("3");
            timer = Time.time;
            summon3 = false;
        }

        if (enemiesleft == 0)
        {
            Application.LoadLevel("Win");
        }*/
    }
}
