using UnityEditor.ShaderGraph;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObbject", menuName = "ScriptableObbject/Material Data")]
public class MaterialData : ScriptableObject
{
    public Material birdMaterial;
    public Color onBaseColor = Color.yellow;
    public Color onJumpColor = Color.green;
    public Color onHitColor = Color.red;
}
