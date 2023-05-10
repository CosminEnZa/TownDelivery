using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSwitch : Interactable
{
    public FuelManager fuelmanager;
    public GameObject FuelPanel;
    void PutFuel()
    {
        FuelPanel.SetActive(true);
    }

    public override string GetDescription()
    {
        if (fuelmanager.currentFuel > 0) return "<color=green>Hold </color> to refill the car's tank";
        if (fuelmanager.currentFuel == 0) return "The car's tank is full";
       
        return "<color=green>Hold</color> to enter the car.";
    }

    public override void Interact()
    {
        if (fuelmanager.currentFuel > 0)
        {
            
            PutFuel();
        }
    }


}
