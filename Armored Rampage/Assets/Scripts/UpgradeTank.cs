using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeTank : MonoBehaviour
{

    private void Start()
    {
        DataHolder.Money = DataHolder.Money + 2000;
    }

    public void UpgradeTurret()
    {
        if (DataHolder.Money >= 1000 && DataHolder.TurretLvl <= 1)
        {
            DataHolder.TurretLvl++;
            DataHolder.Money = DataHolder.Money - 1000;
        }
    }

    public void UpgradeHull()
    {
        if (DataHolder.Money >= 500 && DataHolder.HullLvl <= 1)
        {
            DataHolder.HullLvl++;
            DataHolder.Money = DataHolder.Money - 500;
        }
    }

    public void UpgradeTrack()
    {
        if (DataHolder.Money >= 500 && DataHolder.TrackLvl <= 1)
        {
            DataHolder.TrackLvl++;
            DataHolder.Money = DataHolder.Money - 500;
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
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
