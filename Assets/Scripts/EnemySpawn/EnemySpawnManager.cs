using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] List<BoxCollider2D> spawnAreas;
    [SerializeField] List<GameObject> enemyTypes;

    private BackGroundExpManager backGroundExpManager;

    private void Start()
    {
        backGroundExpManager = GetComponent<BackGroundExpManager>();    
    }

    

}
