using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Controls a moving obstacle that follows a path defined by waypoints.
/// The obstacle loops back to the start when the end of the path is reached.
/// </summary>
public class MoveableObstacle : Obstacle
{
    [Header("Moveable Obstacle Settings")]
    [SerializeField] private float speed = 2.0f;

    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private GameObject obstacle;

    public override void Prepare()
    {
        waypoints = GetComponentsInChildren<Transform>().Where(t => t != transform).ToArray();
        if (prefab == null || waypoints.Length < 2)
        {
            Debug.LogError("Initialization error: Make sure that the prefab is set and there are at least two waypoints.");
            return;
        }
        obstacle = Instantiate(prefab, waypoints[0].position, Quaternion.identity);
    }

    public override void Act()
    {
        if (obstacle != null)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            obstacle.transform.position = Vector3.MoveTowards(obstacle.transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(obstacle.transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }
    }
    

    public override void Visualize()
    {
        #if UNITY_EDITOR
        waypoints = GetComponentsInChildren<Transform>().Where(t => t != transform).ToArray();

        if (waypoints.Length > 1)
        {
            DrawPath();
        }
        #endif
    }


    void DrawPath()
    {
        #if UNITY_EDITOR
        for (int i = 1; i <= waypoints.Length; i++)
        {
            Transform startPoint = waypoints[i - 1];
            Transform endPoint = i != waypoints.Length ? waypoints[i] : waypoints[0];

            // Draw the line between waypoints.
            Gizmos.DrawLine(startPoint.position, endPoint.position);

            // Draw the waypoint index text.
            Handles.Label(startPoint.position, "Waypoint " + (i));

            // Draw an arrow in the middle of the segment.
            Vector3 direction = (endPoint.position - startPoint.position).normalized;
            DrawArrow(startPoint.position + direction * (Vector3.Distance(startPoint.position, endPoint.position) / 2), direction);
        }

        // Draw line back to initial positon.
        Gizmos.DrawLine(waypoints[waypoints.Length - 1].position, waypoints[0].position);

        // Optionally, draw an arrow from the last waypoint to the first to close the loop.
        if (waypoints.Length > 2)
        {
            Vector3 direction = (waypoints[0].position - waypoints[waypoints.Length - 1].position).normalized;
            DrawArrow(waypoints[waypoints.Length - 1].position + direction * (Vector3.Distance(waypoints[waypoints.Length - 1].position, waypoints[0].position) / 2), direction);
        }
        #endif
    }

    private void DrawArrow(Vector3 position, Vector3 direction)
    {
        #if UNITY_EDITOR
        // Adjust these values to change the size and shape of the arrowheads.
        float arrowHeadLength = 0.25f;
        float arrowHeadAngle = 20.0f;

        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Gizmos.DrawRay(position, right * arrowHeadLength);
        Gizmos.DrawRay(position, left * arrowHeadLength);
        #endif
    }

}
