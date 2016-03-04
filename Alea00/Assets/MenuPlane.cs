using UnityEngine;
using System.Collections;

public class MenuPlane : MonoBehaviour {
    private float time = 1.0f;
	// Use this for initialization
	void Start () {
        Debug.Log("Script added to : " + gameObject.name) ;
	}
	
	// Update is called once per frame
	void Update () {
        time += 0.03f;
        transform.position += transform.forward * Time.deltaTime * (5.0f / time);
	}
}
