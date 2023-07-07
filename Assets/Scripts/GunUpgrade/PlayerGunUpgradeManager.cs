using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunUpgradeManager : BaseGunUpgradeManager
{
    protected override void Start()
    {
        base.Start();
        UpgradeButton(currentGunsData.playerGunData);
    }

    protected override void UpgradeGun(BaseGunData gunData)
    {
        base.UpgradeGun(gunData);
        CheckMinValue();


        SaveUpgradedData(baseGun);
    }

    private void CheckMinValue()
    {
        if(currentGunsData.playerGunData.fireofRate <= 0.1f)
        {
            currentGunsData.playerGunData.fireofRate = 0.1f;
        }
    }
}
