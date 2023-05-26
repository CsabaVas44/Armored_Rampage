using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class MultipleShots : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;

    [Header("Attribute")]
    [SerializeField] private float targetrange = 5f;

    public GameObject Bullet;
    public GameObject Player;
    public float fireRate;
    public float nextTimeToShoot = 0;
    public Transform ShootPoint;
    public float force;

    private Transform target;
    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        else
        {
            RotateTowardsTarget();
            if (Time.time % fireRate < 0.001)
            {
                Shoot();
            }
        }

        if (!CheckTargetIsInRange())
        {
            target = null;
        }

    }


    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetrange;
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = targetRotation;
    }

    private void FindTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(this.transform.position, targetrange);

        if (hits.Length > 0)
        {
            foreach (var item in hits)
            {
                if (item.tag == "Player")
                {
                    target = item.transform;
                }
            }
        }
    }

void Shoot()
{
    float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
    Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

    GameObject bulletIns = Instantiate(Bullet, ShootPoint.position, targetRotation);
    GameObject bulletIns2 = Instantiate(Bullet, ShootPoint.position, targetRotation);
    GameObject bulletIns3 = Instantiate(Bullet, ShootPoint.position, targetRotation);
    bulletIns.GetComponent<Rigidbody2D>().AddForce(new Vector2(target.position.x - 1 - transform.position.x, target.position.y - 1 - transform.position.y) * force);
    bulletIns2.GetComponent<Rigidbody2D>().AddForce(new Vector2(target.position.x + 1 - transform.position.x, target.position.y + 1 - transform.position.y) * force);
    bulletIns3.GetComponent<Rigidbody2D>().AddForce(new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y) * force);
}

}

