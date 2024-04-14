using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class MenuCameraController : MonoBehaviour , IMoveable
{
    [field: SerializeField] public WaypointManager _waypointManager { get ; set ; }
    [field: SerializeField] public float distanceThreshold { get ; set ; }
    public NavMeshAgent agent { get ; set ; }
    public Transform currentWaypoint { get ; set ; }

    [SerializeField] private Transform lookAt;

    [SerializeField] private float speed;

    public void MoveToNextWaypoint()
    {
        Assert.IsNotNull(currentWaypoint, "Please set camera current waypoint");

        this.gameObject.transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.transform.position, speed* Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = _waypointManager.GetNextWayPoint(currentWaypoint);
        }
    }

    public void SetCurrentPosition()
    {
        currentWaypoint = _waypointManager.GetNextWayPoint(currentWaypoint);
        this.gameObject.transform.position = currentWaypoint.position;

        currentWaypoint = _waypointManager.GetNextWayPoint(currentWaypoint);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetCurrentPosition();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToNextWaypoint();
        this.gameObject.transform.LookAt(lookAt);
    }
}
