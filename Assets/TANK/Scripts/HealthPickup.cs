using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healthPoints = 15;
    [SerializeField] GameObject pickupFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<PlayerTank>(out PlayerTank component))
            {
                component.OnHealthUpdate(healthPoints);
                Destroy(gameObject);
                if (pickupFX != null) Instantiate(pickupFX, transform.position, Quaternion.identity);
            }
        }
    }
}
