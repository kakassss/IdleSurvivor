using UnityEngine;

public class PistolProjectileMovement : ProjectileMovement
{
    private PistolProjectileData data;
    protected override void Start()
    {
        data = DataManager.Instance.gameData.projectileData.pistolData;
        base.Start();

        Movement();
    }
    
    protected override void Movement()
    {
        rigidbody2D.AddForce(transform.right * data.projectileSpeed,ForceMode2D.Impulse);
    }
}
