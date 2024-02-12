using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunGoon : MonoBehaviour
{
    public GameObject player;
    public EnemyRevolver gun;
    public GameObject bulletPrefab;
    public float bullSpeed = 15;
    public int health = 50;
    public int range = 9;
    public bool flip = false;
    private float timer;
    public float CoolDownTime = 3f;
    public GameObject moneyPrefab;
    private Vector2 OffsetToPlayer => player.transform.position - transform.position;
    private Vector2 HeadingToPlayer => OffsetToPlayer.normalized;


    private void Start()
    {
        timer = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < range)
        {
            if (this.gameObject != null)
            {
                //Face Player
                Vector3 scale = transform.localScale;

                if (player.transform.position.x > transform.position.x)
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
                    timer = Time.time + CoolDownTime;
                }
            }
        }
    }
    private void Shoot()
    {
        var bulletPos = gun.transform.GetChild(2).position;
        var bullet = Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = HeadingToPlayer * bullSpeed;

    }

    public void decHealth(int hp)
    {
        health -= hp;
        if (health <= 0)
        {
            Instantiate(moneyPrefab, transform.position, Quaternion.identity);
            if (gun != null)
            {
                Destroy(gun.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
