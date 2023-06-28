using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : PoolManager<BaseProjectileDamage>
{
    public static BulletPoolManager Instance;   

    protected override void Awake()
    {
        base.Awake();

        Instance = this;
    }



    
}
