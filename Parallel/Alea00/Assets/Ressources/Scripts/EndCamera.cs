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
        }
        else
        {
            transform.position = new Vector3(0, 0, -100);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*string s = PlayerPrefs.GetString("End");
        Debug.Log(s);
        if (s == "Win")
        {
            transform.position = new Vector3(500, 0, -100);
        }*/
    }
}
