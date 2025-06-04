using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject Bird;
    private void Start()
    {
        GameOver.SetActive(false);
    }
    private void OnEnable()
    {
        CollissionLogic.OnGameOver += ToGameOverPanel;
    }
    private void OnDisable()
    {
        CollissionLogic.OnGameOver -= ToGameOverPanel;
    }
    public void ToGameOverPanel()
    {
        GameOver.SetActive(true);
    }
    public void ToGameplay()
    {
        GameOver.SetActive(false);
        Bird.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        Bird.GetComponent<Transform>().position = new Vector3(-15f, 0f, 9f);
        Debug.Log("reviví");
    }
}
