using UnityEngine;

public class PlayerProjectileMovement : ProjectileMovement
{
    private PlayerProjectileData data;
    protected override void Start()
    {
        data = DataManager.Instance.gameData.projectileData.playerData;
        base.Start();

        Movement();
    }

    protected override void Movement()
    {
        rigidbody2D.AddForce(transform.right * data.projectileSpeed,ForceMode2D.Impulse);
    }
    
}
