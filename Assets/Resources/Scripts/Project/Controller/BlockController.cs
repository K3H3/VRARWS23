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

        PhotonNetwork.Instantiate(selectedPrefab.name, target.position, Quaternion.identity);
    }
}