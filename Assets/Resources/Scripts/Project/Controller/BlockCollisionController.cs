using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BlockCollisionController : MonoBehaviour
{
    private XRGrabInteractable block;
    private GameObject pickup;
    [SerializeField] private List<Collider> pickupColliders;

    [SerializeField] private List<Collider> blockColliders;
    // Start is called before the first frame update
    void Start()
    {
        block = GetComponent<XRGrabInteractable>();
        block.selectEntered.AddListener(SetIgnoreCollisionsWithCar);
        block.selectExited.AddListener(SetCollisionsWithCar);

        pickup = GameObject.FindWithTag("Pickup");
        if(pickup == null)
        {
            Debug.LogError("Pickup not found!");
        }
        else
        {
            AddCollidersToList(pickup, pickupColliders);
        }

        AddCollidersToList(gameObject, blockColliders);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetIgnoreCollisionsWithCar(SelectEnterEventArgs args)
    {
        Debug.Log("Setting ignore collisions");
        foreach (Collider blockCol in blockColliders)
        {
            foreach (Collider pickupCol in pickupColliders)
            {
                Physics.IgnoreCollision(blockCol, pickupCol, true);
            }
        }
    }

    void SetCollisionsWithCar(SelectExitEventArgs args)
    {
        Debug.Log("Re-enabling collisions");
        foreach (Collider blockCol in blockColliders)
        {
            foreach (Collider pickupCol in pickupColliders)
            {
                Debug.Log($"Ignoring collider: {pickupCol.name}");
                Physics.IgnoreCollision(blockCol, pickupCol, false);
            }
        }
    }

    private void AddCollidersToList(GameObject obj, List<Collider> collidersList)
    {
        // Add collider from the current object, if it has one
        Collider currentCollider = obj.GetComponent<Collider>();
        if (currentCollider != null)
        {
            collidersList.Add(currentCollider);
        }

        // Recursively call this method for each child
        foreach (Transform child in obj.transform)
        {
            AddCollidersToList(child.gameObject, collidersList);
        }
    }

    public void ResetPickupColliders()
    {
        pickup = GameObject.FindWithTag("Pickup");
        if(pickup == null)
        {
            Debug.LogError("Pickup not found!");
        }
        else
        {
            AddCollidersToList(pickup, pickupColliders);
        }
    }
}
