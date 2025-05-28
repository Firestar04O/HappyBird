using UnityEngine;

public class UpObstacleMovement : MonoBehaviour
{
    [SerializeField] private float obstacleSpeed;
    [SerializeField] public float distanceBetweenObstacles;
    void Update()
    {
        transform.position = new Vector3(transform.position.x - obstacleSpeed, transform.position.y, transform.position.z);
    }
}
