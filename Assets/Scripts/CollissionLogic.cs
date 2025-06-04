using System;
using UnityEngine;

public class CollissionLogic : MonoBehaviour
{
    private Rigidbody myrgbd;
    public static event Action OnGameOver;
    [SerializeField] private Transform endpoint;
    [SerializeField] private float pushForce;
    [SerializeField] private float pushduration;

    private bool isPushed = false;
    private float pushTimer = 0f;
    private Vector3 pushDirection;

    [SerializeField] private BirdVisualController visualController;

    private void Awake()
    {
        myrgbd = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (isPushed)
        {
            pushTimer -= Time.fixedDeltaTime;
            myrgbd.AddForce(pushDirection * pushForce, ForceMode.Force);
            if(pushTimer <= 0f)
            {
                isPushed = false;
                myrgbd.linearVelocity = Vector3.zero;
                visualController.ResetColor();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("OutRange"))
        {
            OnGameOver?.Invoke();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            visualController.OnHit();
            pushDirection = (endpoint.position - transform.position).normalized;
            isPushed = true;
            pushTimer = pushduration;
        }
    }
}