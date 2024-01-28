using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    // Unique code for the Gunner Character
    public Universal_Movement info;
    public GameObject BulletPrefab;
    public float bulletSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Left Click on mouse
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (info.facingRight)
        {
            //Get bullet position
            var BulletPos = new Vector2(info.GetComponent<Transform>().localPosition.x + (transform.right.x * 1.5f), info.GetComponent<Transform>().localPosition.y);
            //Create bullet
            var bullet = Instantiate(BulletPrefab, BulletPos, Quaternion.identity);
            //Set velocity (BROKEN)
            bullet.GetComponent<Rigidbody2D>().velocity = info.transform.right * bulletSpeed;

            //Debug.Log("Shooting right");
        }
        else if (info.facingRight == false)
        {
            var BulletPos = new Vector2(info.GetComponent<Transform>().localPosition.x - (transform.right.x * 1.5f), info.GetComponent<Transform>().localPosition.y);
            var bullet = Instantiate(BulletPrefab, BulletPos, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = -1 * bulletSpeed * info.transform.right;

            //Debug.Log("Shooting left");
        }
    }
}
