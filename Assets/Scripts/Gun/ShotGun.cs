using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : BaseGun
{
    private ShotGunData data;
    
    [SerializeField] float[] projectilAngles;
    [SerializeField] GameObject shotgunPrefab;
    private int projectileCount;

    protected override void Start()
    {

        base.Start();

        data = DataManager.Instance.gameData.gunsData.shotGunData;
        fireOfRate = data.fireofRate;
        projectilePrefab = shotgunPrefab;
        radiusOfDetectArea = data.radiusOfDetectArea;
        projectileCount = data.projectileCount;

        projectilAngles = new float[projectileCount];
    }

    protected override void InstantiateProjectile()
    {
        if(closestEnemyPos.transform.position.y >= 0)
        {
            CalculateEveryProjectileAngle(angle);
        }
        else if(closestEnemyPos.transform.position.y < 0)
        { 
            CalculateEveryProjectileAngle(-angle);               
        }
    }

    private void CalculateEveryProjectileAngle(float angle1)
    {  
        if(projectileCount % 2 == 0)
        {
            CalculateEvenProjectile(angle1);
        }
        else if(projectileCount % 2 == 1)
        {
            CalculateOddProjectile(angle1);
        }
        else
        {
            return;
        }

        for (int i = 0; i < projectileCount; i++) // mantık söyle tekli sayı olacak verilen sayı, 
        {
            projectilePistol = Instantiate(projectilePrefab,transform.position ,Quaternion.Euler(0,0,projectilAngles[i]));
        }
    }

    private void CalculateEvenProjectile(float angle2)
    {
        float angleDif = 5;
        for (int i = 0; i < projectileCount / 2; i++)
        {
            projectilAngles[i] = angle2 - angleDif * (i + 1);
        }

        for (int i = projectileCount / 2; i < (projectileCount / 2) * 2; i++)
        {
            projectilAngles[i] = angle2 + angleDif * (i - 2);
        }
    }

    private void CalculateOddProjectile(float angle2)
    {
        float angleDif = 5;
        float index = projectileCount / 2 -1;

        for (int i = 0; i < projectileCount / 2; i++)
        {
            projectilAngles[i] = angle2 - angleDif * (i + 1);
        }

        for (int i = projectileCount / 2 ; i < projectileCount-1 ; i++)
        {
            projectilAngles[i] = angle2 + angleDif * (projectileCount <= 3 ? 1 : (i - index));
        }
        
        projectilAngles[projectileCount-1] = angle2; 
    }

    protected override void Update()
    {
        Fire();
    }
    
}
