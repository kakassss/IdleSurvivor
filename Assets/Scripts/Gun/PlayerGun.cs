using UnityEngine;

public class PlayerGun : BaseGun
{

    private PlayerGunData data;
    [SerializeField] GameObject playerProjectile;
    private PlayerGunPoolManager pool;
    protected override void Start()
    {
        data = DataManager.Instance.gameData.gunsData.playerGunData;

        fireOfRate = data.fireofRate;
        projectilePrefab = playerProjectile;
        radiusOfDetectArea = data.radiusOfDetectArea;

        pool = PlayerGunPoolManager.Instance;
    }

    protected override void InstantiateProjectile()
    {
        if(closestEnemyPos.transform.position.y >= 0)
        {
            projectilePistol = pool.GetObject().gameObject;
            projectilePistol.transform.position = transform.position;
            projectilePistol.transform.rotation = Quaternion.Euler(0,0,angle);
            //projectilePistol = Instantiate(projectilePrefab,transform.position ,Quaternion.Euler(0,0,angle)); // Instantiating for y >= 0 position enemies
        }
        else if(closestEnemyPos.transform.position.y < 0)
        {
            projectilePistol = pool.GetObject().gameObject;
            projectilePistol.transform.position = transform.position;
            projectilePistol.transform.rotation = Quaternion.Euler(0,0,-angle);
            //projectilePistol = Instantiate(projectilePrefab,transform.position ,Quaternion.Euler(0,0,-angle));// Instantiating for y < 0 position enemies
        }
    }

    public override void UpgradeGunData(GameData data)
    {
        radiusOfDetectArea = data.gunsData.playerGunData.radiusOfDetectArea;
        fireOfRate = data.gunsData.playerGunData.fireofRate;
    }

    protected override void Update()
    {
        PlayerInput();
    }
}
