using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;

    public GameObject InteractButton;

    public TMPro.TextMeshProUGUI interactionText;
    public UnityEngine.UI.Image interactionHoldProgress;


    public Camera cam;
    private bool pressed = false;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        bool successfulHit = false;

        if(Physics.Raycast(ray, out hit, interactionDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                ButtonInteration(interactable);
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                InteractButton.SetActive(true);
                successfulHit = true;

               
            }
        }

        if (!successfulHit)
        {
            InteractButton.SetActive(false);
            interactionText.text = "";
        }

    }

    public void PressButton()
    {
        pressed = true;
    }
    
     void ButtonInteration(Interactable interactable)
    {
        if (pressed == true)
        {
            interactable.Interact();
            pressed = false;
        }
    }

    void HandleInteraction(Interactable interactable)
    {
        KeyCode key = KeyCode.E;
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if(Input.GetKeyDown(key))
                {
                   interactable.Interact();
                }
               break;

            case Interactable.InteractionType.Hold:
                if (Input.GetKey(key))
                {
                    // we are holding the key, increase the timer until we reach 1f
                    interactable.IncreaseHoldTime();
                    if (interactable.GetHoldTime() > 1f) {
                        interactable.Interact();
                        interactable.ResetHoldTime();
                    }
                }
                else
                {
                    interactable.ResetHoldTime();
                }
                interactionHoldProgress.fillAmount = interactable.GetHoldTime();
                break;

            case Interactable.InteractionType.Minigame:

                break;

            default:
                throw new System.Exception("Unsupported type of interactable.");
        }
    }
}
