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

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        if(collision.GetComponent<Gunner>() != null)
        {
            collision.gameObject.GetComponent<Gunner>().decHP(bulDmg);
        }
        //Debug.Log("Collision");
        if (collision.GetComponent<Armadillo>() != null)
        {
            collision.gameObject.GetComponent<Armadillo>().decHealth(bulDmg);
        }

        if (collision.GetComponent<GunGoon>() != null)
        {
            collision.gameObject.GetComponent<GunGoon>().decHealth(bulDmg);
        }
    }
}
