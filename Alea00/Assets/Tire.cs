using UnityEngine;
using System.Collections;

public class Tire : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Tire initialisé");
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        Debug.Log("Tire Effectué");
        if (Input.GetButtonDown("Fire1"))
        {
            float xAxe = this.transform.position.x;
            float yAxe = this.transform.position.y;
            float zAxe = this.transform.position.z;
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = new Vector3(xAxe, yAxe, zAxe);
        }
    }
}
