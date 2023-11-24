using Photon.Pun;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [Header("Spawn Settings")] public GameObject[] blocks;
    public Transform target;

    [Header("Customization")] public float minScale = 0.5f;
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

        GameObject spawnedObject = PhotonNetwork.Instantiate(selectedPrefab.name, target.position, Quaternion.identity);

        float randomScaleX = Random.Range(minScale, maxScale);
        float randomScaleY = Random.Range(minScale, maxScale);
        float randomScaleZ = Random.Range(minScale, maxScale);
        Vector3 randomScale = new Vector3(randomScaleX, randomScaleY, randomScaleZ);

        spawnedObject.GetComponent<ObjectModifier>().ApplyModifiers(randomScale);
    }
}