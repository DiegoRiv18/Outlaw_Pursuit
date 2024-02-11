using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Button bullet;
    public Button upWeap;
    private int balance;
    public static Shop Singleton;

    // Start is called before the first frame update
    void Start()
    {
        Singleton = this;
        balance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            notOn();
        }
    }

    private void incBal(int amount)
    {
        balance += amount;
    }

    public static void moneyUp(int amt)
    {
        Singleton.incBal(amt);
    }


    private void notOn()
    {
        if (this.gameObject.GetComponent<Canvas>().enabled == false)
        {
            this.gameObject.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<Canvas>().enabled = false;
        }
    }
}
