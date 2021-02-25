using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class InputController : Controller
{
    private Camera mainCam; //main camera for aiming with mouse

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
