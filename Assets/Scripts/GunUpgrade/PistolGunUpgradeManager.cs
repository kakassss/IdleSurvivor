using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolGunUpgradeManager : BaseGunUpgradeManager
{
    private int fireOfRateIndex = 0;
    private int radiusOfDetectAreaIndex = 0;
    protected override void Start()
    {
        base.Start();

    }
    public void UpgradeGun()
    {
        fireOfRateMultiplier = fireOfRateMultiplierValues[fireOfRateIndex];
        radiusOfDetectAreaMultiplier = radiusOfDetectAreaMultiplierValues[radiusOfDetectAreaIndex];

        currentGunsData.pistolGunData.radiusOfDetectArea *= radiusOfDetectAreaMultiplier;
        currentGunsData.pistolGunData.fireofRate -= fireOfRateMultiplier;

        CheckMinValue();

        
        SaveUpgradedData(baseGun);
        
        fireOfRateIndex++;
        radiusOfDetectAreaIndex++;
    }

    // private void SaveUpgradedData()
    // {
    //     currentData.gunsData = currentGunsData;
    //     pistolGun.UpgradeGunData(currentData);
    //     DataManager.Instance.SavePlayerData(currentData);
    // }

    private void CheckMinValue()
    {
        if(currentGunsData.pistolGunData.fireofRate <= 0.1f)
        {
            currentGunsData.pistolGunData.fireofRate = 0.1f;
        }
    }
}
