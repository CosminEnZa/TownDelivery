using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectsAtStart : MonoBehaviour
{
    public GameObject menu;
    public GameObject settings;
    public GameObject[] checkList;
    public GameObject[] handsList;

    public GameObject[] logos;

    public GameObject Rank;
    public GameObject Bank;
    public GameObject Shop;

    public GameObject[] disableObjects;

    public GameObject[] indicator_list;
    bool show_hand = false;
    // Start is called before the first frame update
    void Start()
    {
        show_hand = false;
        if(PlayerPrefs.GetInt("Tutorial") != 0)
        {
            this.GetComponent<Tutorial>().enabled = false;
        }
        settings.SetActive(false);
        menu.SetActive(false);

        foreach (GameObject obj in disableObjects)
        {
            obj.SetActive(false);
        }

        if(PlayerPrefs.GetInt("Logo1") == 1)
        {
            logos[0].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Logo2") == 1)
        {
            logos[1].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Logo3") == 1)
        {
            logos[2].SetActive(true);
        }

        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            foreach (GameObject obj in checkList)
            {
                obj.SetActive(false);
            }
        }

        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            foreach (GameObject obj in handsList)
            {
                obj.SetActive(true);
            }
        }

        if (PlayerPrefs.GetInt("Tutorial") == 1 && PlayerPrefs.GetInt("Day") == 2)
        {
            Bank.SetActive(false);
            Shop.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Tutorial") == 1 && PlayerPrefs.GetInt("Day") == 3)
        {
            Bank.SetActive(false);
        }

        StartCoroutine(check_if_start());


        }

    IEnumerator check_if_start()
    {
        while (true)
        { // This creates a never-ending loop

            if (ShopManager.dayStarted == true && show_hand == false)
            {
                if (PlayerPrefs.GetInt("Tutorial") == 1 && PlayerPrefs.GetInt("Day") == 2)
                {
                    Bank.SetActive(false);
                    Shop.SetActive(false);
                    indicator_list[0].SetActive(true);
                    indicator_list[1].SetActive(true);
                    show_hand = true;
                }
                if (PlayerPrefs.GetInt("Tutorial") == 1 && PlayerPrefs.GetInt("Day") == 3)
                {
                    Bank.SetActive(false);
                    indicator_list[2].SetActive(true);
                    indicator_list[3].SetActive(true);
                    show_hand = true;
                }
                if (PlayerPrefs.GetInt("Tutorial") == 1 && PlayerPrefs.GetInt("Day") == 4)
                {
                    indicator_list[4].SetActive(true);
                    indicator_list[5].SetActive(true);
                    show_hand = true;
                }
            }


            yield return new WaitForSeconds(5);
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }
}
