using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Gunner>() != null)
        {
            AudioManager.Instance.PlaySFX("Coin");
            Shop.moneyUp(1);
            CoinCounter.AddToScore(1);
            Destroy(this.gameObject);
        }
    }
}
