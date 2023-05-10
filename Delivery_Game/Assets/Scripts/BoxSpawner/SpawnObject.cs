using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objectToSpawn;

    void OnEnable()
    {
        Instantiate(objectToSpawn, this.transform.position, this.transform.rotation);
        SpawnBoxes.totalObjects++;
    }
}
