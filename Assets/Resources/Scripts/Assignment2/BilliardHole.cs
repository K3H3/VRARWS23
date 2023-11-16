using UnityEngine;

public class BilliardHole : MonoBehaviour
{
    public GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BilliardBall"))
        {
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

            // Ignore collisions between the ball that fell in the hole and all walls
            foreach (GameObject wall in walls)
            {
                Collider wallCollider = wall.GetComponent<Collider>();
                if (wallCollider != null)
                {
                    Physics.IgnoreCollision(other, wallCollider, true);
                }
            }

            Vector3 directionToCenter = transform.position - other.transform.position;
            other.attachedRigidbody.AddForce(directionToCenter.normalized * 0.1f, ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BilliardBall"))
        {
            other.attachedRigidbody.useGravity = true;
            this.gameController.UpdateGoals();
        }
    }
}
