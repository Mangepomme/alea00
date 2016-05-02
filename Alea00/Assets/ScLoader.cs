using UnityEngine;
using System.Collections;

public class ScLoader : MonoBehaviour {

    public static string planetype;
    public string planetypedisplay;

	// Use this for initialization
	void Start () {
        planetype = "Fighter";
        planetypedisplay = planetype;
    }
	
	// Update is called once per frame
	void Update () {
        planetypedisplay = planetype;

    }

    public void setPlaneType(string s)
    {
        planetype = s ;
    }

    public void exit()
    {
        Application.Quit();
    }

    public void load_sologame()
    {
        PlayerPrefs.SetString("PlaneType", planetype);
        Debug.Log("load solo");
        Application.LoadLevel("SoloGame");
    }

    public void load_racemode()
    {
        PlayerPrefs.SetString("PlaneType", planetype);
        Debug.Log("load race");
        Application.LoadLevel("RaceMode") ;
    }

    public void load_menu()
    {
        PlayerPrefs.SetString("PlaneType", planetype);
        Debug.Log("load menu");
        Application.LoadLevel("MainMenu");
    } 

    public void load_multi()
    {
        PlayerPrefs.SetString("PlaneType", planetype);
        Debug.Log("load multi");
        Application.LoadLevel("MultiTest");
    }
}
