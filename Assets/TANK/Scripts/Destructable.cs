using UnityEngine;

public class Destructable : MonoBehaviour, IDamagable
{
    [SerializeField] float health = 20;
    [SerializeField] GameObject destroyFX;

    bool destroyed = false;

    public float Health { get { return health; } set { health = value; } }

    public void ApplyDamage(float damage)
    {
        if (destroyed) return;
        
        health -= damage;
        if (health <= 0)
        {
            destroyed = true;
            if (destroyFX != null) Instantiate(destroyFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
