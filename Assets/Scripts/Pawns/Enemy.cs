using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private Weapon weapon;
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private Transform target;
    private Pawn pawn;
    private Vector3 moveDirection;
    private Animator _anim;
    [SerializeField]
    private float distanceToTarget;
    [SerializeField]
    private float shootRadius = 4f;
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
        //get our distance to target
        distanceToTarget = GetDistanceToTarget();
        //for debugging purposes since stopping distance isnt working, display the distance to target for comparison
        Debug.Log("Distance to " + target + (" is " + distanceToTarget));
        //look at our target
        pawn.transform.LookAt(target);
        //if our distance to target is less than or equal to our stopping distance
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            //Stop
            Debug.Log("Stopping at stoppingDistance");
        }
        //otherwise
        else 
        {
            //the direction we want to move in is our target's position minus our position
            moveDirection = target.position - transform.position;
            //tell the pawn to move in that direction
            pawn.Move(moveDirection);
        }
        //if (distanceToTarget <= shootRadius && weapon != null)
        //{
            //attack with our weapon
            
        //}
        //else if (distanceToTarget >= shootRadius && weapon != null)
        //{
            //stop attacking with our weapon
        //}
        //else 
        //{
            //do nothing
        //}
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
