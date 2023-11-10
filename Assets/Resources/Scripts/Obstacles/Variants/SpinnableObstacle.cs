using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Controls a spinning obstacle that spins clock or counterclockwise.
/// </summary>
public class SpinnableObstacle : Obstacle
{
    [Header("Spinnable Obstacle Settings")]
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private bool clockwise = true;

    private GameObject obstacle;

    public override void Prepare()
    {
        obstacle = Instantiate(prefab, transform.position, Quaternion.identity);
    }

    public override void Act()
    {
        float direction = clockwise ? 1f : -1f;
        obstacle.transform.Rotate(Vector3.up, speed * direction * Time.deltaTime);
    }


    public override void Visualize()
    {
        #if UNITY_EDITOR
        float radius = 1f; 
        Vector3 rotationDirection = clockwise ? Vector3.forward : Vector3.back;
        Vector3 arrowPosition1 = transform.position + (transform.right * radius);
        Vector3 arrowPosition2 = transform.position + (-transform.right * radius);

        Gizmos.DrawWireSphere(transform.position, radius);
        DrawArrow(arrowPosition1, rotationDirection);
        DrawArrow(arrowPosition2, -rotationDirection);
        #endif
    }

    private void DrawArrow(Vector3 position, Vector3 direction)
    {
        #if UNITY_EDITOR
        float arrowHeadLength = 0.25f;
        float arrowHeadAngle = 20.0f;

        // Draw the arrow line
        Gizmos.DrawRay(position, direction * 0.5f); // The length of the line is half of the radius for visibility

        // Calculate the right and left parts of the arrowhead
        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * Vector3.forward;
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * Vector3.forward;

        // Draw the right and left parts of the arrowhead
        Gizmos.DrawRay(position + direction * 0.5f, right * arrowHeadLength);
        Gizmos.DrawRay(position + direction * 0.5f, left * arrowHeadLength);
        #endif
    }

}