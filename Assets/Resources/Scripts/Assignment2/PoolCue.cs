using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PoolCue : MonoBehaviour
{
    public ActionBasedController leftController;
    public ActionBasedController rightController;

    public GameController gameController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BilliardBall"))
        {
            leftController.SendHapticImpulse(0.5f, 0.5f);
            rightController.SendHapticImpulse(0.5f, 0.5f);

            this.gameController.UpdateHits();
        }
    }
}
