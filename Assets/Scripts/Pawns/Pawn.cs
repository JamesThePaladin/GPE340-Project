using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public abstract class Pawn : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    protected Animator _anim; //animator on player pawn
    [SerializeField]
    public Health pawnHealth { get; private set; } //The Health Object attached to this Pawn
    [Header("Weapon Settings"), Tooltip("The weapon an actor currently has equipped.")]
    public Weapon weapon;
    [Header("Movement Settings")]
    [Range(0f, 3f), Tooltip("The amount the speed is multiplied by when the player is sprinting.")]
    public float sprintBoost = 1f; //for player sprint boost

    public virtual void Awake()
    {
        _anim = GetComponent<Animator>();
        pawnHealth = GetComponent<Health>();
    }
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
