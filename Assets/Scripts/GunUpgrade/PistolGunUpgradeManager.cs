using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolGunUpgradeManager : BaseGunUpgradeManager
{
    [SerializeField] PistolGun pistolGunData;

    [SerializeField] List<float> fireOfRateMultiplierValues;
    [SerializeField] List<float> radiusOfDetectAreaMultiplierValues;

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

        
        SaveUpgradedData();
        
        fireOfRateIndex++;
        radiusOfDetectAreaIndex++;
    }

    private void SaveUpgradedData()
    {
        currentData.gunsData = currentGunsData;
        pistolGunData.UpgradeGunData(currentData);
        DataManager.Instance.SavePlayerData(currentData);
    }

    private void CheckMinValue()
    {
        if(currentGunsData.pistolGunData.fireofRate <= 0.1f)
        {
            currentGunsData.pistolGunData.fireofRate = 0.1f;
        }
    }
}
