using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveManager : MonoBehaviour
{
    public List<ListWrapper> stages;
}

[Serializable]
public class ListWrapper
{
    public List<Stages> allStages;
}

[Serializable]
public class Stages
{
    public Waves wave; 
}

[Serializable]
public class Waves
{
    public int time;
    public int totalEnemy;
    public int spawnRate;
    public int enemyPowerMultiplier;
    public List<GameObject> enemies;
}