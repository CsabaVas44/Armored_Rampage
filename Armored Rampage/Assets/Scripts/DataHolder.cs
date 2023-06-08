using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static int Money { get; set; }

    public static int TankLevel { get; set; }
    public static int PlayingFor { get; set; }
    public static int TrackLvl { get; set; }
    public static int HullLvl { get; set; }
    public static int TurretLvl { get; set; } // reload + bullet count


}
