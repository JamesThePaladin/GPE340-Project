using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField, Range(0, 100), Tooltip("The amount this pickup heals the entity that picks it up.")] 
    private float healAmount;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Update();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnPickUp(HumanoidPawn entity)
    {
        Health entityHealth = entity.GetComponent<Health>();
        entityHealth.Heal(healAmount);
        base.OnPickUp(entity);
    }
}
