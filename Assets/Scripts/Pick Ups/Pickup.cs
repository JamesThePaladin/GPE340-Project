using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    protected Vector3 axis = Vector3.up;
    protected float rotationSpeed = 90f;
    // Start is called before the first frame update

    public virtual void Awake()
    {
        Destroy(gameObject, 15f);
    }

    public virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //rotate the pickup as it sits on the ground
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, axis);
    }

    protected void OnTriggerEnter(Collider collider)
    {
        //check to see if what collided with pickup is a HumanoidPawn
        HumanoidPawn entity = collider.GetComponent<HumanoidPawn>();
        //if it is
        if (entity)
        {
            //call on pickup
            OnPickUp(entity);
        }
    }

    protected virtual void OnPickUp(HumanoidPawn entity)
    {
        Destroy(gameObject);
    }

}
