using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gunner : MonoBehaviour
{
    // Unique code for the Gunner Character
    public Universal_Movement info;
    public GameObject BulletPrefab;
    public float bullSpeed = 10;

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
        // get position of mouse on screen
        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);


        // set the bullet to spawn next to the player in the position they are facing

        Vector2 bulletPos;

        if (info.facingRight) 
        {
            bulletPos = FindAnyObjectByType<revolver>().transform.GetChild(2).position;
            // bulletPos = new Vector2(info.GetComponent<Transform>().localPosition.x + 1, info.GetComponent<Transform>().localPosition.y);
        }

        else
        {
            bulletPos = FindAnyObjectByType<revolver>().transform.GetChild(2).position;
           // bulletPos = new Vector2(info.GetComponent<Transform>().localPosition.x - 1, info.GetComponent<Transform>().localPosition.y);
        }

        // Direction bullet is shot
        Vector2 bulletDirection = (mousePos - bulletPos).normalized;


        float angle = Vector2.SignedAngle(transform.up, bulletDirection);

        Debug.Log(angle);
        if ((info.facingRight && angle < 0) || (!info.facingRight && angle > 0))
        {
            var bullet = Instantiate(BulletPrefab, bulletPos, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletDirection.x, bulletDirection.y) * bullSpeed;
        }
       
        //if (info.facingRight)
        //{
        //    //Get bullet position
        //    var BulletPos = new Vector2(info.GetComponent<Transform>().localPosition.x + (transform.right.x * 1.5f), info.GetComponent<Transform>().localPosition.y);
        //    //Create bullet
        //    var bullet = Instantiate(BulletPrefab, BulletPos, Quaternion.identity);
        //    //Set velocity (BROKEN)
        //    bullet.GetComponent<Rigidbody2D>().velocity = info.transform.right * bulletSpeed;

        //    //Debug.Log("Shooting right");
        //}
        //else if (info.facingRight == false)
        //{
        //    var BulletPos = new Vector2(info.GetComponent<Transform>().localPosition.x - (transform.right.x * 1.5f), info.GetComponent<Transform>().localPosition.y);
        //    var bullet = Instantiate(BulletPrefab, BulletPos, Quaternion.identity);
        //    bullet.GetComponent<Rigidbody2D>().velocity = -1 * bulletSpeed * info.transform.right;

        //    //Debug.Log("Shooting left");
   //}
    }
}
