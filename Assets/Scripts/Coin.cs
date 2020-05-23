using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    public int CoinValue = 1;
    public int TotalCoins = 0;
    public int CurrentAmountCoins;
    public int ActualCurrentCoins = 0;


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.GetComponent<Pirate>() != null)
        {
            CurrentAmountCoins = TotalCoins+1;
            
            PlayerPrefs.SetInt("TotalCoins", CurrentAmountCoins);
            
            Destroy(this.gameObject);
        }
        ActualCurrentCoins = ActualCurrentCoins + 1;
        PlayerPrefs.SetInt("Coins", ActualCurrentCoins);
    }


    void Start()
    {
        ActualCurrentCoins = 0;
        PlayerPrefs.SetInt("Coins", ActualCurrentCoins);

    }

    // Update is called once per frame
    void Update()
    {
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime *2);
        

    }

    
}
