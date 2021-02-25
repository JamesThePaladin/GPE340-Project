using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
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

}
