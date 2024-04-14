using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class PedestrianController : MonoBehaviour , IMoveable
{
    [field: SerializeField] public WaypointManager _waypointManager { get; set; }
    [field: SerializeField] public float distanceThreshold { get; set; }
    [field: SerializeField] public NavMeshAgent agent { get; set; }
    public Transform currentWaypoint { get; set; }

    public bool dogIsNear;

    public bool fleed;

    [SerializeField] Transform fleeLocation;

    public Animator pedestrianAnimator;

    public float hideDuration;

    public float MaxHideDuration;

    public bool hideFromDog;

    public bool nearDogIsFront;
    // Start is called before the first frame update
    void Start()
    {
        MaxHideDuration = hideDuration;
        Assert.IsNotNull(pedestrianAnimator, "Please set Pedestrian animation controller ");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCurrentPosition()
    {
        currentWaypoint = _waypointManager.GetNextWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = _waypointManager.GetNextWayPoint(currentWaypoint);
    }

    public void MoveToNextWaypoint()
    {
        Assert.IsNotNull(currentWaypoint, "Please set Pedestrian current waypoint");
        SetAnimationTrigger("isWalking");
        ResetAnimationTrigger("isHidding");
        ResetAnimationTrigger("isRunning");

        agent.SetDestination(currentWaypoint.transform.position);
        
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = _waypointManager.GetNextWayPoint(currentWaypoint);
        }
    }

    public void FleeBackToPrevWaypoint()
    {
        Assert.IsNotNull(currentWaypoint, "Please set Pedestrian current waypoint");
        Assert.IsNotNull(fleeLocation, "Please set flee location waypoint");
        SetAnimationTrigger("isRunning");
        if (nearDogIsFront) 
        {
            agent.SetDestination(currentWaypoint.transform.position);
            currentWaypoint = _waypointManager.GetPrevWayPoint(currentWaypoint);
            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            {
                if (!dogIsNear)
                {
                    fleed = true;
                }
            }
        }
        else
        {
            agent.SetDestination(currentWaypoint.transform.position);
            currentWaypoint = _waypointManager.GetNextWayPoint(currentWaypoint);
            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            {
                if (!dogIsNear)
                {
                    fleed = true;
                }
            }
            
        }
    }

    public void HideFromDogs()
    {
        agent.SetDestination(fleeLocation.transform.position);
        if (Vector3.Distance(transform.position, fleeLocation.transform.position) < distanceThreshold)
        {
            hideDuration -= 1 * Time.deltaTime;
            agent.isStopped = true;
            dogIsNear = false;
            SetAnimationTrigger("isHidding");
        }
    }

    public void SetAnimationTrigger(string trigger)
    {
        pedestrianAnimator.SetTrigger(trigger);
    }

    public void ResetAnimationTrigger(string trigger) 
    { 
        pedestrianAnimator.ResetTrigger(trigger);
    }
}
