using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetShop : MonoBehaviour
{
    public TMPro.TextMeshProUGUI BuySelect;
    public TMPro.TextMeshProUGUI PriceText;

    public CoinsManager coinsman;
    public DiamondManager diamondman;

    [SerializeField]
    private int ID = 1;

    [SerializeField]
    private int price;

    int money;
    int diamonds;
    int objectBuy;

    public GameObject[] list;

    [SerializeField]
    private GameObject car;

    GameObject notification;

    public static bool dayStarted = false;

    public bool BoughtWithDiamonds;

    void Start()
    {
        money = PlayerPrefs.GetInt("Coins");
        diamonds = PlayerPrefs.GetInt("Diamonds");
        objectBuy = PlayerPrefs.GetInt("PetBought" + ID);
        //PriceText.text = price.ToString() + "$";

        if (!PlayerPrefs.HasKey("SelectedPet"))
        {
            PlayerPrefs.SetInt("SelectedPet", 1);
        }

        if (objectBuy == 1)
        {
            BuySelect.text = "Select";
        }
        else if (objectBuy == 0)
        {
            BuySelect.text = "Buy";
        }
    }

    public void BuyOrSelect()
    {


            if (objectBuy == 1) //select
            {
                for (int i = 0; i < 4; i++)
                {
                    list[i].SetActive(false);
                }

                car.SetActive(true);
            PlayerPrefs.SetInt("SelectedPet", ID);
            }

        if (objectBuy == 0) //buy
        {
            if (BoughtWithDiamonds == false)
            {
                if (money >= price)
                {
                    CoinsManager.Coins -= price;
                    PlayerPrefs.SetInt("PetBought" + ID, 1);
                    objectBuy = 1;
                    BuySelect.text = "Select";
                    coinsman.UpdateCoins();
                }
            }
            else if (BoughtWithDiamonds)
            {
                if (diamonds >= price)
                {
                    DiamondManager.Diamonds -= price;
                    PlayerPrefs.SetInt("PetBought" + ID, 1);
                    objectBuy = 1;
                    BuySelect.text = "Select";
                    diamondman.UpdateDiamonds();
                }
            }
        }
    }


}
