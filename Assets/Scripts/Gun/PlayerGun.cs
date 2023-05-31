using UnityEngine;

public class PlayerGun : BaseGun
{

    private PlayerGunData data;
    [SerializeField] GameObject playerProjectile;
    protected override void Start()
    {
        data = DataManager.Instance.gameData.gunsData.playerGunData;

        fireOfRate = data.fireofRate;
        projectilePrefab = playerProjectile;
        radiusOfDetectArea = data.radiusOfDetectArea;
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
        PlayerInput();
    }
}
