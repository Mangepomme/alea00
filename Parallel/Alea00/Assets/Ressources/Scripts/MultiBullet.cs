using UnityEngine;
using System.Collections;

public class MultiBullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        
        Destroy(gameObject);
    }
}
