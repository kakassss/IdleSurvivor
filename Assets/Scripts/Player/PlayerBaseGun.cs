using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseGun : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyList = new List<GameObject>();
    private DataManager dataManager;
    private float distance;

    [SerializeField] GameObject projectilePrefab;
    private void Start()
    {
        dataManager = DataManager.Instance;
        dataManager.LoadPlayerData();
    }

    private void FireToClosestEnemy()
    {
        Transform closestEnemyPos = FindClosestEnemy().transform; // find closest enemy position
        Vector3 direction = closestEnemyPos.position - transform.position; // find projectile direction
        float angle = Vector3.Angle(Vector3.right,direction); // Calculate projectile rotation

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(closestEnemyPos.transform.position.y >= 0)
            {
                InstantiateProjectile(closestEnemyPos,angle);
            }
            else if(closestEnemyPos.transform.position.y < 0)
            {
                InstantiateProjectile(closestEnemyPos,angle);
            }
        }
    }

    private void InstantiateProjectile(Transform closestEnemyPos, float angle)
    {   
        GameObject projectilePistol;

        if(closestEnemyPos.transform.position.y >= 0)
        {
            projectilePistol = Instantiate(projectilePrefab,transform.position ,Quaternion.Euler(0,0,angle)); // Instantiating for y >= 0 position enemies
        }
        else if(closestEnemyPos.transform.position.y < 0)
        {
            projectilePistol = Instantiate(projectilePrefab,transform.position ,Quaternion.Euler(0,0,-angle));// Instantiating for y < 0 position enemies
        }
    }

    private void Update() 
    {
        //dataManager.gameData.projectileData.damage +=1;
        dataManager.SavePlayerData();
       
        FireToClosestEnemy();
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
