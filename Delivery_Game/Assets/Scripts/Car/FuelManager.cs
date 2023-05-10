using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
   public float currentFuel = 0f;
    public float baseInterval = 1;
    float countDown;

    public GameObject fuelPart;

    public RectTransform Bar;


    public UnityEvent NotificationFuel;
    public GameObject fuelWaypoint; 

    public GameObject TowPanel;

    public static bool EngineStart = false;

    // Start is called before the first frame update
    void Start()
    {
        currentFuel = PlayerPrefs.GetFloat("Fuel");
        fuelPart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       

        if(currentFuel >= 140 && currentFuel <= 141)
        {
            fuelWaypoint.SetActive(true);
            NotificationFuel.Invoke();
        }
        else if(currentFuel == 0)
        {
            fuelWaypoint.SetActive(false);
        }

        if(currentFuel >= 180 && Mathf.Abs(CarController.speed) <= 1)
        {
            TowPanel.SetActive(true);
            CarController.noFuel = true;
        }
        else
        {
            TowPanel.SetActive(false);
        }

            if (CarController.isMoving && CarSwitch.isOn)
            {
                if (currentFuel < 180)
                {
                    currentFuel += Time.deltaTime / 3;
                    Bar.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, currentFuel + 90));
                    PlayerPrefs.SetFloat("Fuel", currentFuel);
                }
            }       
        
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fuel"))
        {
            fuelWaypoint.SetActive(false);
            fuelPart.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fuel"))
        {

            fuelPart.SetActive(false);
        }
    }
}
