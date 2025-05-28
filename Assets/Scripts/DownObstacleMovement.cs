using UnityEngine;

public class DownObstacleMovement : MonoBehaviour
{
    [SerializeField] private UpObstacleMovement reference;
    void Update()
    {
        transform.position = new Vector3(reference.GetComponent<Transform>().position.x, reference.GetComponent<Transform>().position.y - reference.distanceBetweenObstacles , transform.position.z);
    }
}
