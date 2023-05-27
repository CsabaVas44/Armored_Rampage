using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTankSelector : MonoBehaviour
{

    public UnityEvent TankLevel0;
    public UnityEvent TankLevel1;
    public UnityEvent TankLevel2;

    public void Start()
    {
        if(DataHolder.TankLevel == 0)
        {
            TankLevel0.Invoke();
        }
        if (DataHolder.TankLevel == 1)
        {
            TankLevel1.Invoke();
        }
        if (DataHolder.TankLevel == 2)
        {
            TankLevel2.Invoke();
        }

    }

   


}
