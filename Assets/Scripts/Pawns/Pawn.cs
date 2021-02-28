using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Pawn : MonoBehaviour
{
    [Header("Weapon Settings"), Tooltip("The weapon an actor currently has equipped.")]
    public Weapon weapon;
    [Header("Movement Settings")]
    [Range(0f, 3f), Tooltip("The amount the speed is multiplied by when the player is sprinting.")]
    public float sprintBoost = 1.5f; //for player sprint boost

    public virtual void Start() 
    {

    }

    public virtual void Update() 
    {
        
    }

    public virtual void Move(Vector3 moveDirection) 
    {
        
    }
}
