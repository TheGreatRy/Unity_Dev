using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force = 10;
    [SerializeField] GameObject bulletTrail;
    [SerializeField] AudioSource fireSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force, ForceMode.VelocityChange);
        if (bulletTrail != null) Instantiate(bulletTrail, transform.position, Quaternion.identity);
        fireSFX.Play();
    }

    // Update is called once per frame
    void Update()
    {
        bulletTrail.transform.position = transform.position;
    }
}
