using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDay : MonoBehaviour
{
    public GameObject[] TipList;

    public static int dayNumber = 1;

    public TMPro.TextMeshProUGUI dayText;
    public GameObject openScreen;
    public GameObject rewardText;

    int rank_day;

    public GameObject Tutorialwindow;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        for (int i = 0; i < TipList.Length; i++)
        {
            TipList[i].SetActive(false);
        }

        TipList[Random.Range(0, TipList.Length)].SetActive(true);
        dayNumber = PlayerPrefs.GetInt("Day", 1);
        rank_day = PlayerPrefs.GetInt("RankDay", 1);
       
        dayText.text = "Day " + dayNumber;
       
        Invoke("AddRankDay", 3);
    }

    void AddRankDay()
    {
        rank_day++;
        PlayerPrefs.SetInt("RankDay", rank_day);
    }

    public void StartaNewDay()
    {
        Time.timeScale = 1;
        openScreen.SetActive(false);
        rewardText.SetActive(false);
        ShopManager.dayStarted = true;
        this.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            Tutorialwindow.SetActive(true);
        }

    }
}
