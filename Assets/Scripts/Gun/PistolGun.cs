using UnityEngine;

public class PistolGun : BaseGun
{
    private PistolGunData data;
    [SerializeField] GameObject pistolprefab;

    private BulletPoolManager pool;
    protected override void Start()
    {
        data = DataManager.Instance.gameData.gunsData.pistolGunData;

        radiusOfDetectArea = data.radiusOfDetectArea;
        fireOfRate = data.fireofRate;
        projectilePrefab = pistolprefab;

        pool = BulletPoolManager.Instance;

    }

    protected override void InstantiateProjectile()
    {
        if(closestEnemyPos.transform.position.y >= 0)
        {
            projectilePistol = pool.GetObject().gameObject;
            projectilePistol.transform.position = transform.position;
            projectilePistol.transform.rotation = Quaternion.Euler(0,0,angle); // Instantiating for y >= 0 position enemies
            //projectilePistol = Instantiate(pool.GetObject().gameObject,transform.position ,Quaternion.Euler(0,0,angle)); 
        }
        else if(closestEnemyPos.transform.position.y < 0)
        {
            projectilePistol = pool.GetObject().gameObject;
            projectilePistol.transform.position = transform.position;
            projectilePistol.transform.rotation = Quaternion.Euler(0,0,-angle); // Instantiating for y < 0 position enemies
            //projectilePistol = Instantiate(pool.GetObject().gameObject,transform.position ,Quaternion.Euler(0,0,-angle));
        }
    }

    protected override void Update()
    {
        Fire();
    }
}
