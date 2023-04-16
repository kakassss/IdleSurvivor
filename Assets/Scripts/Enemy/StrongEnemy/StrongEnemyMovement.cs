using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemyMovement : BaseEnemyMovement
{
    private StrongEnemyData data;
    protected override void Start()
    {
        base.Start();
        data = DataManager.Instance.gameData.enemyData.strongEnemyData; 
        movementSpeed = data.movementSpeed;

        Debug.Log("StrongEnemyspeed" + movementSpeed);
    }
}
