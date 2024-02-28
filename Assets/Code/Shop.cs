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
    public static Shop Singleton;

    // Start is called before the first frame update
    void Start()
    {
        //shopCanvas.SetActive(false);
        Singleton = this;
        balance = 0;
        addDmg = 0;
        DontDestroyOnLoad(this.gameObject);
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
        if (balance >= 10)
        {
            addDmg += 20;
            balance -= 10;
            CoinCounter.AddToScore(-10);
        }
    }

    public int getDmg()
    {
        return addDmg;
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
