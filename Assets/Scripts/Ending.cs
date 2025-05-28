using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] private UpObstacleMovement obstacle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            obstacle.GetComponent<Transform>().position = new Vector3(22f,10f,9f);
        }
    }
}
