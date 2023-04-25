using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : BaseGun
{
    private ShotGunData data;
    
    [SerializeField] float[] projectilAngles;

    private int projectileCount;
    protected override void Start()
    {
        data = DataManager.Instance.gameData.gunsData.shotGunData;
        fireOfRate = data.fireofRate;
        projectilePrefab = data.projectilePrefab;
        radiusOfDetectArea = data.radiusOfDetectArea;
        projectileCount = data.projectileCount;

        projectilAngles = new float[projectileCount];
        CalculateEveryProjectileAngle(45);
        base.Start();
    }

    protected override void InstantiateProjectile()
    {
        //CalculateEveryProjectileAngle();
        if(closestEnemyPos.transform.position.y >= 0)
        {
            
        }
        else if(closestEnemyPos.transform.position.y < 0)
        {
            projectilePistol = Instantiate(projectilePrefab,transform.position ,Quaternion.Euler(0,0,-angle));
        }
    }

    private void CalculateEveryProjectileAngle(float angle1)
    {                               //           5 tane mermi varsa-----3 tane
        float currentAngle = angle1;// 45 düşün, 25 35 45 55 65-----------  35 45 55
        
        for (int i = 0; i < projectileCount; i++)
        {
            if(i>=2)
            {
                currentAngle -= 5;
            }
            projectilAngles[i] = currentAngle + (10);
        }
       

        if(angle % 2 == 0)
        {
            
        }
        else
        {
            
        }
        for (int i = 0; i < 5; i++) // mantık söyle tekli sayı olacak verilen sayı, 
        {
            projectilePistol = Instantiate(projectilePrefab,transform.position ,Quaternion.Euler(0,0,angle));
        }
    }
    protected override void Update()
    {
        Fire();
        //dataManager.gameData.projectileData.damage +=1;
        //DataManager.Instance.SavePlayerData(); // bunu ilerde bi şeyler için kullanabilirsin dursun şimdilik, zaten bu update calısmıyor
        //Fire();
    }
    
}
