using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TimeManagerMission : MonoBehaviour
{
    public MissionsManager missionman;
    [SerializeField] double nextRewardDelay = 23f;
    //check if reward is available every 5 seconds
    [SerializeField] float checkForRewardDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("DailyMission_Datetime")))
        {
            PlayerPrefs.SetString("DailyMission_Datetime", DateTime.Now.ToString());
        }

        StopAllCoroutines();
        StartCoroutine(CheckForRewards());
    }

    IEnumerator CheckForRewards()
    {
        while (true)
        {
                DateTime currentDatetime = DateTime.Now;
                DateTime rewardClaimDatetime = DateTime.Parse(PlayerPrefs.GetString("DailyMission_Datetime", currentDatetime.ToString()));

            
                //get total Hours between this 2 dates
                double elapsedHours = (currentDatetime - rewardClaimDatetime).TotalHours;
           
            if (elapsedHours >= nextRewardDelay)
                    ActivateNewMissions();      

            yield return new WaitForSeconds(checkForRewardDelay);
        }
    }

    void ActivateNewMissions()
    {
        Debug.Log("New Missions");
        PlayerPrefs.SetString("DailyMission_Datetime", DateTime.Now.ToString());    

        missionman.ResetValues();
    }
}
