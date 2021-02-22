using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    Vector3 offset;

    // Use this for initialization
    void Start()
    {
        //get offset of GameObject and Camera
        offset = transform.position - target.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //set the desired camera position equal to the GameObject's plus the offset
        Vector3 targetCamPos = target.position + offset;
        //make it smooth
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

    }
}
    

