using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGun : BaseGun
{
    private SniperGunData data;

    protected override void Start()
    {
        data = DataManager.Instance.gameData.gunsData.sniperGunData;

        fireOfRate = data.fireofRate;
        projectilePrefab = data.projectilePrefab;
        base.Start();
    }

    private void Update()
    {
        Fire();    
    }
}
