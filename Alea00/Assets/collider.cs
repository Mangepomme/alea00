using UnityEngine;
using System.Collections;

public class collider : MonoBehaviour {

    void OnCollisionEnter(collider col)
    {
        Debug.Log("collision");

        if (col.gameObject.name == "planEnemy")
        {
            Destroy(col.gameObject);
        }
        else
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

    }
}
