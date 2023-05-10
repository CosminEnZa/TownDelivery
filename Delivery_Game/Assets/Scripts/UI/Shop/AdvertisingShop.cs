using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvertisingShop : MonoBehaviour
{
    public TMPro.TextMeshProUGUI NewsText;
    public TMPro.TextMeshProUGUI RadioText;
    public TMPro.TextMeshProUGUI TVText;
    public TMPro.TextMeshProUGUI AdsText;

    public CoinsManager coinsman;


    int money;
    int diamonds;
    int adActive;

    public static float newsMulti;
    public static float radioMulti;
    public static float TVMulti;
    public static float AdsMulti;


    GameObject notification;

    public static bool dayStarted = false;

    public GameObject Newpaper;
    public GameObject Radio;
    public GameObject TV;
    public GameObject Ads;

    public Color greenColor;
    public Color redColor;

    void Start()
    {
        newsMulti = 0;
        radioMulti = 0;
        TVMulti = 0;
        AdsMulti = 0;

        
        Invoke("SetValues", 1);
    }

    public void NewsButton()
    {
        if (PlayerPrefs.GetInt("NewsActive") == 1)
        {
            PlayerPrefs.SetInt("NewsActive", 0);
            Newpaper.GetComponent<Image>().color = greenColor;
            NewsText.text = "Activate";
        }
        else if (PlayerPrefs.GetInt("NewsActive") == 0 && CoinsManager.Coins >= 7)
        {
            PlayerPrefs.SetInt("NewsActive", 1);
            Newpaper.GetComponent<Image>().color = redColor;
            NewsText.text = "Disable";
           
        }
    }

    public void RadioButton()
    {
        if (PlayerPrefs.GetInt("RadioActive") == 1)
        {
            PlayerPrefs.SetInt("RadioActive", 0);
            Radio.GetComponent<Image>().color = greenColor;
            RadioText.text = "Activate";
        }
        else if (PlayerPrefs.GetInt("RadioActive") == 0 && CoinsManager.Coins >= 7)
        {
            PlayerPrefs.SetInt("RadioActive", 1);
            Radio.GetComponent<Image>().color = redColor;
            RadioText.text = "Disable";

        }
    }

    public void TVButton()
    {
        if (PlayerPrefs.GetInt("TVActive") == 1)
        {
            PlayerPrefs.SetInt("TVActive", 0);
            TV.GetComponent<Image>().color = greenColor;
            TVText.text = "Activate";
        }
        else if (PlayerPrefs.GetInt("TVActive") == 0 && CoinsManager.Coins >= 7)
        {
            PlayerPrefs.SetInt("TVActive", 1);
            TV.GetComponent<Image>().color = redColor;
            TVText.text = "Disable";

        }
    }

    public void AdsButton()
    {
        if (PlayerPrefs.GetInt("AdsActive") == 1)
        {
            PlayerPrefs.SetInt("AdsActive", 0);
            Ads.GetComponent<Image>().color = greenColor;
            AdsText.text = "Activate";
        }
        else if (PlayerPrefs.GetInt("AdsActive") == 0 && CoinsManager.Coins >= 7)
        {
            PlayerPrefs.SetInt("AdsActive", 1);
            Ads.GetComponent<Image>().color = redColor;
            AdsText.text = "Disable";

        }
    }

    void SetValues()
    {
        if (PlayerPrefs.GetInt("NewsActive") == 0)
        {
            newsMulti = 0;
            Newpaper.GetComponent<Image>().color = greenColor;
            NewsText.text = "Activate";
        }
        else if (PlayerPrefs.GetInt("NewsActive") == 1 && CoinsManager.Coins >= 7)
        {
            newsMulti = 0.05f;
            Newpaper.GetComponent<Image>().color = redColor;
            NewsText.text = "Disable";
            WorkDayOver.expenses += 7;
            CoinsManager.Coins -= 7;
            coinsman.UpdateCoins();
        }
        else
        {
            newsMulti = 0;
            Newpaper.GetComponent<Image>().color = greenColor;
            NewsText.text = "Activate";
        }



        if (PlayerPrefs.GetInt("RadioActive") == 0)
        {
            radioMulti = 0;
            Radio.GetComponent<Image>().color = greenColor;
            RadioText.text = "Activate";
        }
        else if (PlayerPrefs.GetInt("RadioActive") == 1 && CoinsManager.Coins >= 20)
        {
            radioMulti = 0.15f;
            Radio.GetComponent<Image>().color = redColor;
            RadioText.text = "Disable";
            WorkDayOver.expenses += 20;
            CoinsManager.Coins -= 20;
            coinsman.UpdateCoins();
        }
        else
        {
            radioMulti = 0;
            Radio.GetComponent<Image>().color = greenColor;
            RadioText.text = "Activate";
        }



        if (PlayerPrefs.GetInt("TVActive") == 0)
        {
            TVMulti = 0;
            TV.GetComponent<Image>().color = greenColor;
            TVText.text = "Activate";
        }
        else if (PlayerPrefs.GetInt("TVActive") == 1 && CoinsManager.Coins >= 65)
        {
            TVMulti = 0.3f;
            TV.GetComponent<Image>().color = redColor;
            TVText.text = "Disable";
            WorkDayOver.expenses += 45;
            CoinsManager.Coins -= 45;
            coinsman.UpdateCoins();
        }
        else
        {
            TVMulti = 0;
            TV.GetComponent<Image>().color = greenColor;
            TVText.text = "Activate";
        }



        if (PlayerPrefs.GetInt("AdsActive") == 0)
        {
            AdsMulti = 0;
            Ads.GetComponent<Image>().color = greenColor;
            AdsText.text = "Activate";
        }
        else if (PlayerPrefs.GetInt("AdsActive") == 1 && CoinsManager.Coins >= 65)
        {
            AdsMulti = 0.45f;
            Ads.GetComponent<Image>().color = redColor;
            AdsText.text = "Disable";
            WorkDayOver.expenses += 65;
            CoinsManager.Coins -= 65;
            coinsman.UpdateCoins();
        }
        else
        {
            AdsMulti = 0;
            Ads.GetComponent<Image>().color = greenColor;
            AdsText.text = "Activate";
        }
    }




}
