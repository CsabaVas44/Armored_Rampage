using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private GameObject _startTrans;
    [SerializeField] private GameObject _endTrans;

    
    public void PlaButtonPressed()
    {
        _startTrans.SetActive(true);
        _startTrans.GetComponent<Animation>().Play();
        Thread.Sleep(1000);
        Debug.Log("start ended");
        _startTrans.SetActive(false);
        Debug.Log("end started");
        _endTrans.SetActive(true);
        _endTrans.GetComponent<Animation>().Play();
        Thread.Sleep(1000);
        _endTrans.SetActive(false);
        Debug.Log("end ended");
        SceneManager.LoadScene("LevelSelection");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
