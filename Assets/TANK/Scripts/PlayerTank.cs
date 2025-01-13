
using UnityEngine;

public class PlayerTank : MonoBehaviour
{

    [SerializeField] float maxTorque = 90; 
    [SerializeField] float maxForce = 1;
    [SerializeField] GameObject rocket;
    [SerializeField] Transform barrel;

    float torque;
    float force;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        torque = Input.GetAxis("Horizontal") * maxTorque;
        force = Input.GetAxis("Vertical") * maxForce;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(rocket, barrel.position + Vector3.up, barrel.rotation);
        }
    }
    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector3.up * torque);
    }
}
