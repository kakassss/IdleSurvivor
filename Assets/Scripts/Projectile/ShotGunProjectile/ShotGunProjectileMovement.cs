using UnityEngine;

public class ShotGunProjectileMovement : BaseProjectileMovement
{
    private ShotgunProjectileData data;
    protected override void Start()
    {
        data = DataManager.Instance.gameData.projectileData.shotgunData;
        base.Start();

        Movement();
    }

    protected override void Movement()
    {
        rigidbody2D.AddForce(transform.right * data.projectileSpeed,ForceMode2D.Impulse);
    }
}
