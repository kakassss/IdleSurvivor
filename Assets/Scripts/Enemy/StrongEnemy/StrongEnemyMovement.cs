
public class StrongEnemyMovement : BaseEnemyMovement
{
    private StrongEnemyData data;
    protected override void Start()
    {
        data = DataManager.Instance.gameData.enemyData.strongEnemyData; 
        movementSpeed = data.movementSpeed;
        base.Start();
    }
}
