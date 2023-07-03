using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolGunPoolManager : PoolManager<BaseProjectileDamage>
{
    public static PistolGunPoolManager Instance;   

    protected override void Awake()
    {
        base.Awake();

        Instance = this;
    }



    
}
