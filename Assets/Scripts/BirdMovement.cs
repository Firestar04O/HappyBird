using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMovement : MonoBehaviour
{
    private Rigidbody myrgbd;
    [SerializeField] private float force;
    protected Vector2 height;
    protected float maxHeight;
    private float gravity;
    private Vector3 gravityDirection;
    private float maxRotation = 45f;
    [SerializeField] private float speedRotation;
    private void Awake()
    {
        maxHeight = Screen.height;
        gravity = 9.8f;
        myrgbd = GetComponent<Rigidbody>();
        gravityDirection = Vector3.down;
    }
    private void Update()
    {
        float angle = Mathf.Clamp(myrgbd.linearVelocity.y * speedRotation, -maxRotation, maxRotation);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    private void FixedUpdate()
    {
        myrgbd.AddForce(gravityDirection * gravity, ForceMode.Acceleration);
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            height = Mouse.current.position.ReadValue();
            if (height.y > maxHeight / 2)
            {
                myrgbd.AddForce(Vector3.up * force, ForceMode.Impulse);
                gravityDirection = Vector3.down;
            }
            else if (height.y < maxHeight / 2)
            {
                myrgbd.AddForce(Vector3.down * force, ForceMode.Impulse);
                gravityDirection = Vector3.up;
            }
        }
    }
}
