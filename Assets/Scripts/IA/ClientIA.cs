using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClientIA : MonoBehaviour
{

    private NavMeshAgent _navMeshAgent;

	// Use this for initialization
	void Start ()
	{
	    _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.destination = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
