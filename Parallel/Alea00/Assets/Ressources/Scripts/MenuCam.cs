using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuCam : MonoBehaviour {
    public Transform currentMount;
    public float bias = 0.1f;

    public Dropdown PlaneChoices;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, currentMount.position, bias);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, bias);

        int val = PlaneChoices.value;string plane = PlaneChoices.itemText.text;
        //Debug.Log(val);

        PlayerPrefs.SetInt("Plane", val);
    }

    public void setMount(Transform newMount)
    {
        currentMount = newMount;
    }
}
