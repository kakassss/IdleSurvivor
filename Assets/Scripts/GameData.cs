using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// ALL DATABASE
[Serializable]
public class GameData
{
    public ProjectilesData projectileData;
    public EnemiesData enemyData;

}

// MAIN PROJECTILE DATABASE
[Serializable]
public class ProjectilesData
{
    public PistolProjectileData pistolData;
    public SniperProjectileData sniperData;
    
}

// MAIN ENEMY DATABASE
[Serializable]
public class EnemiesData
{
    public NormalEnemyData normalEnemy;
    public StrongEnemyData strongEnemyData;
}
//----------------------------ENEMY DATAS----------------------------
[Serializable]
public class NormalEnemyData : BaseEnemyData{}

[Serializable]
public class StrongEnemyData : BaseEnemyData{}

[Serializable]
public class BaseEnemyData
{
    public string enemyName;
    public float health;
    public float movementSpeed;
    public float damage;
}

//----------------------------PROJECTILE DATAS----------------------------
[Serializable]
public class PistolProjectileData : BaseProjectileData{}

[Serializable]
public class SniperProjectileData : BaseProjectileData{}


[Serializable]
public class BaseProjectileData
{
    // silaha göre patlaam efekti veya 
    //merminin arkasından çıkan trail eklenebilir
    public string itemName;
    public float damage;
    public float projectileSpeed;
    public float fireofRate;
    public int passThroghInEnemy;
}