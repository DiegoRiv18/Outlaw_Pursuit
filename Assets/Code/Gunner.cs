using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

using UnityEngine;
using UnityEngine.UIElements;

public class Gunner : MonoBehaviour
{
    // Unique code for the Gunner Character
    public Universal_Movement info;
    public GameObject BulletPrefab;
    public float bullSpeed = 10;
    public int hp;


    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
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
        }

        else
        {
            bulletPos = FindAnyObjectByType<revolver>().transform.GetChild(2).position;
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
       
    }
    public void decHP(int amt)
    {
        hp -= amt;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
