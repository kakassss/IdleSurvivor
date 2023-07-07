
public class PistolGunUpgradeManager : BaseGunUpgradeManager
{
    protected override void Start()
    {
        base.Start();
        UpgradeButton(currentGunsData.pistolGunData);
    }

    protected override void UpgradeGun(BaseGunData gunData)
    {
        base.UpgradeGun(gunData);
        CheckMinValue();


        SaveUpgradedData(baseGun);
    }

    private void CheckMinValue()
    {
        if(currentGunsData.pistolGunData.fireofRate <= 0.1f)
        {
            currentGunsData.pistolGunData.fireofRate = 0.1f;
        }
    }
}
