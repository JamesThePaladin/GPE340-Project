﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public abstract class Pawn : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    protected Animator _anim; //animator on player pawn
    [HideInInspector]
    public Health pawnHealth; //The Health Object attached to this Pawn
    private Transform tf; //the transform component of our pawn
    public AudioSource pawnAudio; //audio for pawns
    public ParticleSystem bloodParticle; //blood particle for pawn hit
    [Header("Weapon Settings"), Tooltip("The weapon an actor currently has equipped.")]
    public Weapon weapon;
    [Header("Movement Settings")]
    [Range(0f, 5f), Tooltip("The speed the player moves in feet/second")]
    public float speed = 1f; //player pawn movement speed
    [Range(0f, 3f), Tooltip("The amount the speed is multiplied by when the player is sprinting.")]
    public float sprintBoost = 1f; //for player sprint boost
    [Range(0f, 1000f), Tooltip("This variable controls how fast the pawn turns towards its target in degrees per second.")]
    public float turnSpeed = 3f; //how fast our pawn turns towards something

    public virtual void Awake()
    {
        //get components as soon as you can
        _anim = GetComponent<Animator>();
        pawnHealth = GetComponent<Health>();
        tf = GetComponent<Transform>();
        pawnAudio = GetComponentInChildren<AudioSource>();
        bloodParticle = GetComponentInChildren<ParticleSystem>();
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

    public void PlayHurtSound() 
    {
        pawnAudio.Play();
    }
}
