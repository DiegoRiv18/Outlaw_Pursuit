using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGoon : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public EnemyRevolver goonGun;
    public float bullSpeed = 10;
    public int health = 50;
    public bool flip = false;
    // Update is called once per frame
    void Update()
    {
        //Face Player
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
    private void Shoot()
    {
        // get position of player on screen
        Vector2 playerPos = player.transform.position;


        // set the bullet to spawn next to the player in the position they are facing

        Vector2 bulletPos;

        if (player.GetComponent<Universal_Movement>().facingRight)
        {
            bulletPos = goonGun.transform.GetChild(2).position;
        }

        else
        {
            bulletPos = goonGun.transform.GetChild(2).position;
        }

        // Direction bullet is shot
        Vector2 bulletDirection = (playerPos - bulletPos).normalized;


        float angle = Vector2.SignedAngle(transform.up, bulletDirection);

        //Debug.Log(angle);
        if ((player.GetComponent<Universal_Movement>().facingRight && angle < 0) || (!player.GetComponent<Universal_Movement>().facingRight && angle > 0))
        {
            var bullet = Instantiate(bulletPrefab, bulletPos, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletDirection.x, bulletDirection.y) * bullSpeed;
        }

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
