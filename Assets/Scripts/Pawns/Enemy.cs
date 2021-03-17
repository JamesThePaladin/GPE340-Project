using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform target;
    private Pawn pawn;
    private Vector3 moveDirection;
    private Animator _anim;
    private float distanceToTarget;
    [SerializeField, Range(0, 4), Tooltip("The distance at which AI begin to fire their weapons")]
    private float fireRadius = 4f;
    private float currentAngle;
    private float fireAngle;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        pawn = GetComponent<Pawn>();
        target = GameManager.instance.playerPawn.GetComponent<Transform>();
        _anim = GetComponent<Animator>();
        pawn.SendMessage("EquipDefaultWeapon");
        fireAngle = pawn.weapon.GetComponent<WeaponGun>().GetFireAngle();
    }

    private void Update()
    {
        
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

        //get current angle to target
        currentAngle = GetAngleToTarget();
       //if the distance to our target is less than or equal to our fire radius
        if (distanceToTarget <= fireRadius)
        {
            // and if our current angle is less than or equal to our weapon's fire angle
            if (currentAngle <= fireAngle)
            {
                // and if our pawn's weapon is not null
                if (pawn.weapon != null)
                {
                    //fire your weapon
                    pawn.weapon.AttackStart();
                }
            }
            //else if the our current angle to our target is greater than our acceptable angle to fire
            else if (currentAngle > fireAngle)
            {
                //stop firing
                pawn.weapon.AttackEnd();
            } 
        }
    }

    private float GetDistanceToTarget() 
    {
        float distanceToTarget = Vector3.Distance(target.position, pawn.transform.position);
        return distanceToTarget;
    }

    private float GetAngleToTarget() 
    {
        Vector3 targetDir = target.position - pawn.transform.position;
        float angleToTarget = Vector3.Angle(targetDir, pawn.transform.forward);
        return angleToTarget;
    }
    private void OnAnimatorMove() 
    {
        navMeshAgent.velocity = _anim.velocity;
    }
}
