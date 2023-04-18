using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolGun : BaseGun
{
    private PistolGunData data;


    protected override void Start()
    {
        data = DataManager.Instance.gameData.gunsData.pistolGunData;

        fireOfRate = data.fireofRate;
        projectilePrefab = data.projectilePrefab;
        base.Start();
    }


    private void Update()
    {
        Fire(); 
    }
}
