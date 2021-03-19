using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //set the desired camera position equal to the GameObject's plus the offset
        Vector3 targetCamPos = target.position + offset;
        //make it smooth
        transform.position = Vector3.Slerp(transform.position, targetCamPos, smoothing * Time.fixedDeltaTime);

    }
}
    

