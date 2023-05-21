using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    Scene scene;
    
    void Start()
    {
        gameObject.SetActive(true);
    }

    public void NextLevelButton()
    {
        scene = SceneManager.GetActiveScene();
        int thisLevelScene = scene.buildIndex;
        SceneManager.LoadScene(thisLevelScene + 1);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void UpgradeButton()
    {
        SceneManager.LoadScene(0);
    }
    public void SelectorButton()
    {
        SceneManager.LoadScene(1);
    }


}
