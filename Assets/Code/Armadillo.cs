using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Armadillo : MonoBehaviour
{
    bool active;
    public int health;
    public GameObject player;
    public float speed;
    private bool hit;
    int dmg = 20;
    public GameObject moneyPrefab;
    Vector3 curr_rotation;
    Vector3 rightvec;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        health = 60;
        player = FindObjectOfType<Gunner>().gameObject;
        speed = 0;
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        curr_rotation = transform.GetChild(1).eulerAngles;

        if (player != null)
        {
            if (transform.position.x - player.transform.position.x < 8 && Mathf.Abs(transform.position.y - player.transform.position.y) < 2 && !active)
            {
                active = true;
                speed = -0.02f;
                rightvec = transform.right;
            }

            if (active)
            {
                curr_rotation.z = curr_rotation.z + 2f;
                transform.GetChild(1).eulerAngles = curr_rotation;

                transform.position = transform.position + rightvec * speed;
                if (player.transform.position.x - transform.position.x < -3 && speed > -0.05f)
                {
                    speed -= 0.05f * Time.deltaTime;
                }
                else if (player.transform.position.x - transform.position.x > 3 && speed < 0.05f)
                {
                    speed += 0.05f * Time.deltaTime;
                }
            }
        }
    }

    public void decHealth(int hp)
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
        if (collision.GetComponent<Gunner>() != null && !hit)
        {
            hit = true;
            Gunner gunman = collision.gameObject.GetComponent<Gunner>();
            if (gunman.shield.enabled == true)
            {
                gunman.shield.enabled = false;
            }
            else
            {
                UnityEngine.Debug.Log("hit");
                gunman.decHP(dmg);
            }
        }
        if (collision.GetComponent<ExplosionRange>() != null)
        {
            decHealth(100);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Gunner>() != null && hit)
        {
            hit = false;
        }
    }
}