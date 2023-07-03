using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunPoolManager : PoolManager<BaseProjectileDamage>
{
    public static PlayerGunPoolManager Instance;   

    protected override void Awake()
    {
        base.Awake();

        Instance = this;
    }
}
