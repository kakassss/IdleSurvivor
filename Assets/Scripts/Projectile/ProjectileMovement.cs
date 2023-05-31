using UnityEngine;

public abstract class ProjectileMovement : MonoBehaviour
{
    protected Rigidbody2D rigidbody2D;
    protected virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    protected abstract void Movement();
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
