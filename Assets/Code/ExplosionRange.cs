using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<GunGoon>() != null)
        {

            collision.GetComponent<GunGoon>().decHealth(100);
        }
        if (collision.GetComponent<Gunner>() != null)
        {
            collision.GetComponent<Gunner>().decHP(100);
        }
    }
}
