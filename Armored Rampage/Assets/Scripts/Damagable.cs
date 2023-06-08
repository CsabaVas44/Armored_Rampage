using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    public float MaxHealth = 100;
    public int lvlBoost = 100;

    [SerializeField]
    private float health;

    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit;
    public UnityEvent OnHeal;
    public Transform spawnPoint;
    public GameObject DeadTank;

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
        if (DataHolder.HullLvl == 1)
        {
            Health = MaxHealth+(lvlBoost);
        }
        else if (DataHolder.HullLvl == 2)
        {
            Health = MaxHealth+(lvlBoost*2);
        }
        Health = MaxHealth;
    }

    public void Hit(float damagePoints)
    {
        Health -= damagePoints;
        if (Health <= 0)
        {
            OnDead?.Invoke();
            Destroy(gameObject);
            GameObject DeadTankGO = Instantiate(DeadTank, spawnPoint.position, Quaternion.identity);
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
