using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreObjectPosition : MonoBehaviour
{
    public string ObjectID;
    // Start is called before the first frame update
    void Start()
    {

        transform.position = new Vector3(PlayerPrefs.GetFloat("ObjectPositionX" + ObjectID, this.transform.position.x), PlayerPrefs.GetFloat("ObjectPositionY" + ObjectID, this.transform.position.y), PlayerPrefs.GetFloat("ObjectPositionZ" + ObjectID, this.transform.position.z));
        StartCoroutine(StorePosition());
    }

    IEnumerator StorePosition()
    {
        while (true)
        {
            PlayerPrefs.SetFloat("ObjectPositionX" + ObjectID, this.transform.position.x);
            PlayerPrefs.SetFloat("ObjectPositionY" + ObjectID, this.transform.position.y);
            PlayerPrefs.SetFloat("ObjectPositionZ" + ObjectID, this.transform.position.z);

            yield return new WaitForSeconds(5);
        }
    }
}
