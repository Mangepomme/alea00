using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoTir : MonoBehaviour
{

    public GameObject bullet;
    public float timer = 0;
    public float cadence;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Tir ennemi initialisé");
        timer = Time.time;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time - timer >= cadence) // Si le temps entre 2 tir est respecté
        {
            timer = Time.time;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}