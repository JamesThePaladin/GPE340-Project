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
        target = GameManager.instance.playerPawn.GetComponent<Transform>();
        _anim = GetComponent<Animator>();
        pawn.SendMessage("EquipDefaultWeapon");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get our distance to target
        distanceToTarget = GetDistanceToTarget();
        //look at our target
        pawn.transform.LookAt(target);
        //if our distance to target is less than or equal to our stopping distance
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            //change is stopped on the nav Mesh Agent to true
            navMeshAgent.isStopped = true;
            //set all animations to 0
            _anim.SetFloat("Forward", 0f);
            _anim.SetFloat("Right", 0f);
            return;
        }
        //otherwise
        else 
        {
            //set is stopped to false
            navMeshAgent.isStopped = false;
            //the direction we want to move in is our target's position minus our position
            moveDirection = target.position - transform.position;
            //tell the pawn to move in that direction
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
