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
    private Transform targetPos;
    private Pawn pawn;
    private Vector3 moveDirection;
    private Animator _anim;
    private float distanceToTarget;
    [SerializeField, Range(0, 10), Tooltip("The distance at which AI begin to fire their weapons")]
    private float fireRadius = 4f;
    private float currentAngle;
    private float fireAngle;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        pawn = GetComponent<Pawn>();
        targetPos = GameManager.instance.player.GetComponent<Transform>();
        _anim = GetComponent<Animator>();
        pawn.SendMessage("EquipDefaultWeapon");
        fireAngle = pawn.weapon.GetComponent<WeaponGun>().GetFireAngle();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.playerPawn.isDead == true)
        {
            //change is stopped on the nav Mesh Agent to true
            navMeshAgent.isStopped = true;
            //stop moving
            pawn.Move(Vector3.zero);
            //stop rotating
            rb.velocity = Vector3.zero;
            //stop firing
            pawn.weapon.AttackEnd();
            //set all animations to 0
            _anim.SetFloat("Forward", 0f);
            _anim.SetFloat("Right", 0f);
            return;
        }
        else
        {
            //get our rotation instructions from our
            Quaternion desiredRotation = Quaternion.LookRotation(targetPos.position - transform.position, Vector3.up);
            //rotate towards our target starting from our current rotation to the desired rotation 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, pawn.turnSpeed * Time.fixedDeltaTime);
            //get our distance to target
            distanceToTarget = GetDistanceToTarget();
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
                moveDirection = targetPos.position - transform.position;
                //tell the pawn to move in that direction
                pawn.Move(moveDirection);
            }
        }
    }

    private float GetDistanceToTarget() 
    {
        float distanceToTarget = Vector3.Distance(targetPos.position, pawn.transform.position);
        return distanceToTarget;
    }

    private float GetAngleToTarget() 
    {
        //get our target direction by subtracting our position from our target's position
        Vector3 targetDir = targetPos.position - pawn.transform.position;
        //get the angle in degrees between our target direction and our forward transform
        float angleToTarget = Vector3.Angle(targetDir, pawn.transform.forward);
        //return angle
        return angleToTarget;
    }
    private void OnAnimatorMove() 
    {
        navMeshAgent.velocity = _anim.velocity;
    }
}
