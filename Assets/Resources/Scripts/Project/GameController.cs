using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject target;
    public float magnitude = 100.0f;

    private Vector3 direction = new Vector3(-1,0,0);

    public void Play()
    {
        if (target is null)
        {
            Debug.LogError("No 'target' GameObject assigned.");
            return;
        }

        Rigidbody rb = target.GetComponent<Rigidbody>();

        if (rb is null)
        {
            Debug.LogError("The 'target' GameObject does not have a Rigidbody component.");
            return;

        }

        rb.AddForce(direction.normalized * magnitude, ForceMode.Acceleration);
    }
}
