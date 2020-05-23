﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int TotalCoins;
    public Text CoinUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalCoins = PlayerPrefs.GetInt("Coins");
        CoinUI.text = "Coins Collected: " + TotalCoins;
    }
}
