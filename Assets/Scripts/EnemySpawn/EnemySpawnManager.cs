using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] List<BoxCollider2D> spawnAreas;
    [SerializeField] List<GameObject> enemyTypes;

    [SerializeField] GameObject normalEnemy;
    [SerializeField] GameObject strongEnemy;

    private BackGroundExpManager backGroundExpManager;
    private ExpData expData;
    private SpawnData spawnData;


    private float tempTime;
    private float spawnRate = 3f;
     
    private void Start()
    {
        backGroundExpManager = GetComponent<BackGroundExpManager>();    
        expData = DataManager.Instance.gameData.expData;
        spawnData = DataManager.Instance.gameData.spawnData;
    }

    private Vector2 CalculateSpawnerAreaPos(BoxCollider2D area)
    {
        Vector2 size = area.size;
        Vector2 center = area.offset;

        Vector2 randomPos = new Vector2(Random.Range(center.x - size.x / 2,center.x + size.x / 2),
                                        Random.Range(center.y - size.y / 2,center.y + size.y / 2));
        return randomPos;
    }

    private void SpawnEnemy(float enemySpawnRate,GameObject enemy,int enemyMaxSpawnLevel)
    {
        tempTime += Time.deltaTime;
        enemySpawnRate = CalculateSpawnRate(enemySpawnRate);
        if(tempTime >= enemySpawnRate)
        {
            int randomArea = Random.Range(0,spawnAreas.Count);
            Vector2 randomPos = CalculateSpawnerAreaPos(spawnAreas[randomArea]);

            if(expData.currentLevel <= enemyMaxSpawnLevel)
            {
                GameObject newEnemy = Instantiate(enemy,randomPos,Quaternion.identity);
            }

            tempTime = 0;
        }
        
    }

    private float CalculateSpawnRate(float enemySpawnRate)
    {   
        float half = 4f;
        return Mathf.Abs(enemySpawnRate - expData.currentLevel / half);
    }

    private void Update() 
    {
        SpawnEnemy(spawnData.normalEnemySpawnRate,normalEnemy,spawnData.normalEnemyMaxSpawnLevel);    
    }

}


public enum EnemyTypes
{
    NormalEnemy = 0,
    StrongEnemy,
    SpeedEnemy,
    Boss1Enemy
}