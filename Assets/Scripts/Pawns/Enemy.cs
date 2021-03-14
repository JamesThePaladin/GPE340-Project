using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private Transform target;
    private Pawn pawn;
    private Vector3 moveDirection;
    private Animator _anim;
    [SerializeField]
    private float distanceToTarget;
    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponent<Pawn>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceToTarget = GetDistanceToTarget();
        Debug.Log("Distance to " + target + (" is " + distanceToTarget));
        pawn.transform.LookAt(target);
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            //Do Nothing
            Debug.Log("Stopping at stoppingDistance");
        }
        else 
        {
            moveDirection = target.position - transform.position;
            pawn.Move(moveDirection);
        }
    }

    private float GetDistanceToTarget() 
    {
        float distanceToTarget = Vector3.Distance(target.position, pawn.transform.position);
        return distanceToTarget;
    }

    private void OnAnimatorMove() 
    {
        navMeshAgent.velocity = _anim.velocity;
    }
}
