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
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetrange);
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

        //RaycastHit2D[] hit2 = Physics2D.RaycastAll(this.transform.position, Vector2.right, targetrange * 2f);
        //RaycastHit2D[] hit3 = Physics2D.RaycastAll(this.transform.position, Vector2.up, targetrange * 2f);
        //RaycastHit2D[] hit4 = Physics2D.RaycastAll(this.transform.position, Vector2.left, targetrange * 2f);

        RaycastHit2D[] hit = Physics2D.CircleCastAll(ShootPoint.position, targetrange, Player.GetComponent<Rigidbody2D>().position);
        Debug.Log(Player.GetComponent<Rigidbody2D>().position);

        if (hit.Length > 0)
        {
            Debug.Log("HitLength" + hit.Length);
            
            foreach (var item in hit)
            {
                Debug.Log(item.collider.tag);
                if (item.collider.gameObject.tag == "Player")
                {
                    target = item.transform;
                }
            }

            //}
            //if (hit3.Length > 0)
            //{
            //    foreach (var item in hit3)
            //    {
            //        if (item.collider.gameObject.tag == "Player")
            //        {
            //            target = item.transform;
            //        }
            //    }

            //}
            //if (hit4.Length > 0)
            //{
            //    foreach (var item in hit4)
            //    {
            //        if (item.collider.gameObject.tag == "Player")
            //        {
            //            target = item.transform;
            //        }
            //    }

            //}


        }


        // :) Dont open pls, like ever :) :) Nem tudom pontosan miért mûködik így de megy szóval gg
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

