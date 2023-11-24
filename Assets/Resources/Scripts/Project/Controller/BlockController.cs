using UnityEngine;

public class BlockController : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] blocks;
    public Transform target;

    [Header("Customization")]
    public float minScale = 0.5f;
    public float maxScale = 2.0f;

    public void SpawnRandomObject()
    {
        if (blocks.Length == 0)
        {
            Debug.LogError("No object prefabs assigned.");
            return;
        }

        // Choose a random prefab from the array
        int randomIndex = Random.Range(0, blocks.Length);
        GameObject selectedPrefab = blocks[randomIndex];

        // Instantiate the selected prefab at the target position
        GameObject spawnedObject = Instantiate(selectedPrefab, target.position, Quaternion.identity);

        // Configure the scale of the spawned object within the specified range
        float randomScaleX = Random.Range(minScale, maxScale);
        float randomScaleY = Random.Range(minScale, maxScale);
        float randomScaleZ = Random.Range(minScale, maxScale);
        spawnedObject.transform.localScale = new Vector3(randomScaleX, randomScaleY, randomScaleZ);

        // Configure the color of the spawned object within the specified range
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        Renderer renderer = spawnedObject.GetComponent<MeshRenderer>();
        if (renderer is null)
        {
            Debug.LogWarning("The spawned object does not have a Renderer component.");
            return;
        }

        renderer.material.color = randomColor;
    }
}
