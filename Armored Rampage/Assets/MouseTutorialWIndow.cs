using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseTutorialWIndow : MonoBehaviour
{
    public UnityEvent MouseOpen;
    private void Update()
    {
        MouseTutorialSpawn();
    }

    private void MouseTutorialSpawn()
    {
        if (DataHolder.PlayingFor == 1)
        {
            MouseOpen.Invoke();
        }
    }
    public void closeTutorialWindow()
    {
        DataHolder.PlayingFor++;
        Debug.Log(DataHolder.PlayingFor);
        gameObject.SetActive(false);
    }
}
