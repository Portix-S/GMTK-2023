using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // This script handles player money, as well as the winning money/payment system

    public int money = 100;

    [SerializeField] TextMeshProUGUI playerMoney;
    [SerializeField] TextMeshProUGUI playerMoneyUI;

    public bool Pay(int amount) // Tries to buy something
    {
        if (money - amount >= 0)
        {
            money -= amount;
            playerMoney.text = ""+money;
            playerMoneyUI.text = ""+money;
            return true;
        }
        else
            return false;
    }
}
