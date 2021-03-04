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
    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponent<Pawn>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveDirection.x = target.position.x - transform.position.x;
        moveDirection.y = target.position.y - transform.position.y;
        moveDirection.z = target.position.z - transform.position.z;
        transform.LookAt(target);
        pawn.Move(moveDirection);
    }
}
