using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGeneratorRandomPositionUtil : MonoBehaviour
{
    public GameObject objectPrefab;
    public float radius = 0.2f;

    public Vector2 GetRandomPosition()
    {
        return Random.insideUnitCircle * radius + (Vector2)transform.position;
    }

    public Quaternion Random2DRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    public void CreateObject()
    {
        Vector2 position = GetRandomPosition();
        GameObject impactObject = GetObject();
        impactObject.transform.position = position;
        impactObject.transform.rotation = Random2DRotation();
    }

    public virtual GameObject GetObject()
    {
        return Instantiate(objectPrefab);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}