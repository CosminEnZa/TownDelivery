using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI BuySelect;
    public TMPro.TextMeshProUGUI PriceText;

    public CarController carctrl;
    public CoinsManager coinsman;

    [SerializeField]
    private int ID = 1;

    [SerializeField]
    private int price;

    int money;
    int objectBuy;

    public GameObject[] list;
    public UnityEvent Notification;

    [SerializeField]
    private GameObject car;

    GameObject notification;

    public static bool dayStarted = false;

    void Start()
    {
        money = PlayerPrefs.GetInt("Coins");
        objectBuy = PlayerPrefs.GetInt("Bought" + ID);
        PriceText.text = price.ToString() + "$";

        if(!PlayerPrefs.HasKey("SelectedCar"))
        {
            PlayerPrefs.SetInt("SelectedCar", 1);
        }

        if (objectBuy == 1 || ID == 1)
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

        if (dayStarted == false)
        {
            if (ID == 1)
        {
            for (int i = 0; i < list.Length; i++)
            {
                list[i].SetActive(false);
            }

            car.SetActive(true);
            carctrl.ReseachComponents();
        }
        
            if (objectBuy == 1) //select
            {
                for (int i = 0; i < 10; i++)
                {
                    list[i].SetActive(false);
                }

                car.SetActive(true);
                carctrl.ReseachComponents();
                PlayerPrefs.SetInt("SelectedCar", ID);
            }
        }
        else if (dayStarted == true)
        {
            Notification.Invoke();
            PlayerPrefs.SetInt("SelectedCar", ID);
        }

        if (objectBuy == 0) //buy
        {
            if (money >= price)
            {
                CoinsManager.Coins -= price;
                PlayerPrefs.SetInt("Bought" + ID, 1);
                objectBuy = 1;
                BuySelect.text = "Select";
                coinsman.UpdateCoins();
            }
        }
    }


}
