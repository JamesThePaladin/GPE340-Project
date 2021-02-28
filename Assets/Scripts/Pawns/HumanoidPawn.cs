using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HumanoidPawn : Pawn
{
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
        //Convert the moveDirection from local space to world space
        moveDirection = transform.InverseTransformDirection(moveDirection);
        
        //sets animation parameters based on the move direction datat
        _anim.SetFloat("Forward", moveDirection.z * speed);
        _anim.SetFloat("Right", moveDirection.x * speed);
        base.Move(moveDirection);
    }

    public void OnAnimatorIK(int layerIndex)
    {
        //if we dont have a weapon
        if (!weapon) 
        {
            //clear all weights
            _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
            _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
            _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
            _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);
            _anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 0f);
            return;
        }
        //if we have a weapon with right hand ik points
        if (weapon.rightHandPoint)
        {
            //set position and rotation
            _anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandPoint.position);
            _anim.SetIKRotation(AvatarIKGoal.RightHand, weapon.rightHandPoint.rotation);
            _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
            _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
        }
        //otherwise
        else 
        {
            //leave them where they at
            _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
            _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
        }
        //if we have a weapon with left hand ik points
        if (weapon.leftHandPoint)
        {
            //set position and rotation
            _anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandPoint.position);
            _anim.SetIKRotation(AvatarIKGoal.LeftHand, weapon.leftHandPoint.rotation);
            _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
            _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
        }
        //otherwise
        else 
        {
            //leave them where they at
            _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
            _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);
        }
        //if we have a weapon with a right elbow hint
        if (weapon.RightElbowPoint)
        {
            //set hint position and weight
            _anim.SetIKHintPosition(AvatarIKHint.RightElbow, weapon.RightElbowPoint.position);
            _anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1.0f);
        }
        else 
        {
            //clear hint weight
            _anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 0f);
        }
    }   
}