using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
 
    public SOInt coins;
    public TextMeshProUGUI UITextCoins;

   
    private void Start()
    {
        Reset();        
    }

    private void Reset()
    {
        coins.Value = 0;
       
    }

    public void AddCoins(int amount=1)
    {
        coins.Value+= amount;
       
    }

    private void UpdateUI()
    {
       //UITextCoins.text = coins.ToString();
       //UIInGameManager.UpdateTextCoins(coins.Value.ToString());
    }
}
