using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    protected Vector3 axis = Vector3.up;
    protected float rotationSpeed = 90f;
    // Start is called before the first frame update

    protected virtual void Awake() 
    {
        Destroy(gameObject, 15f);
    }

    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, axis);
    }

    protected void OnTriggerEnter(Collider collider)
    {
        HumanoidPawn entity = collider.GetComponent<HumanoidPawn>();
        if (entity) 
        {
            OnPickUp(entity);
        }
    }

    protected void OnPickUp(HumanoidPawn entity) 
    {
        Destroy(gameObject);
    }

}
