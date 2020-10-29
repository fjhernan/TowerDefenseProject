using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Purse : MonoBehaviour
{
    private TextMeshProUGUI component;
    private const string p = "Purse: ";
    private int coins = 20;
    void Start()
    {
        component = GetComponent<TextMeshProUGUI>();
        component.text = p + coins.ToString("D2");
    }

    public void EarnCoins(int earn)
    {
        coins += earn;
        component.text = p + coins.ToString("D2");
    }

    public void Buying(int spent)
    {
        coins -= spent;
        component.text = p + coins.ToString("D2");
    }

    public int GetCoins()
    {
        int temp = coins;
        return temp;
    }
}
