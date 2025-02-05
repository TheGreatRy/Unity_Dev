using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float sensitivity = 1;
    [SerializeField, Range(2,10)] float distance;

    InputAction lookAction;
    InputAction lookInput;
    Vector3 rotation = Vector3.zero; //x = pitch, y = yaw, x = roll

    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
        lookAction.performed += Look;
        lookAction.canceled += Look;
        Quaternion qrotation = Quaternion.LookRotation(target.position - transform.position);

        rotation.x = qrotation.eulerAngles.x;
        rotation.y = qrotation.eulerAngles.y;
    }

    void Update()
    {
        Quaternion qrotation = Quaternion.Euler(rotation);
        transform.position = target.position + qrotation * (Vector3.back * distance);
        transform.rotation = qrotation;

    }
    void Look(InputAction.CallbackContext ctx)
    {
        var look = ctx.ReadValue<Vector2>();

        rotation.x += look.y * sensitivity;
        rotation.y += look.x * sensitivity;

        rotation.x = Mathf.Clamp(rotation.x, 20, 89);
    }
}
