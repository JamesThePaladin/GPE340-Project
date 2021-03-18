using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class InputController : Controller
{
    [Header("Components")]
    private Camera mainCam; //main camera for aiming with mouse

    // Start is called before the first frame update
    public override void Start()
    {
        //find our main camera on start
        mainCam = FindObjectOfType<Camera>();
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //if our pawn is not dead
        if (pawn.isDead == false)
        {
            //make a raycast from screen to mouse position
            Ray camRay = mainCam.ScreenPointToRay(Input.mousePosition);
            //create a plan to intersect our raycast as "the ground"
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

            if (groundPlane.Raycast(camRay, out float rayLength))
            {
                //get the point of intersection between the raycast and the plane
                Vector3 pointToLook = camRay.GetPoint(rayLength);
                //draw a line so we can see it
                Debug.DrawLine(camRay.origin, pointToLook, UnityEngine.Color.blue);
                //look at the point
                pawn.transform.LookAt(pointToLook);
            }

            //send our inputs to our pawn.
            pawn.Move(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));

            //if our pawn's weapon is not null
            if (pawn.weapon != null)
            {
                //and if they push the button assigned to Fire1, left click
                if (Input.GetButtonDown("Fire1"))
                {
                    //start our attack on our weapon
                    pawn.weapon.AttackStart();
                }

                //if they release the button assigned to Fire1, left click
                if (Input.GetButtonUp("Fire1"))
                {
                    //end our attack on our weapon
                    pawn.weapon.AttackEnd();
                }
            }
        }
        //otherwise, if they are dead
        else 
        {
            //don't move at all
            pawn.Move(Vector3.zero);
        }
        base.Update();
    }
}
