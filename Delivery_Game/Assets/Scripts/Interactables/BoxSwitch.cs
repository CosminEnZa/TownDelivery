using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSwitch : Interactable
{
    private bool isPicked;
    public static bool hasBox;
    private bool noMove = true; 

    
    public GameObject playerBoxTransform;
    public GameObject DropBoxTransform;
  

    private Transform _selection;
    
    

    private void Start()
    {
        
        playerBoxTransform = GameObject.Find("BoxTransformPosition");
        DropBoxTransform = GameObject.Find("BoxTransformCar");

    }

    private void FixedUpdate()
    {

        if(!isPicked)
        {
           
            //this.transform.position = SelectionManager.placeFin.transform.position;
            
            
        }




        

        if(isPicked)
        {

            //this.transform.position = playerBoxTransform.transform.position;
        }


        


    }

    void PickBox()
    {
        
            if (isPicked)
            {
               noMove = false;
                GetComponent<BoxCollider>().isTrigger = true;
                hasBox = true;
                GetComponent<Rigidbody>().useGravity = false;
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                Debug.Log("PickBox");
            }
            
        if (!isPicked)
        {
            Debug.Log("PickBox");
        }
        
            
        

        
    }





    public override string GetDescription()
    {
        if (hasBox) return "You can't carry 2 packages.";
        //if (isPicked) return "<color=green>Hold</color> to drop the package.";
        return "<color=green>Hold</color> to pick up the package.";
    }

    public override void Interact()
    {
        if (!hasBox)
        {
            isPicked = !isPicked;
            PickBox();
        }
    }
}
