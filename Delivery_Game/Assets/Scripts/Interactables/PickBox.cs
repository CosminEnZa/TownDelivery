using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBox : MonoBehaviour
{
    
    public GameObject ObjectPosition;
    public float moveSpeed = 15f;

    private void Start()
    {
        
        ObjectPosition = this.gameObject;
        ObjectPosition.transform.position = this.transform.position;
    }

    private void Update()
    {
        if (CarSwitch.isOn == true)
        {
            this.transform.position = ObjectPosition.transform.position;
        }
        else if (CarSwitch.isOn == false)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, ObjectPosition.transform.position, Time.deltaTime * 4f);
        }

    }

    public void Reset()
    {
        ObjectPosition = this.gameObject;
    }
}
