
public class NormalEnemyMovement : BaseEnemyMovement
{
    private NormalEnemyData data;
    protected override void Start()
    {
        data = DataManager.Instance.gameData.enemyData.normalEnemy; 
        movementSpeed = data.movementSpeed;
        base.Start();

    }
    
}
