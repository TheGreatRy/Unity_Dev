using UnityEngine;
using UnityEngine.InputSystem;

public class RollerController : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float jumpForce = 1;
    [SerializeField] Transform view;
    [SerializeField] LayerMask groundMask;

    Rigidbody rb;
    Vector2 movementInput = Vector2.zero;  
    float rayLength = 2;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementInput.x, 0, movementInput.y);
        movement = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up) * movement;
        rb.AddForce(view.rotation * movement * speed);
        
    }
    public void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
    public void OnJump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);  
    }
    public bool OnGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayLength, groundMask);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector3.down * rayLength);
    }
}
