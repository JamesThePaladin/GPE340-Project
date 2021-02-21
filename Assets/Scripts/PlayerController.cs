using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    [SerializeField, Tooltip("The max speed of the player")]
    private float speed = 4f; //speed of player

    private Animator anim; //animator on the player GameObject

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        input = Vector3.ClampMagnitude(input, 1f);
        input *= speed;
        anim.SetFloat("Forward", Input.GetAxis("Vertical"));
        anim.SetFloat("Right", Input.GetAxis("Horizontal"));
    }
}
