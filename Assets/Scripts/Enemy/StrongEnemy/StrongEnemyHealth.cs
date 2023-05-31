
public class StrongEnemyHealth : BaseEnemyHealth
{
    private StrongEnemyData data;
   
    protected override void Start()
    {
        base.Start();
        data = DataManager.Instance.gameData.enemyData.strongEnemyData;
        currentHealth = data.health;
        knockBackPower = data.knockBack;
        exp = data.exp;
    }
}
