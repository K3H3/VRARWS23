using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarResetController : MonoBehaviour
{
    public GameObject pickup; // Current instance of the car
    public GameObject pickupPrefab; // Prefab of the car to spawn
    public Transform pickupSpawnPoint; // Location where the new car should be spawned

    public void ResetCar()
    {
        // Check if there is a current car instance and destroy it
        if (pickup != null)
        {
            Destroy(pickup);
        }

        // Define a new rotation with a 90-degree rotation around the y-axis
        Quaternion newRotation = Quaternion.Euler(pickupSpawnPoint.rotation.eulerAngles.x, 90f, pickupSpawnPoint.rotation.eulerAngles.z);
        
        // Instantiate a new car at the spawn point
        pickup = Instantiate(pickupPrefab, pickupSpawnPoint.position, newRotation);

        // Optionally, if you want to reset the car's velocity and other properties,
        // ensure it has a Rigidbody and reset its state here
        Rigidbody rb = pickup.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        ResetAllBlocks();
    }

    private void ResetAllBlocks()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

        foreach (GameObject block in blocks)
        {
            BlockCollisionController ctrl = block.GetComponent<BlockCollisionController>();
            ctrl.ResetPickupColliders();
        }
    }
}

