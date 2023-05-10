using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TimeManager : MonoBehaviour
{
    string ampm;
    public float guiTime;
    public TMPro.TextMeshProUGUI generalTime_text;
    public TMPro.TextMeshProUGUI TabletTime_text;

    public Material nightSky;
    public Light directionalLight;
    public Material nightLights;
    public MeshRenderer[] trafficLight;

    public Color darkBlueColor;

    public GameObject panel;
    public static bool timeRunning = true;

    public UnityEvent dayFinishedEvent;

    public GameObject imageObject;
    public Vector3 rotationVector;

    // Start is called before the first frame update
    void Start()
    {
        timeRunning = true;
        panel.SetActive(false);
        guiTime = 630;
        StartCoroutine(StartTimer());
        StartCoroutine(rotationRoutine());
        ShopManager.dayStarted = false;

        WorkDayOver.deliveries = 0;
        WorkDayOver.tow = 0;
        WorkDayOver.fuel = 0;
        WorkDayOver.tips = 0;
        WorkDayOver.expenses = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator StartTimer()
    {
        while (timeRunning)
        {
            HandleClock();
            guiTime += 30;

            yield return new WaitForSeconds(15);
        }

    }

    void HandleClock()
    {
       // guiTime = Time.time; //set guiTime
       float second = Mathf.Round(Mathf.Repeat(guiTime, 60));  //use Mathf.Repeat to make the seconds reset to 0 when they get to 60
       float minute = Mathf.Floor(Mathf.Repeat(guiTime / 60, 60));  //one minute = 60 seconds - once again, reset minutes to 0 when they get to 60
        //this one's trickier - one hour = (60 * 60 seconds), and hours need to reset to 0 when they hit twelve

        if(guiTime == 1140)
        {
            RenderSettings.skybox = nightSky;
            directionalLight.color = darkBlueColor;
            foreach (MeshRenderer meshrend in trafficLight)
            {
                meshrend.material = nightLights;
            }
            
        }

        if(guiTime == 1260)
        {
            if (PlayerPrefs.GetInt("Tutorial") == 1)
            {
                dayFinishedEvent.Invoke();
            }
            timeRunning = false;
        }

        if (guiTime < 720)
        {  //13 hours = 47000 seconds. guiTime / 47000 is even, then we need AM, otherwise, PM
            ampm = "AM";
        }
        else
        {
            ampm = "PM";
        }

        generalTime_text.text = string.Format("{0:00}:{1:00}{2}", minute, second, ampm);  //final clock string
        TabletTime_text.text = generalTime_text.text;
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    IEnumerator rotationRoutine()
    {    
        var total_x_rot = 0.0f;

        while (timeRunning == true)
        {
            // prevent from over-rotating
            var x_rot = Mathf.Min(360.0f - total_x_rot, rotationVector.x);

            imageObject.transform.Rotate(new Vector3(0.0f, 0.0f, x_rot));
            total_x_rot -= x_rot;

         
                yield return new WaitForSeconds(1.7f);
            
        }
    }


}
