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
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!target) 
        {
            if (GameManager.instance.player)
            {
                target = GameManager.instance.player.transform; 

            }
        }
        //set the desired camera position equal to the GameObject's plus the offset
        Vector3 targetCamPos = target.position + offset;
        //move towards the target but slow done as you get there
        transform.position = Vector3.Slerp(transform.position, targetCamPos, smoothing * Time.fixedDeltaTime);
    }
}
    

