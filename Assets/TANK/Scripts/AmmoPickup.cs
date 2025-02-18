
using UnityEngine;

public class AmmoPickup: MonoBehaviour
{
    [SerializeField] int ammoCount = 5;
    [SerializeField] GameObject pickupFX;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<PlayerTank>(out PlayerTank component))
            {
                component.ammo += ammoCount;
                Destroy(gameObject);
                if (pickupFX != null) Instantiate(pickupFX, transform.position, Quaternion.identity);
            }
        }
    }

}
