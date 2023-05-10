using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    CharacterNavigatorController controller;
    public Waypoint currentWaypoint;

    private void Awake()
    {
        controller = GetComponent<CharacterNavigatorController>();
    }

    void Start()
    {
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    void Uppdate()
    {
        if(controller.ReachedDestination)
        {
            currentWaypoint = currentWaypoint.nextWaypoint;
            controller.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
