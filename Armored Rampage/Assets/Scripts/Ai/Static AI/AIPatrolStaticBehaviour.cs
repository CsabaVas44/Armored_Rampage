using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolStaticBehaviour : AIBehaviour
{
    public float patrolDelay = 2;

    [SerializeField]
    Vector2 randomDirection = Vector2.zero;

    [SerializeField]
    float currentPatrolDelay;

    private void Awake()
    {
        randomDirection = Random.insideUnitCircle;
    }

    public override void PerformAction(TankController tank, AiDetector detector)
    {
        if (tank != null)
        {
            float? angle = Vector2.Angle(tank.aimTurret.transform.up, randomDirection);
            if (currentPatrolDelay <= 0 && (angle < 2))
            {
                randomDirection = Random.insideUnitCircle;
                currentPatrolDelay = patrolDelay;
            }
            else
            {
                if (currentPatrolDelay > 0)
                {
                    currentPatrolDelay -= Time.deltaTime;
                }
                else
                {
                    tank.HandleTurretMovement((Vector2)tank.aimTurret.transform.position + randomDirection);
                }
            }
        }
    }
}
