using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Yapılış amacı başka karakterlerin belki daha farklı
//movement'a ihtiyacı olabilir diye
public abstract class BaseEnemyMovement : MonoBehaviour
{
    protected GameObject playerPos;
    protected float movementSpeed;

    //Movement 
    protected Vector2 direction ; // gidilecek -+ yön
    protected float distance; // aradaki uzaklık
    protected Vector3 velocity;
    protected virtual void Start()
    {
        playerPos = FindPlayerPosition.Instance.player;
    }
    protected virtual void Update()
    {
        Movement();
    }
    protected virtual void Movement()
    {
        direction = playerPos.transform.position - transform.position; // gidilecek -+ yön
        distance = direction.magnitude; // aradaki uzaklık
        velocity = direction.normalized * movementSpeed; // gidilen hız 1 * x


        if(distance <= 0.1f) return; 

        transform.position += velocity * Time.deltaTime; 
          
    }

}
