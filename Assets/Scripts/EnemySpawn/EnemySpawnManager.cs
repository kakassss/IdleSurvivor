using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] List<BoxCollider2D> spawnAreas;
    [SerializeField] List<GameObject> enemyTypes;

    private BackGroundExpManager backGroundExpManager;
    private ExpData expData;


    private float tempTime;
    private float spawnRate = 3f;
     
    private void Start()
    {
        backGroundExpManager = GetComponent<BackGroundExpManager>();    
        expData = DataManager.Instance.gameData.expData;
    }

    private Vector2 CalculateSpawnerAreaPos(BoxCollider2D area)
    {
        Vector2 size = area.size;
        Vector2 center = area.offset;

        Vector2 randomPos = new Vector2(Random.Range(center.x - size.x / 2,center.x + size.x / 2),
                                        Random.Range(center.y - size.y / 2,center.y + size.y / 2));
        return randomPos;
    }

    private void SpawnEnemy()
    {
        tempTime += Time.deltaTime;
        if(tempTime >= spawnRate)
        {
            int randomArea = Random.Range(0,spawnAreas.Count);
            Vector2 randomPos = CalculateSpawnerAreaPos(spawnAreas[randomArea]);
            if(expData.currentLevel <=5)
            {
                GameObject randomEnemy = enemyTypes[Random.Range(0,0)];
                GameObject enemy = Instantiate(randomEnemy,randomPos,Quaternion.identity);
            }

            if(expData.currentLevel >=10)
            {
                GameObject randomEnemy = enemyTypes[Random.Range(0,1)];
                GameObject enemy = Instantiate(randomEnemy,randomPos,Quaternion.identity);
            }

            if(expData.currentLevel >=15)
            {
                GameObject randomEnemy = enemyTypes[Random.Range(0,2)];
                GameObject enemy = Instantiate(randomEnemy,randomPos,Quaternion.identity);
            }

            tempTime = 0;
        }
        
    }

    private void Update() 
    {
        SpawnEnemy();    
    }

}


public enum EnemyTypes
{
    NormalEnemy = 0,
    StrongEnemy,
    SpeedEnemy,
    Boss1Enemy
}