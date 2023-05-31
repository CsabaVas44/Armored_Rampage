using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{

    public UnityEvent TutorialFirst;
    public UnityEvent TutorialAfter;
    void Start()
    {
        if(DataHolder.PlayingFor == 0) //oof
        {
            TutorialFirst.Invoke();
        }
        else
        {
            TutorialAfter.Invoke();
        }
    }
    public void closeTutorialWindow()
    {
        DataHolder.PlayingFor++;
        Debug.Log("DataHolder: " + DataHolder.PlayingFor);
        gameObject.SetActive(false);
    }

}
