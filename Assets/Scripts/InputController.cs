using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class InputController : Controller
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        pawn.Move(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));
        base.Update();
    }
}
