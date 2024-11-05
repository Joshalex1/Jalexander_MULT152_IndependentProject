using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEPLATFORM : MonoBehaviour
{
    public Transform[] waypoints; // Array to hold waypoints
    public float speed = 2f; // Speed of the platform
    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints.Length == 0) return; // Ensure there are waypoints

        // Move the platform towards the current waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Use a for loop to find the next waypoint
            for (int i = 0; i < waypoints.Length; i++)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                if (currentWaypointIndex == i)
                {
                    break;
                }
            }

        }
    }

}