using UnityEngine;

public class SwingLocomotion : MonoBehaviour
{
    [SerializeField] private GameObject leftHand, rightHand, mainCamera, forwardDirection;
    private Vector3 prevPosLeftHand, prevPosRightHand, prevPlayerPos;
    private float speed = 70f;

    void Start()
    {
        prevPlayerPos = transform.position;
        prevPosLeftHand = leftHand.transform.position;
        prevPosRightHand = rightHand.transform.position;
    }

    void Update()
    {
        UpdateForwardDirection();
        Vector3 currentPosLeftHand = leftHand.transform.position;
        Vector3 currentPosRightHand = rightHand.transform.position;
        Vector3 currentPlayerPos = transform.position;

        float handSpeed = CalculateHandSpeed(currentPlayerPos, currentPosLeftHand, currentPosRightHand);

        if (Time.timeSinceLevelLoad > 1f)
        {
            transform.position += forwardDirection.transform.forward * handSpeed * speed * Time.deltaTime;
        }

        UpdatePreviousPositions(currentPosLeftHand, currentPosRightHand, currentPlayerPos);
    }

    private void UpdateForwardDirection()
    {
        float yRotation = mainCamera.transform.eulerAngles.y;
        forwardDirection.transform.eulerAngles = new Vector3(0, yRotation, 0);
    }

    private float CalculateHandSpeed(Vector3 currentPlayerPos, Vector3 currentPosLeftHand, Vector3 currentPosRightHand)
    {
        float playerDistanceMoved = Vector3.Distance(currentPlayerPos, prevPlayerPos);
        float leftHandDistanceMoved = Vector3.Distance(prevPosLeftHand, currentPosLeftHand);
        float rightHandDistanceMoved = Vector3.Distance(prevPosRightHand, currentPosRightHand);

        return ((leftHandDistanceMoved - playerDistanceMoved) + (rightHandDistanceMoved - playerDistanceMoved));
    }

    private void UpdatePreviousPositions(Vector3 currentPosLeftHand, Vector3 currentPosRightHand, Vector3 currentPlayerPos)
    {
        prevPosLeftHand = currentPosLeftHand;
        prevPosRightHand = currentPosRightHand;
        prevPlayerPos = currentPlayerPos;
    }
}
