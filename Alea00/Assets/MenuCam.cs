using UnityEngine;
using System.Collections;

public class MenuCam : MonoBehaviour {
    public Transform currentMount;
    public float bias = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, currentMount.position, bias);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, bias);
    }

    public void setMount(Transform newMount)
    {
        currentMount = newMount;
    }
}
