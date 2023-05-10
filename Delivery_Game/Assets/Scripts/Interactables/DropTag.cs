using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Box")
        {
            this.tag = "NonDrop";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            this.tag = "Drop";
        }
    }
}
