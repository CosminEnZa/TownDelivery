using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    //This will be the zombie's speed. Adjust as necessary.
    private float speed = 6.0f;

    public int stopDist;
    public int farDist;
    public int closeDist;

    public float closeSpeed;
    public float farSpeed;

    public Animator anim;

    void Start()
    {
        //At the start of the game, the zombies will find the gameobject called wayPoint.
        wayPoint = GameObject.Find("PlayerCapsule");
    }

    void Update()
    {
        float dist = Vector3.Distance(wayPoint.transform.position, this.transform.position);
        if (dist > 3)
        {
            transform.LookAt(wayPoint.transform);
        }
        if(dist <= stopDist)
        {
            speed = 0;
        }
        else if (dist > stopDist && dist <= closeDist)
        {
            speed = closeSpeed;
        }
        else if (dist > farDist)
        {
            speed = farSpeed;
        }

        if(dist <= stopDist)
        {
            anim.SetBool("Stop", true);
        }

        if (dist > stopDist)
        {
            anim.SetBool("Stop", false);
        }
        wayPointPos = new Vector3(wayPoint.transform.position.x, this.transform.position.y, wayPoint.transform.position.z);
        //Here, the zombie's will follow the waypoint.
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
    }
}
