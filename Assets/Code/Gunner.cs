using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

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
    int hpcap;
    public GameObject Gun;
    bool canShoot = true;
    bool canHeal = true;
    bool canShield = true;
    bool canSwitch = true;
    int shotCounter = 1; 
    float cooldownDuration = 0.25f;
    float reloadDuration = 4f;
    public GameObject reloadingStatus;
    Image hp2Co;
    Image hp1Co;
    Image hp3Co;
    public GameObject DeathScreen;
    public LineRenderer shield;
    public Text Heal;
    public Text Shield;
    public Text Reload;
    public bulletcounter counter;
    int maxAmmo;

    // Start is called before the first frame update
    void Start()
    {
        counter = FindAnyObjectByType<bulletcounter>();
        reloadingStatus.SetActive(false);
        hpone = 100 + Shop.Singleton.getHP(); ;
        hptwo = 100 + Shop.Singleton.getHP(); ;
        hpthree = 100 + Shop.Singleton.getHP(); ;
        hp = 100 + Shop.Singleton.getHP();
        actChar = 1;
        baseColor = transform.Find("Square").GetComponent<SpriteRenderer>();
        hp1Co = health_bar.transform.Find("Fill").GetComponent<Image>();
        hp2Co = health_two.transform.Find("Fill").GetComponent<Image>();
        hp3Co = health_three.transform.Find("Fill").GetComponent<Image>();
        DeathScreen.SetActive(false);
        hpcap = hp;
        shield = transform.Find("Line").GetComponent<LineRenderer>();
        shield.enabled = false;
        Heal.enabled = false;
        Shield.enabled = false;
        Reload.enabled = false;
        health_bar.slider.maxValue = hp;
        health_two.slider.maxValue = hp;
        health_three.slider.maxValue = hp;
        maxAmmo = 6 + Shop.Singleton.getAmmo();
    }
     
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Hub")
        {
            Gun.SetActive(false);
        }

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
                counter.ChangeAmmo(6 - shotCounter);
            }
        }
        if (Input.GetKeyDown("1"))
        {
            if (canSwitch == true && hpone > 0)
            {
                switch1();
            }
        }
        if (Input.GetKeyDown("2"))
        {
            if (canSwitch == true && hptwo > 0)
            {
                switch2();
            }
        }
        if (Input.GetKeyDown("3"))
        {
            if (canSwitch == true && hpthree > 0)
            {
                switch3();
            }
        }
        if (Input.GetKeyDown("e"))
        {
            if (actChar == 2 && canHeal == true)
            {
                StartCoroutine(HealCooldown());
                heal(60);
            }
            if (actChar == 3 && canShield == true)
            {
                StartCoroutine(ShieldCooldown());
                shieldUp();
            }
        }
    }

    public void switch1()
    {
        if (actChar != 1)
        {
            if (actChar == 2)
            {
                hptwo = hp;
            }
            else if (actChar == 3)
            {
                hpthree = hp;
            }
            actChar = 1;
            baseColor.color = new Color(1, 0.509804f, 0.1647059f, 1);
            info.speed = 5;
            info.jumpPower = 8;
            hp = hpone;
            health_bar.SetHealthBar(hp);
            health_two.SetHealthBar(hptwo);
            health_three.SetHealthBar(hpthree);
            Gun.SetActive(true);
            hp2Co.color = Color.blue;
            hp3Co.color = Color.yellow;
            hp1Co.color = new Color(1, 0.509804f, 0.1647059f, 1);
        }
    }

    public void switch2()
    {
        if (actChar != 2)
        {
            if (actChar == 1)
            {
                hpone = hp;
            }
            else if (actChar == 3)
            {
                hpthree = hp;
            }
            actChar = 2;
            baseColor.color = Color.blue;
            info.speed = 3;
            info.jumpPower = 8;
            hp = hptwo;
            health_bar.SetHealthBar(hp);
            health_two.SetHealthBar(hpthree);
            health_three.SetHealthBar(hpone);
            Gun.SetActive(true);
            hp1Co.color = Color.blue;
            hp2Co.color = Color.yellow;
            hp3Co.color = new Color(1, 0.509804f, 0.1647059f, 1);
        }
    }

    public void switch3()
    {
        if (actChar != 3){
            if (actChar == 2)
            {
                hptwo = hp;
            }
            else if (actChar == 1)
            {
                hpone = hp;
            }
            actChar = 3;
            baseColor.color = Color.yellow;
            info.speed = 7;
            info.jumpPower = 10;
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
    public void heal(int amt)
    {
            if (hpone > 0)
            {
                hpone += amt;
                if (hpone > hpcap)
                {
                    hpone = hpcap;
                }
                health_three.SetHealthBar(hpone);
            }
            if (hpthree > 0)
            {
                hpthree += amt;
                if (hpthree > hpcap)
                {
                    hpthree = hpcap;
                }
                health_two.SetHealthBar(hpthree);
            }
            hptwo += amt;
            if (hptwo > hpcap)
            {
                hptwo = hpcap;
            }
            hp += amt;
            if (hp > hpcap)
            {
                hp = hpcap;
            }
            health_bar.SetHealthBar(hp);
    }

    public void shieldUp()
    {
            shield.enabled = true;
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
        if (SceneManager.GetActiveScene().name != "Hub")
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
                AudioManager.Instance.PlaySFX("Shot");
                var bullet = Instantiate(BulletPrefab, bulletPos, Quaternion.identity);

                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletDirection.x, bulletDirection.y) * bullSpeed;
            }
        }
    }

    private IEnumerator HealCooldown()
    {
        canHeal = false;
        Heal.text = "15";
        Heal.enabled = true;
        for (int i = 15; i > 0; i--)
        {
            Heal.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        Heal.text = "Heal\nReady!";
        canHeal = true;
        yield return new WaitForSeconds(2);
        Heal.enabled = false;
    }

    private IEnumerator ShieldCooldown()
    {
        canShield = false;
        Shield.text = "10";
        Shield.enabled = true;
        for (int i = 10; i > 0; i--)
        {
            Shield.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        Shield.text = "Shield\nReady!";
        canShield = true;
        yield return new WaitForSeconds(2);
        Shield.enabled = false;
    }

    private IEnumerator RloadCooldown()
    {
        Reload.text = "4";
        Reload.enabled = true;
        for (int i = 4; i > 0; i--)
        {
            Reload.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        Reload.enabled = false;
    }

    private IEnumerator ShootCooldown()
    {
        canShoot = false; // Set to false to prevent shooting
        if (shotCounter == maxAmmo) // Check if it's time to increase cooldown
        {
            reloadingStatus.SetActive(true);
            StartCoroutine(RloadCooldown());
            yield return new WaitForSeconds(reloadDuration);
            AudioManager.Instance.PlaySFX("Reload");
            reloadingStatus.SetActive(false);
            counter.ChangeAmmo(6 + Shop.Singleton.getAmmo());
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
        StartCoroutine(RloadCooldown());
        yield return new WaitForSeconds(reloadDuration);
        AudioManager.Instance.PlaySFX("Reload");
        reloadingStatus.SetActive(false);
        counter.ChangeAmmo(maxAmmo);
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
        if (shield.enabled == true)
        {
            shield.enabled = false;
        }
        else{
            hp -= amt;
            health_bar.SetHealthBar(hp);
            if (hp <= 0)
            {
                if ((hpone <= 0 && hptwo <= 0) || (hpone <= 0 && hpthree <= 0) || (hpthree <= 0 && hptwo <= 0))
                {
                    Destroy(this.gameObject);
                }
                else if (actChar == 1)
                {
                    if (hptwo > 0)
                    {
                        switch2();
                    }
                    else if (hpthree > 0)
                    {
                        switch3();
                    }
                }
                else if (actChar == 2)
                {
                    if (hpthree > 0)
                    {
                        switch3();
                    }
                    else if (hpone > 0)
                    {
                        switch1();
                    }
                }
                else if (actChar == 3)
                {
                    if (hpone > 0)
                    {
                        switch1();
                    }
                    else if (hptwo > 0)
                    {
                        switch2();
                    }
                }
            }
        }
    }

    private void OnDestroy()
    {
        if (DeathScreen != null)
        {
            DeathScreen.SetActive(true);
        }
    }
}
