using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCarRotation : MonoBehaviour
{
    [SerializeField]
    private int deltaSpeed;

    [SerializeField]
    private int maxSpeed;

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Dot(transform.up, Vector3.down) > 0)
        {

            StartCoroutine(rotateCar());
        }
    }

    IEnumerator rotateCar()
    {
        yield return new WaitForSeconds(4);

        this.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);

    }
}
