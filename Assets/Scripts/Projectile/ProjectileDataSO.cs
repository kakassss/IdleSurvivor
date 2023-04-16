using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "GunModel/Gun")]
public class ProjectileDataSO : ScriptableObject
{
    public string itemName;
    //public GameObject projectileModel;
    //public Rigidbody2D rb2d;
    // silaha göre patlaam efekti veya 
    //merminin arkasından çıkan trail eklenebilir

    public float damage;
    public float projectileSpeed;
    public float fireofRate;

    public int passThroghInEnemy;
}
