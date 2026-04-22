using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class CanonController : MonoBehaviour
{
    [SerializeField] float maxTorque = 90;
    [SerializeField] Transform barrel;
    [SerializeField] GameObject projectile;

    float torque;

    Rigidbody mainBody;
    void Start()
    {
        mainBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        torque = Input.GetAxis("Vertical") * maxTorque;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, barrel.position, barrel.rotation);
            
        }
    }
    private void FixedUpdate()
    {
        mainBody.AddRelativeTorque(Vector3.up * torque);
    }
}
