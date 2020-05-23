using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    public int CoinValue = 1;
    public int TotalCoins;
    public int CurrentAmountCoins;


    void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<Pirate>()!=null)
        {
            CurrentAmountCoins = TotalCoins++;
            PlayerPrefs.SetInt("Coins", CurrentAmountCoins);
            Destroy(this.gameObject);
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalCoins = PlayerPrefs.GetInt("Coins", 0);
    }

    
}
