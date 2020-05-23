using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int TotalCoins;
    public TextMeshProUGUI CoinUI;

    // Update is called once per frame
    void Update()
    {
        TotalCoins = PlayerPrefs.GetInt("Coins");
        CoinUI.text = "Coins Collected: " + TotalCoins;
    }
}