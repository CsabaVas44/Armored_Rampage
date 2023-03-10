using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDetector : MonoBehaviour
{

    [Range(1, 15)]
    [SerializeField]
    float viewRadius = 11;

    [SerializeField]
    float detectionCheckDelay = 0.1f;

    [SerializeField]
    Transform target = null;

    [SerializeField]
    LayerMask playerLayerMask;

    [SerializeField]
    LayerMask visibilityLayer;

    [field: SerializeField]
    public bool TargetVisible { get; private set; }

    


    private void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    private void Update()
    {
        if (Target != null)
        {
            TargetVisible = CheckTargetVisible();
        }
    }

    private bool CheckTargetVisible()
    {
        var result = Physics2D.Raycast(transform.position, Target.position - transform.position, viewRadius, visibilityLayer);
        if (result.collider != null)
        {
            return (playerLayerMask & (1 << result.collider.gameObject.layer)) != 0;
        }
        return false;
    }

    public Transform Target 
    { 
        get => target;
        set 
        {
            target = value;
            TargetVisible = false;
        }
    }

    private void DetectTarget()
    {
        if (Target == null)
        {
            CheckIfPlayerInRange();
        }
        else if (Target != null)
        {
            DetectIfOutOfRange();
        }

    }   

    private void DetectIfOutOfRange()
    {
        if (Target == null || Target.gameObject.activeSelf == false || Vector2.Distance(transform.position,Target.position) > viewRadius + 1)
        {
            Target = null;
        }
    }

    private void CheckIfPlayerInRange()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);
        if (collision != null)
        {
            Target = collision.transform;
        }
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionCheckDelay);
        DetectTarget();
        StartCoroutine(DetectionCoroutine());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
