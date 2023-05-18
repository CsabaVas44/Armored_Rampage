using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class PatrollingEnemyTurret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;

    [Header("Attribute")]
    [SerializeField] private float targetrange = 5f;

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
        RotateTowardsTarget();

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
        RaycastHit2D[] hit = Physics2D.RaycastAll(this.transform.position, Vector2.down, targetrange * 2f);
        RaycastHit2D[] hit2 = Physics2D.RaycastAll(this.transform.position, Vector2.right, targetrange * 2f);
        RaycastHit2D[] hit3 = Physics2D.RaycastAll(this.transform.position, Vector2.up, targetrange * 2f);
        RaycastHit2D[] hit4 = Physics2D.RaycastAll(this.transform.position, Vector2.left, targetrange * 2f);

        if (hit.Length > 0)
        {
            Debug.Log(hit.Length);
            foreach (var item in hit)
            {
                Debug.Log(item.collider.tag);
                if (item.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Found the player");
                    target = item.transform;
                }
            }

        }
        if (hit2.Length > 0)
        {
            Debug.Log(hit.Length);
            foreach (var item in hit2)
            {
                Debug.Log(item.collider.tag);
                if (item.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Found the player");
                    target = item.transform;
                }
            }

        }
        if (hit3.Length > 0)
        {
            Debug.Log(hit.Length);
            foreach (var item in hit3)
            {
                Debug.Log(item.collider.tag);
                if (item.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Found the player");
                    target = item.transform;
                }
            }

        }
        if (hit4.Length > 0)
        {
            Debug.Log(hit.Length);
            foreach (var item in hit4)
            {
                Debug.Log(item.collider.tag);
                if (item.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Found the player");
                    target = item.transform;
                }
            }

        }



    }
}
