using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGun : MonoBehaviour
{
    protected List<GameObject> enemyList = new List<GameObject>();
    protected DataManager dataManager;
    
    protected GameObject projectilePrefab;
    protected float fireOfRate;
    protected float distance; // find cloestEnemyPos

    protected float radiusOfDetectArea;
    protected CircleCollider2D detectArea;
    protected float tempTime; // using with fireOfRate
    protected GameObject projectilePistol; // usingForInsantiate

    //Closest Enemy Pos with find projectile rotation
    protected Transform closestEnemyPos;
    protected Vector3 direction;
    protected float angle;

    private void Awake() 
    {
        detectArea = GetComponent<CircleCollider2D>();
    }

    protected virtual void Fire()
    {
        tempTime += Time.deltaTime;
        if(tempTime >= fireOfRate)
        {
            FireToClosestEnemy();
            tempTime = 0f;
        }
    }

    protected void CalculateClosestEnemyPos()
    {
        closestEnemyPos = FindClosestEnemy().transform; // find closest enemy position
        direction = closestEnemyPos.position - transform.position; // find projectile direction
        angle = Vector3.Angle(Vector3.right,direction); // Calculate projectile rotation
    }

    protected void FireToClosestEnemy()
    {
        CalculateClosestEnemyPos();

        if(closestEnemyPos == null) return;

        if(closestEnemyPos.transform.position.y >= 0)
        {
            InstantiateProjectile();
        }
        else if(closestEnemyPos.transform.position.y < 0)
        {
            InstantiateProjectile();
        }
    }

    protected void PlayerInput()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    protected virtual GameObject FindClosestEnemy()
    {
        if(enemyList.Count == 0)
        {
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
    
    // Use this gun circle area gizmos
    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.blue;
    //     Gizmos.DrawWireSphere(transform.position,2);    
    // }

    protected abstract void InstantiateProjectile(); // abstract yapmamım sebebi shotgun gibi etrafa sacılan projecileların olması
    protected abstract void Update();
    protected abstract void Start();
}
