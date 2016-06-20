using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public int xSpeed;
    public int ySpeed;
    public int zSpeed;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(new Vector3(xSpeed, ySpeed, zSpeed));
	}
}
