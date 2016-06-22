using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GlobalSolo : MonoBehaviour {

    //Pour tous les modes
    public GameObject Plan;
    public GameObject Gate;
    public GameObject Fighter;
    public GameObject Sprinter;
    public GameObject SmallConqueror;
    public GameObject Conqueror;
    public GameObject Prototype;
    public int planetype;
    public GUIStyle styleText;

    //Pour le mode Race
    public int gatesnumber;
    public static int gatesleft;
    public int gatesleftdisplay;
    public int timeleft;

    //Pour les modes fight et boss
    public GameObject Hunter;
    public GameObject Destroyer;
    public GameObject ChaosSun;
    public float timer;
    public float delaySpawn = 3f;
    public static int enemiesleft;
    public int enemiescheck;
    public static int pvleft;
    public int pvcheck;

    // Use this for initialization
    void Start ()
    {
        int lvl = PlayerPrefs.GetInt("Level");
        if (lvl == 1 || lvl == 3)
        {
            planetype = PlayerPrefs.GetInt("Plane");

            gatesleft = gatesnumber;

            timeleft = 3000;

            if (planetype == 4)
            {
                Plan = Prototype;
                Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion
            }
            else if (planetype == 1)
            {
                Plan = Sprinter;
                Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion
            }
            else if (planetype == 2)
            {
                Plan = SmallConqueror;
                Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion
            }
            else if (planetype == 3)
            {
                Plan = Conqueror;
                Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion
            }
            else
            {
                Plan = Fighter;
                Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion
            }

            if(lvl == 1)
            {
                Instantiate(Gate, new Vector3(29.9f, 6.5f, 57.68f), new Quaternion(0, 90, 90, 0));
                Instantiate(Gate, new Vector3(30f, 6.5f, 67.46f), new Quaternion(0, 90, 90, 0));
                Instantiate(Gate, new Vector3(49.9f, 3.63f, 20.72f), new Quaternion(0, 90, 90, 0));
                Instantiate(Gate, new Vector3(72.6f, 3.19f, 26.51f), new Quaternion(0, 90, 90, 0));
                Instantiate(Gate, new Vector3(61.59f, 6.822f, 38.302f), new Quaternion(0, 90, 90, 0));
                Instantiate(Gate, new Vector3(77.45f, 11.4f, 59.66f), new Quaternion(0, 90, 90, 0));
                Instantiate(Gate, new Vector3(76.07f, 11.5f, 65.18f), new Quaternion(0, 90, 90, 0));
                Instantiate(Gate, new Vector3(74.32f, 11.5f, 73.25f), new Quaternion(0, 90, 90, 0));
            }
        }
        else if (lvl == 2 || lvl == 4)
        {
            planetype = PlayerPrefs.GetInt("Plane");

            enemiesleft = 3;
            enemiescheck = enemiesleft;
            timer = Time.time;

            if (planetype == 4)
            {
                Plan = Prototype;
                Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion
            }
            else if (planetype == 1)
            {
                Plan = Sprinter;
                Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion
            }
            else if (planetype == 2)
            {
                Plan = SmallConqueror;
                Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion
            }
            else if (planetype == 3)
            {
                Plan = Conqueror;
                Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion
            }
            else
            {
                Plan = Fighter;
                Instantiate(Plan, transform.position, transform.rotation); // On instantie l'avion
            }
            if(lvl == 2)
            {
                Instantiate(Hunter, new Vector3(32, 30, 43), transform.rotation);
                Instantiate(Hunter, new Vector3(30, 30, 30), transform.rotation);
                Instantiate(Hunter, new Vector3(75, 15, 65), transform.rotation);
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        int lvl = PlayerPrefs.GetInt("Level");
        if(lvl == 2 || lvl == 4)
        {
            if(enemiesleft == 0)
            {
                PlayerPrefs.SetString("End", "Win");
                Application.LoadLevel("End");
            }
        }
        else if(lvl == 1 || lvl == 3)
        {
            timeleft--;
            if (timeleft <= 0)
            {
                PlayerPrefs.SetString("End", "Lose");
                Application.LoadLevel("End");
            }

            gatesleftdisplay = gatesleft;
            if (gatesleft <= 0)
            {
                PlayerPrefs.SetString("End", "Win");
                Application.LoadLevel("End");
            }
        }
	}

    void OnGUI()
    {
        int lvl = PlayerPrefs.GetInt("Level");
        if (lvl == 1 || lvl == 3)
        {
            // Chrono
            GUI.TextArea(new Rect(10, 10, 100, 100), "Temps restant : " + ((int)(timeleft) / 10).ToString(), styleText);
        }
        else if(lvl == 2 || lvl == 4)
        {
            GUI.TextArea(new Rect(10, 10, 100, 100), "Ennemis restants : " + ((int)(enemiesleft)).ToString(), styleText);
        }
        else
        {
            GUI.TextArea(new Rect(10, 10, 100, 100), "Points de vie restants : " + ((int)(enemiesleft)).ToString(), styleText);
        }
    }
}
