using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Events")]
    [SerializeField, Tooltip("Raised every time the object is healed.")]
    private UnityEvent onHeal;
    [SerializeField, Tooltip("Raised every time the object is damaged.")]
    private UnityEvent onDamage;
    [SerializeField, Tooltip("Raised once when the object's health reaches 0.")]
    private UnityEvent onDeath;

    [SerializeField] private static float MaxHealth = 100f;
    [SerializeField] private float health = 100f;

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

    public void Heal(int heal) 
    {
        health += heal;
    }

    public void FullHeal() 
    {
        health = MaxHealth;
    }
    public void Damage(int damage) 
    {
        health -= damage;
    }

    public void Kill() 
    {
        health = 0;
    }
}
