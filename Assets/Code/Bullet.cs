using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnBecameInvisible()
    {
 
        Bullet.Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<Bullet>() == null)
        {
            Bullet.Destroy(gameObject);
        }

    }
}
