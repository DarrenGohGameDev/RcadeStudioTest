using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IMoveable 
{
    WaypointManager _waypointManager { get; set; }

    float distanceThreshold { get; set; }

    NavMeshAgent agent { get; set; }

    Transform currentWaypoint { get; set; }

    void SetCurrentPosition();

    void MoveToNextWaypoint();
}
