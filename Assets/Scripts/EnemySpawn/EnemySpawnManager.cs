using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] List<BoxCollider2D> spawnAreas;
    private BackGroundExpManager backGroundExpManager;
    private WaveManager waveManager;
    private StagesData stageData;
    private ExpData expData;
    private SpawnData spawnData;


    private float currentSpawnTimer;
    private Stages currentStage;
    List<GameObject> newEnemies = new List<GameObject>();
     
    private void Start()
    {
        backGroundExpManager = GetComponent<BackGroundExpManager>();
        waveManager = GetComponent<WaveManager>();

        stageData = DataManager.Instance.gameData.stagesData;
        expData = DataManager.Instance.gameData.expData;
        spawnData = DataManager.Instance.gameData.spawnData;

        currentStage = waveManager.stages[stageData.currentStage].allWaves[stageData.currentStageWave];
    }

    private Vector2 CalculateSpawnerAreaPos(BoxCollider2D area)
    {
        Vector2 size = area.size;
        Vector2 center = area.offset;

        Vector2 randomPos = new Vector2(Random.Range(center.x - size.x / 2,center.x + size.x / 2),
                                        Random.Range(center.y - size.y / 2,center.y + size.y / 2));
        return randomPos;
    }


    
    private void SpawnWave()
    {
        
        if(newEnemies.Count >= currentStage.wave.totalEnemy)
        {
            CalculateCurrentStageAndWave();
            return; 
        } 

        Debug.Log("stageData.currentStage " + stageData.currentStage);
        Debug.Log("stageData.currentStageWave " + stageData.currentStageWave);

        currentSpawnTimer += Time.deltaTime;

        float enemySpawnRate = (float)currentStage.wave.time / (float)currentStage.wave.totalEnemy;
        int randomEnemy = Random.Range(0,currentStage.wave.enemies.Count);
        

        if(currentSpawnTimer > enemySpawnRate)
        {
            int randomArea = Random.Range(0,spawnAreas.Count);
            Vector2 randomPos = CalculateSpawnerAreaPos(spawnAreas[randomArea]);

            GameObject newEnemy = Instantiate(currentStage.wave.enemies[randomEnemy],randomPos,Quaternion.identity);
            newEnemies.Add(newEnemy);
            currentSpawnTimer = 0;
        }
    }

    private void CalculateCurrentStageAndWave()
    {
        
        if(stageData.currentStageWave + 1 == waveManager.stages[stageData.currentStage].allWaves.Count)
        {

            if(stageData.currentStage + 1 == waveManager.stages.Count) return;

            stageData.currentStage++;
            stageData.currentStageWave = 0;

            newEnemies.Clear();
            currentStage = waveManager.stages[stageData.currentStage].allWaves[stageData.currentStageWave];
            return;

        }

        newEnemies.Clear();
        stageData.currentStageWave++;
        currentStage = waveManager.stages[stageData.currentStage].allWaves[stageData.currentStageWave];
    }

    // private float CalculateSpawnRate(float enemySpawnRate)
    // {   
    //     float half = 4f;
    //     return Mathf.Abs(enemySpawnRate - expData.currentLevel / half);
    // }

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