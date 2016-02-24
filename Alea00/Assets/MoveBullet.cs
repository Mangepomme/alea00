using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {

    public static float speedBullet = -200f;
    public Vector3 Direction;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Direction = PlanePilot.PlanDirection;
        Direction.Normalize();
        transform.Translate(Direction * speedBullet * Time.deltaTime);
    }
}
