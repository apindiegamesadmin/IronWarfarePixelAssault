using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    public int MaxHealth = 100;

    [SerializeField]
    private int health;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            OnHealthChange?.Invoke((float)Health / MaxHealth);
        }
    }


    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit, OnHeal;
    public int shieldPoint;
    public bool shield;
    public bool takeNoDamage;

    private void Start()
    {
        Health = MaxHealth;
    }

    internal void Hit(int damagePoints)
    {
        if (shield)
        {
            shieldPoint -= damagePoints;
            if (shieldPoint <= 0)
            {
                shield = false;
            }
        }
        else
        {
            // Health -= damagePoints;
            // if (Health <= 0)
            // {
            //     OnDead?.Invoke();
            // }
            // else
            // {
            //     OnHit?.Invoke();
            // }

            if (takeNoDamage)
            {
                Health -= damagePoints * 0;
                Debug.Log("No dmg!");
            }
            else
            {
                Health -= damagePoints;
                Debug.Log("Dmg!");
                if (Health <= 0)
                {
                    OnDead?.Invoke();
                }
                else
                {
                    OnHit?.Invoke();
                }
            }
        }
    }

    public void Heal(int healthBoost)
    {
        Health += healthBoost;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        OnHeal?.Invoke();
    }
}
