using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClientIA : MonoBehaviour
{

    private NavMeshAgent _navMeshAgent;

    public bool MovingToDestination { get; set; }

    public Vector3 Destination { get; set; }


    // Use this for initialization
    void Start ()
	{
	    MovingToDestination = false;
	    Destination = Vector3.negativeInfinity;
	    _navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Destination != Vector3.negativeInfinity && !MovingToDestination)
	    {
	        MovingToDestination = true;
	        _navMeshAgent.destination = Destination;
	    }
	}
}
