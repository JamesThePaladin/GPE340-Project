using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Health Values")]
    [SerializeField]
    private float MaxHealth = 100f;
    [SerializeField]
    private float health = 100f;
    private float percent;

    [Header("Events")]
    [SerializeField, Tooltip("Called every time the object is healed.")]
    private UnityEvent onHeal;
    [SerializeField, Tooltip("Called every time the object is damaged.")]
    private UnityEvent onDamage;
    [SerializeField, Tooltip("Called once when the object's health reaches 0.")]
    private UnityEvent onDeath;


    public float GetHealth() 
    {
        return health;
    }

    private void SetHealth(float value) 
    {
        health = value;
    }

    public float GetMaxHealth() 
    {
        return MaxHealth;
    }

    private void SetMaxHealth(float value) 
    {
        MaxHealth = value;
    }

    public float GetPercent() 
    {
        percent = health / MaxHealth;
        return percent;
    }

    private void SetPercent() 
    {
        percent = health / MaxHealth;
    }

    public void Heal(float heal) 
    {
        heal = Mathf.Max(heal, 0f);
        health = Mathf.Clamp(health + heal, 0f, MaxHealth);
        SendMessage("onHeal", SendMessageOptions.DontRequireReceiver);
    }

    public void FullHeal() 
    {
        health = MaxHealth;
    }

    public void Damage(float damage) 
    {
        damage = Mathf.Max(damage, 0f);
        health = Mathf.Clamp(health - damage, 0f, MaxHealth);
        SendMessage("onDamage", SendMessageOptions.DontRequireReceiver);
        if (health <= 0f) 
        {
           SendMessage("onDeath", SendMessageOptions.DontRequireReceiver);
            onDeath.Invoke();
        }
    }

    public void Kill() 
    {
        health = 0;
        Destroy(gameObject);
    }
}
