using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseGun : MonoBehaviour
{
    [SerializeField] protected List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] protected GameObject projectilePrefab;
    private DataManager dataManager;
    private PistolProjectileData data;

    private GameObject projectilePistol; // usingForInsantiate
    private float distance;
    private float fireOfRate;
    private float tempTime;

    private void Start()
    {
        dataManager = DataManager.Instance;
        data = dataManager.gameData.projectileData.pistolData;
        fireOfRate = data.fireofRate;
        tempTime = fireOfRate;


        dataManager.LoadPlayerData();
    }

    private void Fire()
    {
        if(Time.time >= tempTime)
        {
            tempTime += fireOfRate;
            FireToClosestEnemy();
        }
    }

    private void FireToClosestEnemy()
    {
        Transform closestEnemyPos = FindClosestEnemy().transform; // find closest enemy position
        Vector3 direction = closestEnemyPos.position - transform.position; // find projectile direction
        float angle = Vector3.Angle(Vector3.right,direction); // Calculate projectile rotation

        if(closestEnemyPos == null) return;

        if(closestEnemyPos.transform.position.y >= 0)
        {
            InstantiateProjectile(closestEnemyPos,angle);
        }
        else if(closestEnemyPos.transform.position.y < 0)
        {
            InstantiateProjectile(closestEnemyPos,angle);
        }

    }

    private void InstantiateProjectile(Transform closestEnemyPos, float angle)
    {   
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
        Fire();
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
