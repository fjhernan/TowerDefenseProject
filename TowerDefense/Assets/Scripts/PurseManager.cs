using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PurseManager : MonoBehaviour
{
    public TextMeshProUGUI purse;
    private int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        purse.text = "Coins: " + coins.ToString("D2");
    }

    // Update is called once per frame
    void Update()
    {
        purse.text = "Coins: " + coins.ToString("D2");
    }

    public void EarnCoins(int earn){
        coins += earn;
    }

    public void Buying(int spent){
        coins -= spent;
    }

    public int GetCoins(){
        int temp = coins;
        return temp;
    }
}
