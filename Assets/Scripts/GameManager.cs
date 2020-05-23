using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int TotalCoins;
    public int Coins;
    public TextMeshProUGUI TotalCoinUI;
    public TextMeshProUGUI CoinUI;

    // Update is called once per frame
    void Update()
    {
        TotalCoins = PlayerPrefs.GetInt("TotalCoins");
        
        TotalCoinUI.text = "Total Coins Collected: " + TotalCoins;
        CoinUI.text = "Coins Collected: " + Coins;
    }
    public void IncreaseCurrentCoins()
    {
        Coins++;
    }
}