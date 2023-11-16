using UnityEngine;

/// <summary>
/// This MassTransformer allows for dynamic mass transformation of a GameObject based on its scale and a specified density.
/// Attach this script to a GameObject with a Rigidbody component to enable mass adjustment.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class MassTransformer : MonoBehaviour
{
    [Header("Mass Transformation Settings")]
    public float density = 100.0f;

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Calculate the volume of the object based on its scale
        float volume = transform.localScale.x * transform.localScale.y * transform.localScale.z;

        // Calculate the new mass as a function of the volume and density
        float newMass = volume * density;

        // Update the Rigidbody's mass
        rigidbody.mass = newMass;
    }
}
