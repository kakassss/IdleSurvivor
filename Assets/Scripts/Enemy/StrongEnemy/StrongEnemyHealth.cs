using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemyHealth : BaseEnemyHealth
{
    private StrongEnemyData data;
    private void Start()
    {
        data = DataManager.Instance.gameData.enemyData.strongEnemyData;
        currentHealth = data.health;

        Debug.Log("StrongEnemyHealth " + currentHealth);
    }
}
