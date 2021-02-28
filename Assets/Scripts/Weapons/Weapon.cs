using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    public float damage;
    [SerializeField, Tooltip("The actor owner of this weapon.")]
    protected HumanoidPawn owner;
    [Header("IK Points")]
    public Transform rightHandPoint;
    public Transform leftHandPoint;
    public Transform RightElbowPoint;

    [Header("Firing Events")]
    public UnityEvent OnAttackStart;
    public UnityEvent OnAttackEnd;

    protected void Awake()
    {
        owner = gameObject.GetComponentInParent<HumanoidPawn>();
    }
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void AttackStart() 
    {
        // TODO: This is what happens when any attack starts
        OnAttackStart.Invoke();
    }

    public virtual void AttackEnd() 
    {
        // TODO: This is what happens when any attack ends
        OnAttackEnd.Invoke();
    }

    public void SetDamage(float value) 
    {
        damage = value;
    }
}
