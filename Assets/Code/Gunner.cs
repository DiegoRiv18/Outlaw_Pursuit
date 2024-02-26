using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

using UnityEngine;
using UnityEngine.UI;

public class Gunner : MonoBehaviour
{
    // Unique code for the Gunner Character
    public Universal_Movement info;
    public GameObject BulletPrefab;
    public float bullSpeed = 10;
    public int hp;
    public HealthBar health_bar;
    public HealthBar health_two;
    public HealthBar health_three;
    int actChar;
    SpriteRenderer baseColor;
    int hpone;
    int hptwo;
    int hpthree;
    public GameObject Gun;
    bool canShoot = true;
    int shotCounter = 1; 
    float cooldownDuration = 0.25f;
    float reloadDuration = 4f;
    public GameObject reloadingStatus;
    Image hp2Co;
    Image hp1Co;
    Image hp3Co;
    public GameObject DeathScreen;

    // Start is called before the first frame update
    void Start()
    {
        reloadingStatus.SetActive(false);
        hpone = 100;
        hptwo = 100;
        hpthree = 100;
        hp = 100;
        actChar = 1;
        baseColor = transform.Find("Square").GetComponent<SpriteRenderer>();
        hp1Co = health_bar.transform.Find("Fill").GetComponent<Image>();
        hp2Co = health_two.transform.Find("Fill").GetComponent<Image>();
        hp3Co = health_three.transform.Find("Fill").GetComponent<Image>();
        DeathScreen.SetActive(false);
    }
     
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("r presed");
            StartCoroutine(reload());

        }


        //Left Click on mouse
        if (Input.GetButtonDown("Fire1") && canShoot) 
        { 
            if (actChar != 3)
            {
                StartCoroutine(ShootCooldown());
                Shoot();
                bulletcounter.ChangeAmmo(6 - shotCounter);
            }
        }
        if (Input.GetKeyDown("q"))
        {
            actChar += 1;
            if (actChar == 4) 
            {
                actChar = 1;
                baseColor.color = new Color(1, 0.509804f, 0.1647059f, 1);
                info.speed = 5;
                info.jumpPower = 8;
                hpthree = hp;
                hp = hpone;
                health_bar.SetHealthBar(hp);
                health_two.SetHealthBar(hptwo);
                health_three.SetHealthBar(hpthree);
                Gun.SetActive(true);
                hp2Co.color = Color.blue;
                hp3Co.color = Color.yellow;
                hp1Co.color = new Color(1, 0.509804f, 0.1647059f, 1);
            }
            if (actChar == 2)
            {
                baseColor.color = Color.blue;
                info.speed = 3;
                info.jumpPower = 6;
                hpone = hp;
                hp = hptwo;
                health_bar.SetHealthBar(hp);
                health_two.SetHealthBar(hpthree);
                health_three.SetHealthBar(hpone);
                hp1Co.color = Color.blue;
                hp2Co.color = Color.yellow;
                hp3Co.color = new Color(1, 0.509804f, 0.1647059f, 1);

            }
            if (actChar == 3)
            {
                baseColor.color = Color.yellow;
                info.speed = 7;
                info.jumpPower = 10;
                hptwo = hp;
                hp = hpthree;
                health_bar.SetHealthBar(hp);
                health_two.SetHealthBar(hpone);
                health_three.SetHealthBar(hptwo);
                Gun.SetActive(false);
                hp3Co.color = Color.blue;
                hp1Co.color = Color.yellow;
                hp2Co.color = new Color(1, 0.509804f, 0.1647059f, 1);
            }
        }
        if (Input.GetKeyDown("e"))
        {
            heal(10);
        }
    }

    public void heal(int amt)
    {
        if (actChar == 2)
        {
            hpone += amt;
            hptwo += amt;
            hpthree += amt;
            hp += amt;
            health_bar.SetHealthBar(hp);
            health_two.SetHealthBar(hpthree);
            health_three.SetHealthBar(hpone);
        }
    }

    public void buyHealth()
    {
        if (Shop.Singleton.chBal() >= 1)
        {
            hp += 50;
            Shop.moneyUp(-1);
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

        //Debug.Log(angle);
        if ((info.facingRight && angle < 0) || (!info.facingRight && angle > 0))
        {
            var bullet = Instantiate(BulletPrefab, bulletPos, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletDirection.x, bulletDirection.y) * bullSpeed;
        }
       
    }

    private IEnumerator ShootCooldown()
    {
        canShoot = false; // Set to false to prevent shooting
        if (shotCounter == 6) // Check if it's time to increase cooldown
        {
            reloadingStatus.SetActive(true);
            yield return new WaitForSeconds(reloadDuration);
            reloadingStatus.SetActive(false);
            bulletcounter.ChangeAmmo(6);
            shotCounter = 0;
        }
        else
        {
            yield return new WaitForSeconds(cooldownDuration);
        }

        canShoot = true; // Set back to true, allowing shooting again
        shotCounter++; // Increment the shot counter
    }

    private IEnumerator reload()
    {
        reloadingStatus.SetActive(true);
        canShoot = false; // Set to false to prevent shooting
        yield return new WaitForSeconds(reloadDuration);
        reloadingStatus.SetActive(false);
        bulletcounter.ChangeAmmo(6);
        shotCounter = 0;
        canShoot = true; // Set back to true, allowing shooting again
        shotCounter++; // Increment the shot counter

    }

    public void ResetHP()
    {
        hpone = hp;
        hptwo = hp;
        hpthree = hp;
    }

    public void decHP(int amt)
    {
        hp -= amt;
        health_bar.SetHealthBar(hp);
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (this.gameObject != null)
        {
            DeathScreen.SetActive(true);
        }
    }
}
