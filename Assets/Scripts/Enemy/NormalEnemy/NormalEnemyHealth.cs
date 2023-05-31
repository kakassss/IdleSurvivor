
public class NormalEnemyHealth : BaseEnemyHealth
{
    private NormalEnemyData data;
    protected override void Start()
    {
        data = DataManager.Instance.gameData.enemyData.normalEnemy;
        currentHealth = data.health;
        knockBackPower = data.knockBack;
        exp = data.exp;
        base.Start();

    }

}
