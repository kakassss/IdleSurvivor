using UnityEngine;

public class PistolGun : BaseGun
{
    private PistolGunData data;
    [SerializeField] GameObject pistolprefab;
    protected override void Start()
    {
        data = DataManager.Instance.gameData.gunsData.pistolGunData;

        radiusOfDetectArea = data.radiusOfDetectArea;
        fireOfRate = data.fireofRate;
        projectilePrefab = pistolprefab;
    }

    protected override void InstantiateProjectile()
    {
        if(closestEnemyPos.transform.position.y >= 0)
        {
            projectilePistol = Instantiate(projectilePrefab,transform.position ,Quaternion.Euler(0,0,angle)); // Instantiating for y >= 0 position enemies
        }
        else if(closestEnemyPos.transform.position.y < 0)
        {
            projectilePistol = Instantiate(projectilePrefab,transform.position ,Quaternion.Euler(0,0,-angle));// Instantiating for y < 0 position enemies
        }
    }

    protected override void Update()
    {
        Fire();
    }
}
