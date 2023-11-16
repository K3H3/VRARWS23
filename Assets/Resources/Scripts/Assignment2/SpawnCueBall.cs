using System.Collections.Generic;
using UnityEngine;

public class SpawnCueBall : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnDistance = 0.5f;

    private void Start()
    {
        Vector3 randomSpawnPosition = transform.position + Random.insideUnitSphere * spawnDistance;
        Instantiate(prefabToSpawn, randomSpawnPosition, Quaternion.identity);
    }
}
