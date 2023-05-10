using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkDayOver : MonoBehaviour
{

    public static int deliveries;
    public static int tips;
    public static int fuel;
    public static int tow;
    public static int expenses;

    int total;

    public TMPro.TextMeshProUGUI deliveriesText;
    public TMPro.TextMeshProUGUI tipsText;
    public TMPro.TextMeshProUGUI fuelText;
    public TMPro.TextMeshProUGUI towText;
    public TMPro.TextMeshProUGUI expensesText;
    public TMPro.TextMeshProUGUI totalText;

    
    public GameObject openScreen;

    public AudioSource car_audio;

    private void Start()
    {
        
        tips = 0;
        fuel = 0;
        tow = 0;
        expenses = 0;
    }

    void OnEnable()
    {
        car_audio.Pause();
        Time.timeScale = 0;
        total = deliveries + tips - fuel - tow - expenses;
        ShopManager.dayStarted = false;
        deliveriesText.text = deliveries.ToString();
        tipsText.text = tips.ToString();
        fuelText.text = fuel.ToString();
        towText.text = tow.ToString();
        expensesText.text = expenses.ToString();
        totalText.text = total.ToString();
    }

    public void newDay()
    {
        
        StartDay.dayNumber++;
        PlayerPrefs.SetInt("Day", StartDay.dayNumber);
        PlayerPrefs.SetInt("RankDay", PlayerPrefs.GetInt("Day"));
        openScreen.SetActive(true);
        SceneManager.LoadSceneAsync("SampleScene");
    }
    
}
