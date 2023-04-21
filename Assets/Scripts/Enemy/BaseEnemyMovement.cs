using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    private BaseEnemyHealth baseEnemyHealth;
    private Rigidbody2D rb;
    private float firstMovementSpeed;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        baseEnemyHealth = GetComponent<BaseEnemyHealth>();
        playerPos = FindPlayerPosition.Instance.player;
        firstMovementSpeed = movementSpeed;
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

        Vector3 speedUp = new Vector3(0.1f,0.1f);

        if(distance <= 0.1f) return; // playerin yanında dursun diye

        if(baseEnemyHealth.knockBackActive) // eğer knockBack triggerlanırsa movementSpeed yarıya insin
        {
            movementSpeed = firstMovementSpeed/ 4; // 0.25 oldu  hızımı 1 sayarsam
            return;  
        } 
        if(movementSpeed < firstMovementSpeed)//datadan gelen movement speede eşit olana kadar hızlandır
        {
            movementSpeed += Time.deltaTime * 1f;// speedin tekrar hızlanma süresi;
            rb.velocity = velocity;
        }
        else // eğer knockback olmamıssa ya da hızı yavasdan tekrar buraya geldiyse
        {
            rb.velocity = velocity;

        }
      
    }

}
