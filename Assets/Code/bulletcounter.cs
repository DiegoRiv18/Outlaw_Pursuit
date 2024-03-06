using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bulletcounter : MonoBehaviour
{
    private float ammo = 6;
    private static Text ammoText;

    // Use this for initialization
    internal void Start()
    {
        ammoText = GetComponent<Text>();
        UpdateText();

    }

    public void ChangeAmmo(float amt)
    {
        ammo = amt + Shop.Singleton.getAmmo();

        UpdateText();
    }

    private void UpdateText()
    {
        ammoText.text = ammo.ToString();
    }
}