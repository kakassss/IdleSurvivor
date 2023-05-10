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
    private WaveManager waveManager;
    private StagesData stageData;
    private ExpData expData;
    private SpawnData spawnData;


    private float tempTime;
    private float spawnRate = 3f;
     
    private void Start()
    {
        backGroundExpManager = GetComponent<BackGroundExpManager>();
        waveManager = GetComponent<WaveManager>();

        stageData = DataManager.Instance.gameData.stagesData;
        expData = DataManager.Instance.gameData.expData;
        spawnData = DataManager.Instance.gameData.spawnData;

        currentStage = waveManager.stages[stageData.currentStage].allStages[stageData.currentStageWave];
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
    private float waveTime;
    private Stages currentStage;
    private void SpawnWave()
    {

        
        CalculateCurrentStageAndWave();
        Debug.Log("stageData.currentStage " + stageData.currentStage);

        Debug.Log("stageData.currentStageWave " + stageData.currentStageWave);


        tempTime += Time.deltaTime;
        waveTime += Time.deltaTime;

        float enemySpawnRate = currentStage.wave.time / currentStage.wave.totalEnemy;
        int randomEnemy = Random.Range(0,currentStage.wave.enemies.Count);
        
        if(tempTime >= enemySpawnRate)
        {
            int randomArea = Random.Range(0,spawnAreas.Count);
            Vector2 randomPos = CalculateSpawnerAreaPos(spawnAreas[randomArea]);

            GameObject newEnemy = Instantiate(currentStage.wave.enemies[randomEnemy],randomPos,Quaternion.identity);

            tempTime = 0;
        }
    }

    private void CalculateCurrentStageAndWave()
    {
        if(waveTime >= currentStage.wave.time)
        {

            if(stageData.currentStageWave > waveManager.stages[stageData.currentStage].allStages.Count)
            {
                stageData.currentStage++;
                stageData.currentStageWave = 0;

                currentStage = waveManager.stages[stageData.currentStage].allStages[stageData.currentStageWave];
                return;
            }

            stageData.currentStageWave++;

            currentStage = waveManager.stages[stageData.currentStage].allStages[stageData.currentStageWave];
        }
    }

    private float CalculateSpawnRate(float enemySpawnRate)
    {   
        float half = 4f;
        return Mathf.Abs(enemySpawnRate - expData.currentLevel / half);
    }

    private void Update() 
    {
        SpawnWave();
        //SpawnEnemy(spawnData.normalEnemySpawnRate,normalEnemy,spawnData.normalEnemyMaxSpawnLevel);    
    }

}


public enum EnemyTypes
{
    NormalEnemy = 0,
    StrongEnemy,
    SpeedEnemy,
    Boss1Enemy
}