using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunUpgradeManager : BaseGunUpgradeManager
{
    [SerializeField] List<int> projectileCountMultiplierValues;
    private int projectileCountMultiplier;

    private int fireOfRateIndex = 0;
    private int radiusOfDetectAreaIndex = 0;
    private int projectileCountIndex = 0;

    protected override void Start()
    {
        base.Start();
    }

    public void UpgradeGun()
    {
        fireOfRateMultiplier = fireOfRateMultiplierValues[fireOfRateIndex];
        radiusOfDetectAreaMultiplier = radiusOfDetectAreaMultiplierValues[radiusOfDetectAreaIndex];
        projectileCountMultiplier = projectileCountMultiplierValues[projectileCountIndex];


        currentGunsData.shotGunData.radiusOfDetectArea *= radiusOfDetectAreaMultiplier;
        currentGunsData.shotGunData.fireofRate -= fireOfRateMultiplier;
        currentGunsData.shotGunData.projectileCount = projectileCountMultiplier;

        CheckMinValue();

        SaveUpgradedData(baseGun);


        fireOfRateIndex++;
        radiusOfDetectAreaIndex++;
        projectileCountIndex++;
    }

    private void CheckMinValue()
    {
        if(currentGunsData.shotGunData.fireofRate <= 0.1f)
        {
            currentGunsData.shotGunData.fireofRate = 0.1f;
        }
    }
}
