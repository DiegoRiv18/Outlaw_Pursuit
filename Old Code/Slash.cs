using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shash : MonoBehaviour
{
    private float Delay = 0.1f;
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, Delay);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
