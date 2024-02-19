using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bulletcounter : MonoBehaviour
{
    private static float ammo = 6;
    private static Text ammoText;

    // Use this for initialization
    internal void Start()
    {
        ammoText = GetComponent<Text>();
        UpdateText();

    }

    public static void ChangeAmmo(float amt)
    {
        ammo = amt;

        UpdateText();
    }

    private static void UpdateText()
    {
        ammoText.text = ammo.ToString();
    }
}