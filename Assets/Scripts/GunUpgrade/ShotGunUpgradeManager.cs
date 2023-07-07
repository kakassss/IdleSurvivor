
using System.Collections.Generic;
using UnityEngine;


public class ShotGunUpgradeManager : BaseGunUpgradeManager
{
    [SerializeField] List<int> projectileCountMultiplierValues;
    private int projectileCountMultiplier;
    private int projectileCountIndex = 0;


    protected override void Start()
    {
        base.Start();
        UpgradeButton(currentGunsData.shotGunData);
    }

    protected override void UpgradeGun(BaseGunData gunData)
    {
        base.UpgradeGun(gunData);

        projectileCountMultiplier = projectileCountMultiplierValues[projectileCountIndex];
        currentGunsData.shotGunData.projectileCount = projectileCountMultiplier;


        CheckMinValue();
        projectileCountIndex++;
        
        SaveUpgradedData(baseGun);
    }
    
    private void CheckMinValue()
    {
        if(currentGunsData.shotGunData.fireofRate <= 0.15f)
        {
            currentGunsData.shotGunData.fireofRate = 0.1f;
        }
    }
}
