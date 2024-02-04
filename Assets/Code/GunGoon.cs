using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGoon : MonoBehaviour
{
    public GameObject player;
    public Bullet bullet;
    public float bullSpeed = 10;
    public int health = 50;
    public bool flip;
    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;

        if(player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? 1 : -1);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? 1 : -1);
        }

        transform.localScale = scale;
    }

    public void decHealth(int hp)
    {
        health -= hp;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
