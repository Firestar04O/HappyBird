using UnityEngine;

public class BirdVisualController : MonoBehaviour
{
    [SerializeField] private MaterialData materialData;
    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();

        if (materialData != null)
        {
            myRenderer.material = new Material(materialData.birdMaterial);
            SetColor(materialData.onBaseColor);
        }
    }
    public void SetColor(Color color)
    {
        myRenderer.material.color = color;
    }
    public void OnJump()
    {
        SetColor(materialData.onJumpColor);
    }
    public void OnHit()
    {
        SetColor(materialData.onHitColor);
    }
    public void ResetColor()
    {
        SetColor(materialData.onBaseColor);
    }
}
