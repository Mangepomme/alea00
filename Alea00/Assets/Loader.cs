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

    public void load_scene1()
    {
        Application.LoadLevel("SoloGame");
    }


}
