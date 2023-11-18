using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    public Transform targetPosition;

    void Update()
    {
        if (targetPosition != null)
        {
            transform.position = new Vector3(targetPosition.position.x, 0, targetPosition.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Obstacle"))
        {
            return;
        }

        Debug.Log("Player collided with obstacle! Game over.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
