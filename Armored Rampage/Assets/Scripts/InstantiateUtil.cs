using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUtil : MonoBehaviour
{
    public GameObject objectToInstantiate;

    public void InstatiateObject()
    {
        Instantiate(objectToInstantiate);
    }
}
