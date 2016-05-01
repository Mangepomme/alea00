using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Drop : MonoBehaviour {
    public Dropdown drop;
    public GameObject loader;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ScLoader.planetype = drop.captionText.text ;
	}
}
