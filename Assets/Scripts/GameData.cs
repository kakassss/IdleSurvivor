using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// ---------------------------ALL DATABASE---------------------------
[Serializable]
public class GameData
{
    public ProjectilesData projectileData;
    public EnemiesData enemyData;
    public GunsData gunsData;

}
// ---------------------------------------------------------------

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

// MAIN GUN DATABASE
[Serializable]
public class GunsData
{
    public PistolGunData pistolGunData;
    public SniperGunData sniperGunData;
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
    public float collectMoney;
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
    public string projectileName;
    public float damage;
    public float projectileSpeed;
    public int passThroghInEnemy;
}

//----------------------------GUN DATAS----------------------------

[Serializable]
public class PistolGunData : BaseGunData{}

[Serializable]
public class SniperGunData : BaseGunData{}

[Serializable]
public class BaseGunData
{
    public string gunName;
    public float fireofRate;
    public GameObject projectilePrefab;
}