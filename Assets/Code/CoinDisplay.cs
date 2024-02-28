using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    public Text coinText;
    public int maxFontSize = 190; // Set your maximum font size here
    public int minFontSize = 100; // Set your minimum font size here

    private void Update()
    {
        int coinCount = Shop.Singleton.balance;

        // Adjust font size based on the number of coins
        int fontSize = maxFontSize - coinCount.ToString().Length * 20;

        // Update the font size of the Text component
        coinText.fontSize = fontSize;

        // Update the displayed text
        coinText.text = coinCount.ToString();
    }
}