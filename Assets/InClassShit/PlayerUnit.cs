using UnityEngine;
using System.Collections;

public class PlayerUnit : MonoBehaviour {
    private NavMeshAgent agent;
    public Vector3 destination;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(destination);
	}

    public void MoveTo(Vector3 newDestination)
    {
        destination = newDestination;
    }
}
