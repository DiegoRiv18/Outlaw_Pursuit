using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public GameObject shopCanvas;
    public Button bullet;
    public Button upWeap;
    public int balance;
    public int addDmg;
    public int addHP;
    public static Shop Singleton;
    public bool andydeath = false;
    public bool harrydeath = false;
    public bool barondeath = false;
    public int addbull;
    bool capInc;

    // Start is called before the first frame update
    void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(gameObject); // Ensures only one instance exists
            return;
        }

        Singleton = this;
        DontDestroyOnLoad(this.gameObject);
        balance = 0;
        addDmg = 0;
        addHP = 0;
        addbull = 0;
        capInc = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Hub")
        {
            if (Input.GetKeyDown("f"))
            {
                notOn();
            }
        }
    }
    

    public void updmg()
    {
        if (balance >= 20)
        {
            AudioManager.Instance.PlaySFX("ChaChing");
            addDmg += 20;
            balance -= 20;
            CoinCounter.AddToScore(-20);
        }
    }

    public void upHP()
    {
        if (balance >= 20)
        {
            AudioManager.Instance.PlaySFX("ChaChing");
            addHP += 50;
            balance -= 20;
            CoinCounter.AddToScore(-20);
        }
    }

    public void upAmmo()
    {
        if (!capInc && balance >= 20)
        {
            AudioManager.Instance.PlaySFX("ChaChing");
            addbull += 2;
            balance -= 20;
            CoinCounter.AddToScore(-20);
        }
        capInc = true;
    }
    public int getDmg()
    {
        return addDmg;
    }

    public int getHP()
    {
        return addHP;
    }

    public int getAmmo()
    {
        return addbull;
    }

    private void incBal(int amount)
    {
        balance += amount;
    }
    public static void moneyUp(int amt)
    {
        Singleton.incBal(amt);
    }

    private int checkBal()
    {
        return balance;
    }

    public int chBal()
    {
        return Singleton.checkBal();
    }
    
    //toggle buttons on/off
    private void notOn()
    {
        if (shopCanvas.activeSelf == false)
        {
            shopCanvas.SetActive(true);
        }
        else
        {
            shopCanvas.SetActive(false);
        }
    }
}
