using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int TotalCoins;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalCoins = PlayerPrefs.GetInt("Coins");
        Debug.Log(TotalCoins);
    }
}
