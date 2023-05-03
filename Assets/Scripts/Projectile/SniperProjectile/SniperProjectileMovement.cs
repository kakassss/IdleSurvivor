using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperProjectileMovement : ProjectileMovement
{
    private SniperProjectileData data;
    protected override void Start()
    {
        data = DataManager.Instance.gameData.projectileData.sniperData;
        base.Start();

        Movement();    
    }

    protected override void Movement()
    {
        rigidbody2D.AddForce(transform.right * data.projectileSpeed,ForceMode2D.Impulse);
    }


}
