using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGunUpgradeManager : MonoBehaviour
{
    protected GameData currentData;
    protected GunsData currentGunsData;

    protected float fireOfRateMultiplier;
    protected float radiusOfDetectAreaMultiplier;

    protected virtual void Start()
    {
        currentData = DataManager.Instance.gameData;
        currentGunsData = currentData.gunsData;
    }



}
