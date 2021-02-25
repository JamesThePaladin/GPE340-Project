using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HumanoidPawn : Pawn
{
    [Header("Components")]
    [SerializeField] 
    private Animator _anim; //animator on player pawn
    

    [Header("Movement Settings")]
    [SerializeField, Range(0f, 3f), Tooltip("The amount the speed is multiplied by when the player is sprinting.")] 
    private float sprintBoost = 1.5f; //for player sprint boost
    [SerializeField, Range(0f, 5f), Tooltip("The speed the player moves in feet/second")] 
    private float speed = 1f; //player pawn movement speed

    // Start is called before the first frame update
    public override void Start()
    {
        _anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void Move(Vector3 moveDirection)
    {
        //limit max distance of move vector to 1, level the playing field for joysticks
        moveDirection = moveDirection.normalized;

        //if statement for sprint function
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            //Convert the moveDirection from local space to world space then multiply by sprint boost
            moveDirection = transform.InverseTransformDirection(moveDirection) * sprintBoost;
        }
        else
        {
            //Convert the moveDirection from local space to world space
            moveDirection = transform.InverseTransformDirection(moveDirection);
        }

        //sets animation parameters based on the move direction datat
        _anim.SetFloat("Forward", moveDirection.z * speed);
        _anim.SetFloat("Right", moveDirection.x * speed);
        base.Move(moveDirection);
    }

    public void OnAnimatorIK(int layerIndex)
    {
        // TODO: Add if has weapon check and hands check

        // set IK goal positions and rotations
        _anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandPoint.position);
        _anim.SetIKRotation(AvatarIKGoal.LeftHand, weapon.leftHandPoint.rotation);
        _anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandPoint.position);
        _anim.SetIKRotation(AvatarIKGoal.RightHand, weapon.rightHandPoint.rotation);

        _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
        _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
    }   
}