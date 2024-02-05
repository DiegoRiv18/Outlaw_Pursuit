using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGoon : MonoBehaviour
{
    public GameObject player;
    public EnemyRevolver gun;
    public GameObject bulletPrefab;
    public float bullSpeed = 10;
    public int health = 50;
    public bool flip = false;
    float timer = 0;
    public float CoolDownTime = 3;
    private Vector2 OffsetToPlayer => player.transform.position - transform.position;
    private Vector2 HeadingToPlayer => OffsetToPlayer.normalized;


    private void OnBecameVisible()
    {
        timer = Time.time;
    }
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

        if (Time.time > timer)
        {
            Shoot();
            timer += CoolDownTime;
        }
    }
    private void Shoot()
    {
        var bulletPos = gun.transform.position;
        var bullet = Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = HeadingToPlayer * bullSpeed;

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
