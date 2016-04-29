using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void exit()
    {
        Application.Quit();
    }

    public void load_sologame()
    {
        Debug.Log("load solo");
        Application.LoadLevel("SoloGame");
    }

    public void load_racemode()
    {
        Debug.Log("load race");
        Application.LoadLevel("RaceMode") ;
    }

    public void load_menu()
    {
        Application.LoadLevel("MainMenu");
    }
}
