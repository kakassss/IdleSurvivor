using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class BaseGunUpgradeManager : MonoBehaviour
{
    public BaseGun baseGun;
    protected GameData currentData;
    protected GunsData currentGunsData;

    public Button upgradeButton;
    public List<float> fireOfRateMultiplierValues;
    public List<float> radiusOfDetectAreaMultiplierValues;

    protected int fireOfRateIndex = 0;
    protected int radiusOfDetectAreaIndex = 0;

    protected float fireOfRateMultiplier;
    protected float radiusOfDetectAreaMultiplier;

    protected virtual void Start()
    {
        currentData = DataManager.Instance.gameData;
        currentGunsData = currentData.gunsData;
    }

    protected virtual void UpgradeButton(BaseGunData gunsData)
    {
        upgradeButton.onClick.AddListener(delegate{UpgradeGun(gunsData);});
    }

    protected virtual void UpgradeGun(BaseGunData gunData)
    {
        fireOfRateMultiplier = fireOfRateMultiplierValues[fireOfRateIndex];
        radiusOfDetectAreaMultiplier = radiusOfDetectAreaMultiplierValues[radiusOfDetectAreaIndex];

        gunData.radiusOfDetectArea *= radiusOfDetectAreaMultiplier;
        gunData.fireofRate -= fireOfRateMultiplier;


        fireOfRateIndex++;
        radiusOfDetectAreaIndex++;

    }

    protected void SaveUpgradedData(BaseGun gun)
    {
        currentData.gunsData = currentGunsData;
        gun.UpgradeGunData(currentData);
        DataManager.Instance.SavePlayerData(currentData);
    }
}
