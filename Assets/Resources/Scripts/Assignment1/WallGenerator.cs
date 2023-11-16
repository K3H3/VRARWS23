#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

/// <summary>
/// Generates a grid-based wall of 3D primitives (either cubes or spheres) in the Unity scene.
/// Allows customization of the wall's rows, columns, scale, and material.
/// Provides visual feedback in the editor using gizmos.
/// </summary>
public class WallGenerator : MonoBehaviour
{
    [Header("Wall Settings")]
    public int columns = 1;
    public int rows = 1;
    public float scale = 1f;
    public ObjectType objectType = ObjectType.Cube;

    public enum ObjectType
    {
        Cube,
        Sphere
    }

    [Header("Material Settings")]
    public Material material;

    private void Start()
    {
        GenerateWall();
    }

    private void GenerateWall()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector3 position = CalculatePosition(i, j);
                SpawnObjectAtPosition(position);
            }
        }
    }

    private Vector3 CalculatePosition(int columnIndex, int rowIndex)
    {
        Vector3 origin = gameObject.transform.position;
        float offsetY = scale / 2;
        return new Vector3(origin.x + columnIndex * scale, origin.y + rowIndex * scale + offsetY, origin.z);
    }

    private void SpawnObjectAtPosition(Vector3 position)
    {
        GameObject instantiatedObject;

        if (objectType == ObjectType.Cube)
        {
            instantiatedObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
        else
        {
            instantiatedObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }

        instantiatedObject.transform.position = position;
        instantiatedObject.transform.localScale = new Vector3(scale, scale, scale);
        instantiatedObject.transform.parent = gameObject.transform;

        instantiatedObject.AddComponent<Rigidbody>();

        instantiatedObject.GetComponent<MeshRenderer>().material = material;
    }
    
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        DrawWallGizmos();
        DrawDebugLabel();
    }

    private void DrawWallGizmos()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector3 position = CalculatePosition(i, j);
                DrawGizmoAtPosition(position);
            }
        }
    }

    private void DrawGizmoAtPosition(Vector3 position)
    {
        Gizmos.color = Color.magenta;

        if (objectType == ObjectType.Cube)
        {
            Gizmos.DrawWireCube(position, new Vector3(scale, scale, scale));
        }
        else
        {
            Gizmos.DrawWireSphere(position, scale/2);
        }
    }

    private void DrawDebugLabel()
    {
        GUIStyle style = new GUIStyle
        {
            normal = { textColor = Color.magenta },
            fontSize = 32
        };

        Handles.Label(gameObject.transform.position, $"[{columns} x {rows}]", style);
    }
    #endif
}
