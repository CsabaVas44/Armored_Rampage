using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public AudioSource audioSource;

    private void OnDestroy()
    {
        Debug.Log($"Collision detected");

        Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        audioSource.Play();
        Destroy(gameObject);

    }
}
