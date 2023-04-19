using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGun : MonoBehaviour
{
    protected List<GameObject> enemyList = new List<GameObject>();
    protected GameObject projectilePrefab;
    protected float fireOfRate;
    protected float radiusOfDetectArea;
    protected DataManager dataManager;

    protected CircleCollider2D detectArea;
    protected float distance;
    protected float tempTime;
    protected GameObject projectilePistol; // usingForInsantiate


    protected virtual void Start()
    {
        detectArea = GetComponent<CircleCollider2D>();
        detectArea.radius = radiusOfDetectArea;
        DataManager.Instance.LoadPlayerData(); // updatedeki örnek gibi, pek bi işlevi yok hatta virtual olmasına bile şimdilik gerek yok
                                    // ama dursun şimdilik
    }

    protected virtual void Fire()
    {
        if(Time.time >= tempTime)
        {
            tempTime += fireOfRate;
            FireToClosestEnemy();
        }
    }

    protected virtual void FireToClosestEnemy()
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

    protected virtual void InstantiateProjectile(Transform closestEnemyPos, float angle)
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
        DataManager.Instance.SavePlayerData(); // bunu ilerde bi şeyler için kullanabilirsin dursun şimdilik, zaten bu update calısmıyor
        //Fire();
    }

    protected virtual GameObject FindClosestEnemy()
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

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Enemy")) return; 

        enemyList.Add(other.gameObject);    
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
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
