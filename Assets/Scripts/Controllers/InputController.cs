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
        if (GameManager.instance.isGameStart == true) 
        {
            //TODO: Add this back in when scene switching is set up
            //UIManager.instance.RegisterPlayerHealth(pawn);
        }
        //if our pawn is not dead
        if (pawn.isDead == false)
        {
            //make a raycast from screen to mouse position
            Ray camRay = mainCam.ScreenPointToRay(Input.mousePosition);
            //create a plan to intersect our raycast as "the ground"
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

            if (groundPlane.Raycast(camRay, out float rayPoint))
            {
                //get the point of intersection between the raycast and the plane
                Vector3 pointToLook = camRay.GetPoint(rayPoint);
                //draw a line so we can see it
                Debug.DrawLine(camRay.origin, pointToLook, UnityEngine.Color.blue);
                //get our rotation instructions from our
                Quaternion desiredRotation = Quaternion.LookRotation(pointToLook - pawn.transform.position, Vector3.up);
                //rotate towards our target starting from our current rotation to the desired rotation, set the x and z of desired rotation to zero because of undesirable results 
                pawn.transform.rotation = Quaternion.RotateTowards(pawn.transform.rotation, new Quaternion(0, desiredRotation.y, 0, desiredRotation.w), pawn.turnSpeed * Time.deltaTime);
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
            //stop attacking if you are
            pawn.weapon.AttackEnd();
        }
        base.Update();
    }
}
