using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseGun : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyList = new List<GameObject>();
    private CircleCollider2D targetableArea;
    private float distance;
    private DataManager dataManager;
    private void Start()
    {
        dataManager = DataManager.Instance;
        targetableArea = GetComponent<CircleCollider2D>();
        dataManager.LoadPlayerData();
        //Debug.Log("data" + dataManager.gameData.projectileData.damage);    
    }

    private void FireToClosestEnemy()
    {
        Transform closestEnemyPos = FindClosestEnemy().transform;




    }
    GameObject aa;
    private void Update() {
       
       
             //dataManager.gameData.projectileData.damage +=1;
             dataManager.SavePlayerData();
       
        // aa = FindClosestEnemy();
        // Debug.Log("ss" + aa.name);
    }

    private GameObject FindClosestEnemy()
    {
        if(enemyList.Count == 0)
        {
            Debug.Log("No Enemy Found");
            return null;
        }

        float closestDistance = float.MaxValue;
        GameObject closestEnemy = null;

        for (int i = 0; i < enemyList.Count; i++)
        {
            distance = Vector3.Distance(transform.position,enemyList[i].transform.position);
            
            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemyList[i];
            }
      
        }

        return closestEnemy;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Enemy")) return; 

        enemyList.Add(other.gameObject);    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Enemy")) return; 

        enemyList.Remove(other.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,2);    
    }
}
