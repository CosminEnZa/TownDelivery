using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsTotalDeliveries : MonoBehaviour
{

    [Header("Total Deliveries")]
    public int TotalDeliveriesProgress;
    public TMPro.TextMeshProUGUI TotalDeliveriesProgressText;
    public Button TotalDeliveriesButton;
    public static int TotalDeliveriesValue;
    int iTotalDeliveries = 0;


    void Start()
    {
        TotalDeliveriesValue = PlayerPrefs.GetInt("TotalDeliveries");
        iTotalDeliveries = PlayerPrefs.GetInt("iTotalDeliveries");
        TotalDeliveriesProgress = PlayerPrefs.GetInt("TotalDeliveriesProgress", 10);

        CheckRewardsAtStart();
    }

    public void UpdateAchievement()
    {
        PlayerPrefs.SetInt("TotalDeliveries", TotalDeliveriesValue);

        if (TotalDeliveriesValue >= TotalDeliveriesProgress)
        {
            iTotalDeliveries++;
            PlayerPrefs.SetInt("iTotalDeliveries", iTotalDeliveries);
            TotalDeliveriesButton.gameObject.SetActive(true);
            TotalDeliveriesButton.onClick.AddListener(() => {
                //get reward

                TotalDeliveriesProgress += 10;
                PlayerPrefs.SetInt("TotalDeliveriesProgress", TotalDeliveriesProgress);


                iTotalDeliveries--;
                PlayerPrefs.SetInt("iTotalDeliveries", iTotalDeliveries);
                CheckRewardsAtStart();
            });
        }

        TotalDeliveriesProgressText.text = TotalDeliveriesValue.ToString() + "/" + TotalDeliveriesProgress.ToString();
    }

    void CheckRewardsAtStart()
    {
        if (iTotalDeliveries > 0)
        {
            TotalDeliveriesButton.gameObject.SetActive(true);
            TotalDeliveriesButton.onClick.AddListener(() => {
                //get reward

                TotalDeliveriesProgress += 10;
                PlayerPrefs.SetInt("TotalDeliveriesProgress", TotalDeliveriesProgress);


                iTotalDeliveries--;
                PlayerPrefs.SetInt("iTotalDeliveries", iTotalDeliveries);
                CheckRewardsAtStart();
            });
        }

        TotalDeliveriesProgressText.text = TotalDeliveriesValue.ToString() + "/" + TotalDeliveriesProgress.ToString();
    }


}
