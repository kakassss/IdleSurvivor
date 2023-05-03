using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCollider : MonoBehaviour
{
    private EdgeCollider2D edgeCollider;
    private Camera camera;
    private void Awake()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();    
        camera = Camera.main;


        CreateEdgeCollider();
    }

    private void CreateEdgeCollider()
    {
        List<Vector2> edges = new List<Vector2>();
        edges.Add(camera.ScreenToWorldPoint(Vector2.zero));
        edges.Add(camera.ScreenToWorldPoint(new Vector2(Screen.width,0)));
        edges.Add(camera.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height)));
        edges.Add(camera.ScreenToWorldPoint(new Vector2(0,Screen.height)));
        edges.Add(camera.ScreenToWorldPoint(Vector2.zero));
        edgeCollider.SetPoints(edges);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("SniperProjectile")) return;

        var collerderRB = other.GetComponent<Rigidbody2D>();

        RaycastHit2D[] hit2D = Physics2D.RaycastAll(other.transform.position,collerderRB.velocity);

        Vector2 contantPoint = hit2D[1].point;

        Vector2 normal = Vector2.Perpendicular(contantPoint - GetClosestPoint(other.transform.position)).normalized;

        collerderRB.velocity = Vector2.Reflect(collerderRB.velocity,normal);

        float angle = Mathf.Atan2(collerderRB.velocity.y, collerderRB.velocity.x) * Mathf.Rad2Deg;
        other.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private Vector2 GetClosestPoint(Vector2 position)
    {
        Vector2[] points = edgeCollider.points;
        float shortestDistance = Vector2.Distance(position,points[0]);
        Vector2 closestPoints = points[0];

        foreach (Vector2 point in points)
        {
            if(Vector2.Distance(position,point) < shortestDistance)
            {
                shortestDistance = Vector2.Distance(position,point);
                closestPoints = point;
            }
        }
        return closestPoints;
    }


}
