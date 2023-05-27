using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public Text moneyCounter;

    private void Update()
    {
        moneyCounter.text = $"Money Left: ${DataHolder.Money}";
    }

}
