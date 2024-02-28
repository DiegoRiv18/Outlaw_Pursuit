using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CoinCounter : MonoBehaviour
{
    //private static float score = 0;
    private static Text scoreText;

    // Use this for initialization
    internal void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateText();

    }

    public static void AddToScore(float points)
    {
        //score += points;

        UpdateText();
    }

    private static void UpdateText()
    {
        scoreText.text = Shop.Singleton.balance.ToString();
    }
}
