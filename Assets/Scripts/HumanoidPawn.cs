using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidPawn : Pawn
{
    [SerializeField] private Animator _anim;
    public float speed = 1f;

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
        _anim.SetFloat("Forward", moveDirection.z * speed);
        _anim.SetFloat("Right", moveDirection.x * speed);
        base.Move(moveDirection);
    }
}
