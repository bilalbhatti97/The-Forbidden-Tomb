using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiCoinAmount : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerCoins = 0;
    public GameObject coin_ui_txt;

    // Update is called once per frame


    private void Start()
    {
        if(PlayerPrefs.HasKey("coins"))
        {
            CoinPickUp(PlayerPrefs.GetInt("coins"));
        }

    }


    public void CoinPickUp(int amount)
    {
        playerCoins +=amount;
        coin_ui_txt.GetComponent<TMP_Text>().text = playerCoins.ToString();
    }
}
