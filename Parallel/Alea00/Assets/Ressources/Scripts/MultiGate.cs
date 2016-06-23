using UnityEngine;
using System.Collections;

public class MultiGate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            var player = obj.gameObject.GetComponent<MultiPilot>();
            player.nbgatetaken++;
            Destroy(this.gameObject);
        }
    }

}
