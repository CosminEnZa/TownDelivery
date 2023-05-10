using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSignAnim : MonoBehaviour
{
    public Animator anim_;
     
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "CarPlayer")
        {
            anim_.SetBool("open", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "CarPlayer")
        {
            anim_.SetBool("open", true);
        }
    }
}
