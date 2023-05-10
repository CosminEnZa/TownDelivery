using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSwitch : Interactable
{
    
    public GameObject Canvas_First_Person;
    public GameObject Canvas_Inside_Car;
    public GameObject PlayerCapsule;
    public GameObject PlayerCamera;
    public GameObject EnterCarIcon;
    public GameObject ExitCarIcon;
    public GameObject CarCamera;
    public GameObject CarScript;
    public GameObject skip_box;
    public static bool isOn;
    public ParticleSystem exaust;

    public GameObject Car;
    public Transform Position;

    private void Start()
    {
        isOn = false;
        EnterCar();
    }

    private void Update()
    {
        if (isOn == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOn = false;
                EnterCar();
            }
        }
    }

    void EnterCar()
    {
            if (isOn == true && DoorSwitch.isClosed == true )
        {

            //Enter Car
                exaust.Play();
                
                Canvas_Inside_Car.SetActive(true);
                Canvas_First_Person.SetActive(false);
                PlayerCapsule.SetActive(false);
                skip_box.SetActive(false);
                PlayerCamera.SetActive(false);
                EnterCarIcon.SetActive(false);
                CarCamera.SetActive(true);
                ExitCarIcon.SetActive(true);
                CarScript.GetComponent<CarController>().enabled = true;
                Car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            
            
        }

        else if(isOn == false)
        {
            //Exit Car
            exaust.Stop();
            Canvas_Inside_Car.SetActive(false);
            Canvas_First_Person.SetActive(true);
            PlayerCapsule.transform.position = Position.transform.position;
            PlayerCapsule.SetActive(true);
            PlayerCamera.SetActive(true);
            EnterCarIcon.SetActive(true);
            CarCamera.SetActive(false);
            ExitCarIcon.SetActive(false);
            CarScript.GetComponent<CarController>().enabled = false;
            CarController.isBreaking = true;
            Car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
    }

    public override string GetDescription()
    {
        if (SelectionManager.hasBox == true) return "You can't drive while holding a package.";
        if (DoorSwitch.isClosed == false) return "<color=red>Close</color> the packages door to enter.";
            if (isOn) return "";
        return "<color=green>Hold</color> to enter the car.";
    }

    public override void Interact()
    {
        if (DoorSwitch.isClosed == true && SelectionManager.hasBox == false)
        {
            isOn = !isOn;
            EnterCar();
        }
    }
}
