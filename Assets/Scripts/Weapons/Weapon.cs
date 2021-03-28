using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    public AudioSource attackSound;
    public float damage;
    [SerializeField, Tooltip("The actor owner of this weapon.")]
    protected Pawn owner;
    public int maxAmmo = 10; //max ammo for a gun defaulted to 10
    public int currentAmmo; //ammount of ammo the gun currently has
    [SerializeField, Range(0, 5), Tooltip("The angle acceptable to beging firing this gun at when turning to a target. For AI use.")]
    protected float fireAngle = 1.5f;
    [Header("IK Points")]
    public Transform rightHandPoint;
    public Transform leftHandPoint;
    public Transform RightElbowPoint;

    [Header("Firing Events")]
    public UnityEvent OnAttackStart;
    public UnityEvent OnAttackEnd;

    protected virtual void Awake()
    {
        attackSound = GetComponentInChildren<AudioSource>();
        owner = gameObject.GetComponentInParent<Pawn>();
    }
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void FixedUpdate() 
    {
        
    }

    public virtual void AttackStart() 
    {
        OnAttackStart.Invoke();
    }

    public virtual void AttackEnd() 
    {
        OnAttackEnd.Invoke();
    }

    public void SetDamage(float value) 
    {
        damage = value;
    }

    public void UpdateAmmoDisplay() 
    {
        UIManager.instance.RegisterPlayerAmmo(owner);
    }

    public void PlayAttackSound() 
    {
        attackSound.Play();
    }
}
