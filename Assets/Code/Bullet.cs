using BarthaSzabolcs.Tutorial_SpriteFlash;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Bullet : MonoBehaviour
{
    public int bulDmg = 30;

    void OnBecameInvisible()
    {
        Bullet.Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);

        if (collision.GetComponent<Gunner>() != null)
        {
            Gunner gunman = collision.gameObject.GetComponent<Gunner>();
            if(gunman.shield.enabled == true)
            {
                gunman.shield.enabled = false;
            }
            else
            {
                gunman.decHP(bulDmg);
            }
        }
        //Debug.Log("Collision");
        if(Shop.Singleton != null)
        {
            
            if (collision.GetComponent<Armadillo>() != null)
            {
                collision.gameObject.GetComponent<Armadillo>().decHealth(bulDmg + Shop.Singleton.getDmg());
            }

            if (collision.GetComponent<GunGoon>() != null)
            {
                collision.gameObject.GetComponent<GunGoon>().decHealth(bulDmg + Shop.Singleton.getDmg());
            }

            if (collision.GetComponent<Explosion>() != null)
            {
                collision.gameObject.GetComponent<Explosion>().boom();
            }
        }
    }
}
