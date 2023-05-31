using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class PatrollingEnemyTurret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;

    [Header("Attribute")]
    [SerializeField] private float targetrange;

    public GameObject Bullet;
    public GameObject Player;

    public float fireRate;
    public float nextTimeToShoot = 0;
    public Transform ShootPoint;
    public float force;
    private bool canShoot = false;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetrange);
    }

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
        }

        if (!CheckTargetIsInRange())
        {
            target = null;
        }





    }
    IEnumerator ShootCoroutine()
    {
        canShoot = true;
        yield return new WaitForSeconds(1.0f / fireRate);
        canShoot = false;
        Shoot();
    }

    private bool CheckTargetIsInRange()
    {
        if (!canShoot)
        {
            StartCoroutine(ShootCoroutine());
        }

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
    } // :) Dont open pls, like ever :) :) Nem tudom pontosan miért mûködik így de megy szóval gg

    void Shoot()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        GameObject bulletIns = Instantiate(Bullet, ShootPoint.position, targetRotation);
        bulletIns.GetComponent<Rigidbody2D>().AddForce(new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y) * force);
    }
}
