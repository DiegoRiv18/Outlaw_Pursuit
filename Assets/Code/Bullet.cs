using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int bulDmg = 20;

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
        if(collision.GetComponent<Gunner>() != null)
        {
            collision.gameObject.GetComponent<Gunner>().decHP(bulDmg);
            Destroy(this.gameObject);
        }
        //Debug.Log("Collision");
        if (collision.GetComponent<Armadillo>() != null)
        {
            collision.gameObject.GetComponent<Armadillo>().decHealth(bulDmg);
            Destroy(this.gameObject);
        }

        if (collision.GetComponent<GunGoon>() != null)
        {
            collision.gameObject.GetComponent<GunGoon>().decHealth(bulDmg);
            Destroy(this.gameObject);
        }
    }
}
