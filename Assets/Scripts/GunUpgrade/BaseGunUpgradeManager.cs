using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGunUpgradeManager : MonoBehaviour
{
    public BaseGun baseGun;
    protected GameData currentData;
    protected GunsData currentGunsData;

    public List<float> fireOfRateMultiplierValues;
    public List<float> radiusOfDetectAreaMultiplierValues;

    protected float fireOfRateMultiplier;
    protected float radiusOfDetectAreaMultiplier;

    protected virtual void Start()
    {
        currentData = DataManager.Instance.gameData;
        currentGunsData = currentData.gunsData;
    }

    protected void SaveUpgradedData(BaseGun gun)
    {
        currentData.gunsData = currentGunsData;
        gun.UpgradeGunData(currentData);
        DataManager.Instance.SavePlayerData(currentData);
    }
}
