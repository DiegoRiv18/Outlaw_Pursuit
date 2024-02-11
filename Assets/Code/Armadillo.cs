using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Armadillo : MonoBehaviour
{
    bool active;
    public int health;
    public GameObject player;
    float speed;
    private bool hit;
    int dmg = 20;
    public GameObject moneyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        health = 100;
        player = FindObjectOfType<Gunner>().gameObject;
        speed = 0;
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - player.transform.position.x < 5 && transform.position.y < -1.5 && !active)
        {
            active = true;
            speed = -0.01f;
        }
        if (active)
        {
            transform.position = transform.position + transform.right * speed;
            if (player.transform.position.x - transform.position.x < -4 && speed > -0.05f)
            {
                speed -= 0.05f * Time.deltaTime;
            }
            else if (player.transform.position.x - transform.position.x > 4 && speed < 0.05f)
            {
                speed += 0.05f * Time.deltaTime;
            }
        }
    }

    public void decHealth (int hp)
    {
        health -= hp;
        if (health <= 0)
        {
            Instantiate(moneyPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Gunner>() != null && !hit)
        {
            hit = true;
            collision.gameObject.GetComponent<Gunner>().decHP(dmg);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Gunner>() != null && hit)
        {
            hit = false;
        }
    }
}
