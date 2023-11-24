using UnityEngine;

public class ObjectModifier : MonoBehaviour
{
    public void ApplyScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    public void ApplyColor(Color color)
    {
        Renderer renderer = GetComponent<MeshRenderer>();
        renderer.material.color = color;
    }
}