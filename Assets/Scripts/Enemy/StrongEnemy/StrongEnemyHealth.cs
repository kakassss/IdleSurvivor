using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemyHealth : BaseEnemyHealth
{
    private StrongEnemyData data;
   
    protected override void Start()
    {
        base.Start();
        data = DataManager.Instance.gameData.enemyData.strongEnemyData;
        currentHealth = data.health;
        knockBackPower = data.knockBack;

        Debug.Log("StrongEnemyHealth " + currentHealth);
    }
}
