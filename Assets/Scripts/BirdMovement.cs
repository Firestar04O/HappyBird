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
    [SerializeField] private ParticleSystem MagicParticles;
    [SerializeField] private BirdVisualController visualController;

    private bool hasJumped = false;
    private void Awake()
    {
        maxHeight = Screen.height;
        gravity = 9.8f;
        myrgbd = GetComponent<Rigidbody>();
        gravityDirection = Vector3.down;
        myrgbd.AddForce(Vector3.right * force, ForceMode.Force);
    }
    private void Update()
    {
        float angle = Mathf.Clamp(myrgbd.linearVelocity.y * speedRotation, -maxRotation, maxRotation);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (hasJumped && MagicParticles == null)
        {
            hasJumped = false;
        }
        //if(hasJumped == false)
        //{
        //    visualController.ResetColor();
        //}
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
                visualController.OnJump();
            }
            else if (height.y < maxHeight / 2)
            {
                myrgbd.AddForce(Vector3.down * force, ForceMode.Impulse);
                gravityDirection = Vector3.up;
                visualController.OnJump();
            }
            if (MagicParticles != null)
            {
                MagicParticles.Play();
                hasJumped = true;
            }
        }
    }
}
