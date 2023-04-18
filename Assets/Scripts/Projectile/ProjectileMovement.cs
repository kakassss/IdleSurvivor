using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private PistolProjectileData data;
    private Rigidbody2D rigidbody2D;
    private void Start()
    {
        data = DataManager.Instance.gameData.projectileData.pistolData;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(rigidbody2D != null)
        {
            rigidbody2D.velocity = transform.right * data.projectileSpeed;
        }           
    }
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
