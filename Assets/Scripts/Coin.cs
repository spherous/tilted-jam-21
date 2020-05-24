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
    public GameManager manager;
    public Pirate player;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.GetComponent<Pirate>() != null)
        {
            TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
            CurrentAmountCoins = TotalCoins+1;
            player = FindObjectOfType<Pirate>();
            player.PlayCoinSound();
            PlayerPrefs.SetInt("TotalCoins", CurrentAmountCoins);
            manager = FindObjectOfType<GameManager>();
            manager.IncreaseCurrentCoins();
           
            Destroy(this.gameObject);
        }
      
        
    }


    void Start()
    {
        ActualCurrentCoins = 0;
        PlayerPrefs.SetInt("Coins", ActualCurrentCoins);
        

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime *2);
       
        


    }

    
}
