using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeTank : MonoBehaviour
{

    private void Start()
    {
        DataHolder.Money = DataHolder.Money + 1000;
    }

    public void UpgradeTankLevel()
    {
        if (DataHolder.Money >= 1000 && DataHolder.TankLevel <= 1)
        {
            DataHolder.TankLevel++;
            DataHolder.Money = DataHolder.Money - 1000;
        }
    }
    public void IncreaseTankHp()
    {
        //Lorem Ipsum
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
