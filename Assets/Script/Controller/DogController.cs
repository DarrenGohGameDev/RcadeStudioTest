using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class DogController : MonoBehaviour ,IMoveable
{
    [field: SerializeField] public WaypointManager _waypointManager { get; set; }
    [field: SerializeField] public float distanceThreshold { get; set; }
    [field: SerializeField] public NavMeshAgent agent { get; set; }
    public Transform currentWaypoint { get; set; }

    public void MoveToNextWaypoint()
    {
        Assert.IsNotNull(currentWaypoint, "Please set Dog Controller current waypoint");

        agent.SetDestination(currentWaypoint.transform.position);

        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = _waypointManager.GetNextWayPoint(currentWaypoint);
        }
    }

    public void SetCurrentPosition()
    {
        currentWaypoint = _waypointManager.GetNextWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = _waypointManager.GetNextWayPoint(currentWaypoint);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //MoveToNextWaypoint();
    }
}
