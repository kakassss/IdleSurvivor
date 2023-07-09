
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

        CheckMinValue_FireOfRate(gunData,0.2f);
        CheckMinValue_RadiousOfDetectArea(gunData,20f);
        projectileCountIndex++;
        
        SaveUpgradedData(baseGun);
    }
    
}
