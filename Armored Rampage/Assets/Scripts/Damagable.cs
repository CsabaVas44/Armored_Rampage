using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    public float MaxHealth = 100;

    [SerializeField]
    private float health;

    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit;
    public UnityEvent OnHeal;

    public Sprite DeadTank;

    public float Health
    {
        get => health;

        set
        {
            health = value;
            OnHealthChange?.Invoke((float)Health / MaxHealth);
        }
    }

    private void Start()
    {
        Health = MaxHealth;
    }

    public void Hit(float damagePoints)
    {
        Health -= damagePoints;
        if (Health <= 0)
        {
            OnDead?.Invoke();
            Destroy(gameObject);
        }
        else
        {
            OnHit?.Invoke();
        }
    }

    public void Heal(int healthBoost)
    {
        Health += healthBoost;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        OnHeal?.Invoke();
    }

    public void CastTank()
    {
        OnDead.Invoke();
        GameObject.Instantiate(DeadTank);
    }



}
