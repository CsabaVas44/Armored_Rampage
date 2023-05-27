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
        //DataHolder.Money = DataHolder.Money + 1000;
        SceneManager.LoadScene(1);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void UpgradeButton()
    {
        //DataHolder.Money = DataHolder.Money + 1000;
        SceneManager.LoadScene(4);
    }
    public void SelectorButton()
    {
        SceneManager.LoadScene(1);
    }


}
