using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HumanoidPawn : Pawn
{
    [SerializeField] private Animator _anim; //animator on player pawn
    private Camera mainCam; //main camera for aiming with mouse
    private float sprintBoost = 1.5f; //for player sprint boost
    public float speed = 1f; //player pawn movement speed

    // Start is called before the first frame update
    public override void Start()
    {
        _anim.GetComponent<Animator>();
        mainCam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    public override void Update()
    {
        Ray camRay = mainCam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(camRay, out rayLength))
        {
            //get the point of intersection between the raycast and the plane
            Vector3 pointToLook = camRay.GetPoint(rayLength);
            //draw a line so we can see it
            Debug.DrawLine(camRay.origin, pointToLook, UnityEngine.Color.blue);
            //look at the point
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    public override void Move(Vector3 moveDirection)
    {
        //limit max distance of move vector to 1, level the playing field for joysticks
        moveDirection = moveDirection.normalized;

        //if statement for sprint function
        if (Input.GetKey(KeyCode.LeftShift))
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
}
