using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunPoolManager : PoolManager<BaseProjectileDamage>
{
    public static ShotGunPoolManager Instance;   

    protected override void Awake()
    {
        base.Awake();

        Instance = this;
    }
}
