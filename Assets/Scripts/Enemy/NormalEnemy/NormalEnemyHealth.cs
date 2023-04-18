using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyHealth : BaseEnemyHealth
{
    private NormalEnemyData data;
    private void Start()
    {
        data = DataManager.Instance.gameData.enemyData.normalEnemy;
        currentHealth = data.health;

    }


}
