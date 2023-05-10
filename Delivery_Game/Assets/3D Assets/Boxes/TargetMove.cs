using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    [SerializeField] private List<GameObject> waypoints;  // Hom many items you want, will show in Inspector
    public float speed;

    private int current = 0;
    private float WPradius = 1;
    public int RotationSpeed;
    bool changeRot;                                                                      

    private void Start()
    {
       // GetRandom();
    }

    private void Update()
    {
        MoveBetweenWaypoints();
        transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
        transform.Rotate(Vector3.left * (RotationSpeed * Time.deltaTime));
    }

   /* private void GetRandom()
    {
        for (int i = 0; i < 30; i++)
        {
            waypoints.Add(new Vector3(Random.Range(transform.position.x, transform.position.x + 3f),
                Random.Range(transform.position.y, transform.position.y + 3f),
                transform.position.z));
        }
    }
    */

    private void MoveBetweenWaypoints()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius || changeRot == true)
        {
            RotationSpeed = Random.Range(1, 6);
            speed = RotationSpeed;
            current = Random.Range(0, waypoints.Count);
            changeRot = false;
            if (current >= waypoints.Count)
            {
                current = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        changeRot = true;
    }
}