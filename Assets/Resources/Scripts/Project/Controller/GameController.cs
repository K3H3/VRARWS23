using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject target;
    public float magnitude = 100.0f;
    private float _startTime;
    public Text timeText;
    

    private Vector3 direction = new Vector3(-1, 0, 0);

    public void Start()
    {
        _startTime = Time.time;
    }
    
    private void Update()
    {
        UpdateTime();
    }
    
    private void UpdateTime()
    {
        float elapsedTime = Time.time - _startTime;
        string formattedTime = string.Format("{0:F0} seconds", elapsedTime);

        if (timeText != null)
        {
            timeText.text = "Time spent: " + formattedTime;
        }
    }

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