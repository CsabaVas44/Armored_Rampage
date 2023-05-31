using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public Animator transition;
    public float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNextLevel(string nextLevel)
    {
        StartCoroutine(LoadLevel(nextLevel));
    }

    IEnumerator LoadLevel(string nextLevel)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(nextLevel);
    }
}
