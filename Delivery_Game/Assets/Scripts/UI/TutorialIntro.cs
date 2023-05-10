using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialIntro : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject[] list;


    public CoinsManager coinsman;

    bool tolist8 = false;
    bool tolist7 = false;
    bool hasdonelist4 = false;
    public static bool list4 = false;
    public static bool placeBox = false;
    public static bool endtutorial = false;

    public GameObject[] logos;
    

    // Start is called before the first frame update
    void Start()
    {
       

        if(PlayerPrefs.GetInt("Intro") == 0)
        {
            
            SceneManager.LoadScene("Intro");
        }

        if(PlayerPrefs.GetInt("Tutorial") == 0)
        {
            Tutorial();
        }

      
    }

    private void Update()
    {
        if(list4 == true)
        {
            List4();
        }

        if(hasdonelist4 && CarSwitch.isOn)
        {
            List6();
        }

        if(placeBox && tolist7)
        {
            ShowList7();
        }

        if(tolist8 && endtutorial)
        {
            list[8].SetActive(true);
            tolist8 = false;
        }
    }

    public void ChooseLogo()
    {
        list[8].SetActive(false);
        list[9].SetActive(true);

        CoinsManager.Coins += 1000;
        coinsman.UpdateCoins();
    }

    public void ChooseLogo1()
    {
        PlayerPrefs.SetInt("Logo1", 1);
        logos[0].SetActive(true);

        list[9].SetActive(false);
        list[10].SetActive(true);
    }

    public void ChooseLogo2()
    {
        PlayerPrefs.SetInt("Logo2", 1);
        logos[1].SetActive(true);

        list[9].SetActive(false);
        list[10].SetActive(true);
    }

    public void LastPanel()
    {
        EndTutorialWith8();
        TutorialDone();
    }

    public void ChooseLogo3()
    {
        PlayerPrefs.SetInt("Logo3", 1);
        logos[2].SetActive(true);

        list[9].SetActive(false);
        list[10].SetActive(true);
    }

    void EndTutorialWith8()
    {
        
        PlayerPrefs.SetInt("Tutorial", 1);
    }

    public void TutorialDone()
    {
        Canvas.SetActive(false);
    }

    void Tutorial()
    {
        Time.timeScale = 0; 
        Canvas.SetActive(true);
        list[0].SetActive(true);

    }
    public void EndTutorial()
    {
        PlayerPrefs.SetInt("Tutorial", 1);
    }

    /*public void SkipTutorial()
    {
        Canvas.SetActive(true);
        list[0].SetActive(false);
        
    }*/

    public void FirstNext()
    {
        list[2].SetActive(false);
        Invoke("Next", 5);
    }

     void Next()
    {
        list[3].SetActive(true);
        
    }

    void List4()
    {
        list4 = false;
        list[4].SetActive(true);
        hasdonelist4 = true;
    }

    void List6()
    {
        hasdonelist4 = false;
        Invoke("pickTutorial", 1);
    }

    void pickTutorial()
    {
        list[6].SetActive(true);
    }

    public void ToList7()
    {

        tolist7 = true;
    }

    void ShowList7()
    {
        list[7].SetActive(true);
        tolist7 = false;
    }

    public void ToList8()
    {
        tolist8 = true;
        list[7].SetActive(false);
    }
}
