using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPanel : MonoBehaviour
{

    public TMPro.TextMeshProUGUI liters;
    public TMPro.TextMeshProUGUI totalPrice;
    public TMPro.TextMeshProUGUI fuelPrice;

    int litersN;
    float totalPriceN;
    float fuelPriceN;

    public FuelManager fuelmanager;
    public CoinsManager coinmanager;

    public GameObject FuelPanelgo;


    
    void OnEnable()
    {
        fuelPriceN = Random.Range(1.1f, 1.5f);
        fuelPriceN = Mathf.Round(fuelPriceN * 100f) / 100f;
        
        litersN = (int)fuelmanager.currentFuel;
        totalPriceN = fuelPriceN * litersN;

        liters.text = litersN.ToString();
        totalPrice.text = (int)totalPriceN + "$";
        fuelPrice.text = "                                       " + fuelPriceN.ToString() + "$";

    }

    public void Refill()
    {
        fuelmanager.currentFuel = 0;
        CoinsManager.Coins -= (int)totalPriceN;
        coinmanager.UpdateCoins();

        WorkDayOver.fuel += (int)totalPriceN;

        MissionsManager.FuelValue += 1;
        GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();

        this.gameObject.SetActive(false);

    }

    public void CloseFuelPanel()
    {
        FuelPanelgo.SetActive(false);
    }
}
