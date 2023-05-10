using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsAtStart : MonoBehaviour
{
    public GameObject[] Cars;
    public GameObject[] Pets;

    public GameObject[] Decorations;

    public CarController carctrl;

    private void Start()
    {
        
        foreach(GameObject obj in Cars)
        {
            obj.SetActive(false);
        }

        Cars[PlayerPrefs.GetInt("SelectedCar") - 1].SetActive(true);

        foreach (GameObject obj in Pets)
        {
            obj.SetActive(false);
        }

        Pets[PlayerPrefs.GetInt("SelectedPet") - 1].SetActive(true);
       

        carctrl.ReseachComponents();

        for( int i = 1; i <= 21; i++)
        {
            if(PlayerPrefs.GetInt("DecorationBought" + i) == 1)
            {
                Decorations[i-1].SetActive(true);
            }
        }
    }
    
       

    
}
