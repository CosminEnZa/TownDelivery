using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : Interactable
{
    public static bool isClosed = true;

    public Animator doorAnim;

    [SerializeField]
    private AudioSource _source;

    [Header("AudioClips")]
    public AudioClip open;
    public AudioClip close;


    private void Start()
    {
        
    }

    private void Update()
    {
        if (!CarSwitch.isOn)
        {

            if (!isClosed)
            {
                doorAnim.Play("carDoor");
            }

            if (isClosed)
            {
                if (CarSwitch.isOn == false)
                {
                    doorAnim.Play("carDoor_close");
                }


            }
        }

    }


    public override string GetDescription()
    {
        if (isClosed) return "<color=green>Hold</color> to open the door.";
        return "<color=green>Hold</color> to close the door.";
    }

    public override void Interact()
    {
        isClosed = !isClosed;

        if (isClosed)
        {
            _source.clip = close;
            Invoke("PlayCloseDoor", 0.5f);
        }

        else if(!isClosed)
        {
            _source.clip = open;
            _source.Play();
            
        }

    }

    void PlayCloseDoor()
    {
        _source.Play();
    }
}
