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

    public void UpgradeTank500() // g�ny megold�s de a vide�ra j� --> nem upgradel csak levonja a dell�t, azt megoldjuk okosba v�g�ssal hogy gyorsabb a tank xd
    {
        if (DataHolder.Money >= 500 && DataHolder.TankLevel <= 1)
        {
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
