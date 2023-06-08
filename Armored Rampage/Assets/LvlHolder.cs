using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlHolder : MonoBehaviour
{
    public Text turretLvl;
    public Text hullLvl;
    public Text trackLvl;

    private void Update()
    {
        turretLvl.text = $"Turret Level: {DataHolder.TurretLvl+1}/3";
        hullLvl.text = $"Hull Level: {DataHolder.HullLvl+1}/3";
        trackLvl.text = $"Track Level: {DataHolder.TrackLvl+1}/3";
    }
}
