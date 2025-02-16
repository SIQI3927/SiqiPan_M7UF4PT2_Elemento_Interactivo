using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    public ItemScriptableObject Item1, Item2;
    public Image Image1, Image2;
    public TextMeshProUGUI TextItem1, TextItem2;
    public Button Buy1, Buy2;

    void OnEnble()
    {
        Image1.sprite = Item1.image;
        Image2.sprite = Item2.image;
        checkIfCanBuy(Item1, TextItem1, Buy1);
        checkIfCanBuy(Item2, TextItem2, Buy2);
    }

    public void BuyItem1()
    {
        GameManager.gameManager.ItemCollected(Item1.image, 6);
        GameManager.gameManager.CoinCollected(-Item1.price);
        checkIfCanBuy(Item1, TextItem1, Buy1);
        checkIfCanBuy(Item2, TextItem2, Buy2);
    }


    public void BuyItem2()
    {
        GameManager.gameManager.ItemCollected(Item2.image, 7);
        GameManager.gameManager.CoinCollected(-Item2.price);
        checkIfCanBuy(Item2, TextItem1, Buy1);
        checkIfCanBuy(Item2, TextItem2, Buy2);
    }

    private void checkIfCanBuy(ItemScriptableObject item, TextMeshProUGUI insuCoins, Button buyButton)
    {
        if(GameManager.gameManager.Coins >= item.price)
        {
            insuCoins.text = "" + item.price;
            insuCoins.color = Color.yellow;
            buyButton.interactable = true;
        }
        else
        {
            insuCoins.text = "insuficiente coins: " + item.price;
            insuCoins.color = Color.red;
            buyButton.interactable = false;
        }
    }
}

