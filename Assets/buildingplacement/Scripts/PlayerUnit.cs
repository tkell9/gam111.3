using UnityEngine;
using System.Collections;

public class PlayerUnit : MonoBehaviour {
    private NavMeshAgent agent;
    public Vector3 destination;

    private Animator animator;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        destination = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(destination);

        animator.SetFloat("Speed", Mathf.Max(agent.velocity.magnitude / agent.speed, 0.1f));
        animator.SetBool("isWalking", agent.velocity.magnitude > 0.1f);
	}

    public void MoveTo(Vector3 newDestination)
    {
        destination = newDestination;
    }
}
