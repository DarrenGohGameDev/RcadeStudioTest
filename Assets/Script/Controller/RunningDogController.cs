using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class RunningDogController : MonoBehaviour, IMoveable 
{
    [field: SerializeField] public WaypointManager _waypointManager { get; set; }
    [field: SerializeField] public float distanceThreshold { get; set; }
    [field: SerializeField] public NavMeshAgent agent { get; set; }
    public Transform currentWaypoint { get; set; }

    [field: SerializeField] public float stamina { get; set; }

    [field: SerializeField] public float maxStamina { get; set; }

    [field: SerializeField] public float staminaDrain { get; set; }

    [field: SerializeField] public float staminaRegen { get; set; }

    public Material dogMaterial;

    // Start is called before the first frame update
    void Start()
    {
        maxStamina = stamina;
        dogMaterial.SetColor("_Color", Color.red);
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
        Assert.IsNotNull(currentWaypoint, "Please set Running Dog current waypoint");
        dogMaterial.SetColor("_Color", Color.red);
        agent.SetDestination(currentWaypoint.transform.position);
        stamina -= staminaDrain * Time.deltaTime;
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = _waypointManager.GetNextWayPoint(currentWaypoint);
        }
    }

    public void RegenStamina()
    {
        stamina += staminaRegen * Time.deltaTime;
        dogMaterial.SetColor("_Color",Color.green);
    }
}
