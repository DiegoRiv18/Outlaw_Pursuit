using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int bulDmg = 10;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.GetComponent<Armadillo>() != null)
        {
            collision.gameObject.GetComponent<Armadillo>().decHealth(bulDmg);
            Destroy(this.gameObject);
        }
    }
}
