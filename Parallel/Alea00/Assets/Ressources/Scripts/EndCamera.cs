using UnityEngine;
using System.Collections;

public class EndCamera : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        string s = PlayerPrefs.GetString("End");
        if(s == "Win")
        {
            transform.position = new Vector3(500, 0, -100);

            string url = "";
            url += "http://alea00.comlu.com/ADD-SCORE.php?GAMEMODE=";
            string lvl = PlayerPrefs.GetInt("Level").ToString();
            url += lvl;
            url += "&PSEUDO=";
            string pseudo = PlayerPrefs.GetString("Pseudo");
            url += pseudo;
            url += "&PLANTYPE=";
            string plane = "Fighter";
            /*int p = PlayerPrefs.GetInt("Plane");
            if(p == )*/
            url += plane;
            url += "&SCORE=";
            url += PlayerPrefs.GetInt("Score").ToString();

            Application.OpenURL(url);
        }
        else
        {
            transform.position = new Vector3(0, 0, -100);
        }
        
    }
	
	// Update is called once per frame
	void Update ()
    {

    }
}
