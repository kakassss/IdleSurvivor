
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

        CheckMinValue_FireOfRate(gunData,0.2f);
        CheckMinValue_RadiousOfDetectArea(gunData,20f);

        SaveUpgradedData(baseGun);
    }
}
