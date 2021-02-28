using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class InputController : Controller
{
    [Header("Components")]
    private Camera mainCam; //main camera for aiming with mouse
    [Header("Pawn Movement Settings")]
    [SerializeField, Range(0f, 3f), Tooltip("The amount the speed is multiplied by when the player is sprinting.")]
    private float sprintBoost = 1.5f; //for player sprint boost
    // Start is called before the first frame update
    public override void Start()
    {
        mainCam = FindObjectOfType<Camera>();
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //make a raycast from screen to mouse position
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
            pawn.transform.LookAt(new Vector3(pointToLook.x, pawn.transform.position.y, pointToLook.z));
        }
        //if statement for sprint function
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Debug.Log("I'm sprinting!");
            //Convert the moveDirection from local space to world space then multiply by sprint boost
            pawn.Move(new Vector3(Input.GetAxis("Horizontal") * pawn.sprintBoost, 0f, Input.GetAxis("Vertical") * pawn.sprintBoost));
        }
        else
        {
            //Convert the moveDirection from local space to world space
            pawn.Move(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));
        }

        if (Input.GetButtonDown("Fire1")) 
        {
            pawn.weapon.AttackStart();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            pawn.weapon.AttackEnd();
        }

        pawn.Move(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));
        base.Update();
    }
}
