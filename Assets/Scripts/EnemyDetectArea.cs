using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectArea : MonoBehaviour
{
    public static EnemyDetectArea Instance;

    private void Awake()
    {
        Instance = this;    
    }
    public List<GameObject> enemyList = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Enemy")) return;

        enemyList.Add(other.gameObject);    
        //DebugEnemyList();
    }

    public void RemoveEnemyQueue(GameObject enemy)
    {
        enemyList.Remove(enemy);
    }


    private void DebugEnemyList()
    {
        Debug.Log("enemy count: " + enemyList.Count);
    }    

}
