using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GraphManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI StockMoneyText;
    public TMPro.TextMeshProUGUI addMoneyText;
    public TMPro.TextMeshProUGUI profitText;
    public TMPro.TextMeshProUGUI dayValueText;
    public TMPro.TextMeshProUGUI confirmText;

    float profit;
    public CoinsManager coinsman;
    int addingMoney = 100;
    float StoredMoney;
    int days = 0;
    public TMPro.TextMeshProUGUI[] dayText;

    public Window_Graph graph;

    float ValueNumber = 50;

    int lenght = 0;
    bool canRetire = false;
    float MoneyToRetire = 0;

    public UnityEvent WaitRetirement;

    void Start()
    {
        addingMoney = 100;
        addMoneyText.text = addingMoney.ToString() + "$";
        StoredMoney = PlayerPrefs.GetFloat("StoredMoney");
        StockMoneyText.text = "in stocks: " + StoredMoney.ToString() + "$";
        
        
        if (PlayerPrefs.GetInt("Day") < 10)
        {
            for (int i = 1; i <= dayText.Length; i++)
            {
                days = i;
                dayText[i - 1].text = days.ToString();

            }
        }
        else
        {
            for (int i = 1; i <= dayText.Length; i++)
            {
                days = i + PlayerPrefs.GetInt("Day") - 10;
                dayText[i - 1].text = days.ToString();

            }
        }

     
    }

    public void AddMoney()
    {
        if (PlayerPrefs.GetInt("Coins") >= addingMoney)
        {
            addingMoney += 100;
           
            addMoneyText.text = addingMoney.ToString() + "$";
        }

        
    }

    public void DecreaseMoney()
    {
        if(addingMoney > 100)
        {
            addingMoney -= 100;

            addMoneyText.text = addingMoney.ToString() + "$";
        }
    }

    public void PutMoney()
    {
        canRetire = false;
        CoinsManager.Coins -= addingMoney;
        coinsman.UpdateCoins();

        MissionsManager.InvestValue += addingMoney;
        GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();

        StoredMoney += addingMoney;
        PlayerPrefs.SetFloat("StoredMoney", StoredMoney);

        addingMoney = 100;
        addMoneyText.text = addingMoney.ToString() + "$";
        StockMoneyText.text = "in stocks: " + StoredMoney.ToString() + "$";
        profitText.text = "Profit" + "\n" + (StoredMoney * ((ValueNumber - 50) / 100)).ToString() + "$";
        MoneyToRetire = StoredMoney + (StoredMoney * ((ValueNumber - 50) / 100));
        confirmText.text = "Would you like to retire " + MoneyToRetire + "$?";
    }

    public void ModifyList()
    {
        canRetire = true;
        ValueNumber = PlayerPrefs.GetFloat("valueNumber", 50);
        
        lenght = PlayerPrefs.GetInt("lenght");

        for (int i = 0; i < lenght; i++)
        {

            graph.valueList.Add(PlayerPrefs.GetFloat("myList_" + i));
            
        }

        float ran = Random.value;
        if (ran > 0.7)
        {
            if (ValueNumber > 10)
            {
                ValueNumber -= 10;
            }
            else
            {
                ValueNumber += 10;
            }
        }
        else
        {
            if (ValueNumber < 90)
            {
                ValueNumber += 10;
            }
            else
            {
                ValueNumber -= 10;
            }
        }

        profit = StoredMoney * ((ValueNumber - 50) / 100);
        dayValueText.text = "Today's value" + "\n" + (ValueNumber - 50) + "%";
        profitText.text = "Profit" + "\n" + profit + "$";

        if (graph.valueList.Count < 10)
        {
            graph.valueList.Add(ValueNumber);
            lenght++;
            PlayerPrefs.SetInt("lenght", lenght);
        }
        else if (graph.valueList.Count == 10)
        {
            for (int i = 0; i < graph.valueList.Count-1; i++)
            {
                graph.valueList[i] = PlayerPrefs.GetFloat("myList_" + (i+1));
            }
            graph.valueList[9] = ValueNumber;
       
        }
        for (int i = 0; i < graph.valueList.Count; i++)
        {
            PlayerPrefs.SetFloat("myList_" + i, graph.valueList[i]);
        }
        PlayerPrefs.SetFloat("valueNumber", ValueNumber);

        MoneyToRetire = StoredMoney + (StoredMoney * ((ValueNumber - 50) / 100));
        confirmText.text = "Would you like to retire " + MoneyToRetire + "$?";
    }

    public void RetireMoney()
    {
        if(canRetire == true)
        {
            MoneyToRetire = StoredMoney + (StoredMoney * ((ValueNumber - 50) / 100));
            StoredMoney = 0;
            PlayerPrefs.SetFloat("StoredMoney", StoredMoney);
            StockMoneyText.text = "in stocks: " + StoredMoney.ToString() + "$";
            confirmText.text = "Would you like to retire " + MoneyToRetire + "$?";

            CoinsManager.Coins += (int)MoneyToRetire;
            coinsman.UpdateCoins();

            canRetire = false;
        }

        else
        {
            WaitRetirement.Invoke();
        }
    }
}
