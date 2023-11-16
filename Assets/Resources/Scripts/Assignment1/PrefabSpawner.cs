using UnityEngine;

/// <summary>
/// PrefabSpawner spawns a specified prefab at a designated spawn point.
/// Call the 'Spawn' method to instantiate the prefab at the specified position and rotation.
/// </summary>
public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform target;


    public void Spawn()
    {
        if (prefab == null)
        {
            Debug.LogError("Prefab not assigned.");
            return;
        }

        if (target == null)
        {
            Debug.LogError("Target not assigned.");
            return;
        }

        // Instantiate the prefab at the calculated position
        Instantiate(prefab, target.position, target.rotation);
    }
}
