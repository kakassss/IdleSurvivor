using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private ProjectileDataHandler handler;
    private Rigidbody2D rigidbody2D;
    private void Start()
    {
        handler = GetComponent<ProjectileDataHandler>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(rigidbody2D != null)
        {
            rigidbody2D.velocity = transform.right * handler.projectileData.projectileSpeed;
        }           
    }
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
