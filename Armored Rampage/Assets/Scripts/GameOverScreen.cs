using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    public int thisLevelIndex;

    public void Setup()
    {
        gameObject.SetActive(true);
    }


    public void RestartButton()
    {
        SceneManager.LoadScene(thisLevelIndex);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
}
