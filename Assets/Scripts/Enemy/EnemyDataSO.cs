using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New enemy", menuName = "Enemy/Enemy")]
public class EnemyDataSO : ScriptableObject
{
    public string enemyName;
    public float health;
    public float movementSpeed;
    public float damage;
    
}
