using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationShop : MonoBehaviour
{
    public TMPro.TextMeshProUGUI BuySelect;
    public TMPro.TextMeshProUGUI PriceText;

    public CoinsManager coinsman;
    public DiamondManager diamondman;

    [SerializeField]
    private int ID;

    [SerializeField]
    private int price;

    int money;
    int diamonds;
    int objectBuy;

    [SerializeField]
    private GameObject decoration;

    GameObject notification;

    public bool BoughtWithDiamonds;

    void Start()
    {
        money = PlayerPrefs.GetInt("Coins");
        diamonds = PlayerPrefs.GetInt("Diamonds");
        objectBuy = PlayerPrefs.GetInt("DecorationBought" + ID);

        if (!BoughtWithDiamonds)
        {
            PriceText.text = price.ToString() + "$";
        }
        else
        {
            PriceText.text = price.ToString();
        }

        if (objectBuy == 1)
        {
            BuySelect.text = "Bought";
        }
        else if (objectBuy == 0)
        {
            BuySelect.text = "Buy";
        }

    }

    public void BuyOrSelect()
    {

        if (objectBuy == 0) //buy
        {
            if (BoughtWithDiamonds == false)
            {
                if (money >= price)
                {
                    CoinsManager.Coins -= price;
                    PlayerPrefs.SetInt("DecorationBought" + ID, 1);
                    objectBuy = 1;
                    BuySelect.text = "Bought";
                    coinsman.UpdateCoins();
                    decoration.SetActive(true);
                }
            }
            else if (BoughtWithDiamonds)
            {
                if (diamonds >= price)
                {
                    DiamondManager.Diamonds -= price;
                    PlayerPrefs.SetInt("DecorationBought" + ID, 1);
                    objectBuy = 1;
                    BuySelect.text = "Bought";
                    diamondman.UpdateDiamonds();
                    decoration.SetActive(true);
                }
            }
        }
    }


}
