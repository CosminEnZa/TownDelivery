using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpBoxChild : MonoBehaviour
{
    public GameObject[] SpawnList;

    void OnAwake()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            SpawnList[i].SetActive(false);
            i++;
        }
    }
    private void Start()
    {
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
            int i = 0;
            foreach (Transform child in transform)
            {
                SpawnList[i].SetActive(false);
                i++;
            }
            SpawnList[Random.Range(0, SpawnList.Length)].SetActive(true);

            yield return new WaitForSeconds(Random.Range(10, 20));
        }
    }
}
