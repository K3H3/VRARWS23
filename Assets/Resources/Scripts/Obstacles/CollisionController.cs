using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
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
