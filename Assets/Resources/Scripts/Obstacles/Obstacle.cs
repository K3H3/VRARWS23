using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [Header("Obstacle Settings")]
    [SerializeField] public GameObject prefab;

    [Header("Debug Settings")]
    [SerializeField] public Color gizmoColor = Color.white;


    public abstract void Prepare();

    public abstract void Act();

    public abstract void Visualize();

    public void Start()
    {
        Prepare();
    }

    public void Update()
    {
        Act();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Visualize();
    }
}
