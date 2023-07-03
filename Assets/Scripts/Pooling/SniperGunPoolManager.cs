using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGunPoolManager : PoolManager<BaseProjectileDamage>
{
    public static SniperGunPoolManager Instance;   

    protected override void Awake()
    {
        base.Awake();

        Instance = this;
    }
}
