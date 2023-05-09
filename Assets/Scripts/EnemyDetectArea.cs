using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectArea : MonoBehaviour
{
    [SerializeField] LayerMask wallLayer;
    private CircleCollider2D circleCollider2D;
    private void Start() 
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("SniperProjectile")) return;

        var collerderRB = other.GetComponent<Rigidbody2D>();
        
        RaycastHit2D hit2D = Physics2D.Raycast(other.transform.position,collerderRB.velocity,wallLayer);
        RaycastHit2D hit2D1 = Physics2D.Raycast(other.transform.position,collerderRB.velocity + collerderRB.velocity /4,wallLayer);
        Debug.DrawRay(other.transform.position,collerderRB.velocity,Color.blue,0.1f);
        Vector2 contantPoint = hit2D.point;
        
        Vector2 normal = Vector2.Perpendicular(circleCollider2D.ClosestPoint(contantPoint)).normalized;

        collerderRB.velocity = Vector2.Reflect(collerderRB.velocity ,normal);

        float angle = Mathf.Atan2(collerderRB.velocity.y, collerderRB.velocity.x) * Mathf.Rad2Deg;
        other.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    

}
