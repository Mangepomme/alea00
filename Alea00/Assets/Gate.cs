using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider obj)
    {
        if (obj.gameObject.tag == "player")
        {
            GlobalRace.gatesleft--;
            Destroy(this.gameObject);
        }
    }
}
