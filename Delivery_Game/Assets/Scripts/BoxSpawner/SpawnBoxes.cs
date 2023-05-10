using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes : MonoBehaviour
{
    public GameObject cameraCar;
    public GameObject playerCamera;
    public GameObject BoxPanelParent;
    public GameObject[] SpawnList;
    public static int totalObjects = 0;


    private void Start()
    {
        totalObjects = 0;
        SpawnList = new GameObject[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            SpawnList[i] = child.gameObject;
            i++;
        }

        StartCoroutine(SpawnBox());
    }

     
    IEnumerator SpawnBox()
    {
        while (true)
        {
            if (PlayerPrefs.GetInt("Tutorial") == 1)
            {
                if (TimeManager.timeRunning == true)
                {

                    int i = 0;
                    foreach (Transform child in transform)
                    {
                        SpawnList[i].SetActive(false);
                        i++;
                    }
                    if (totalObjects <= 15)
                    {

                        SpawnList[Random.Range(0, SpawnList.Length)].SetActive(true);
                    }
                }

            }
            else             
            {

                int i = 0;
                foreach (Transform child in transform)
                {
                    SpawnList[i].SetActive(false);
                    i++;
                }
                if (totalObjects <= 15)
                {

                    SpawnList[Random.Range(0, SpawnList.Length)].SetActive(true);
                }
            }
            yield return new WaitForSeconds(Random.Range(10, 35));
            
        }
    }
}
