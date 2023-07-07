
public class SniperGunUpgradeManager : BaseGunUpgradeManager
{
    protected override void Start()
    {
        base.Start();
        UpgradeButton(currentGunsData.sniperGunData);
    }

    protected override void UpgradeGun(BaseGunData gunData)
    {
        base.UpgradeGun(gunData);
        CheckMinValue();


        SaveUpgradedData(baseGun);
    }

    private void CheckMinValue()
    {
        if(currentGunsData.sniperGunData.fireofRate <= 0.1f)
        {
            currentGunsData.sniperGunData.fireofRate = 0.1f;
        }
    }
}
