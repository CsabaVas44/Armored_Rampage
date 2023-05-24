using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    GameObject[] enemies;
    int counterBefore;
    public Text enemyCounter;
    public UnityEvent OnAllEnemiesDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        counterBefore = enemies.Length;
        TextChanged();
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (enemies.Length != counterBefore)
        {
            TextChanged();
            counterBefore--;
        }
        if(enemies.Length == 0)
        {
            OnAllEnemiesDestroyed.Invoke();
        }

    }
    void TextChanged()
    {
        enemyCounter.text = $"Enemies Alive: {enemies.Length}";
    }
}
