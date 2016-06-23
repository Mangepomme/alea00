using UnityEngine;
using System.Collections;

public class MultiBullet : MonoBehaviour
{

    void Update()
    {
        transform.Translate(Vector3.forward * 300 * Time.deltaTime / 30);
    }

    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var crash = hit.GetComponent<MultiPilot>();
        crash.CollisionBullet();
        Destroy(gameObject);
    }
}
