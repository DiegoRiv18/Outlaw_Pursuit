using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Money : MonoBehaviour
{

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Gunner>() != null)
        { 
            Shop.moneyUp(1);
            CoinCounter.AddToScore(1);
            Destroy(this.gameObject);
        }
    }
}
