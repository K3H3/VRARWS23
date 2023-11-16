using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int goals = 0;
    private int hits = 0;
    private float startTime;

    public Text goalsText;
    public Text hitsText;
    public Text timeText;
    public Text scaleText;


    private void Start()
    {
        startTime = Time.time;
        goalsText.text = "Goals: 0";
        hitsText.text = "Hits: 0";
        scaleText.text = "100 %";
    }

    private void Update()
    {
        UpdateTime();
    }

    public void UpdateGoals()
    {
        goals += 1;
        goalsText.text = "Goals: " + goals.ToString();
    }

    private void UpdateTime()
    {
        float elapsedTime = Time.time - startTime;
        string formattedTime = string.Format("{0:F0} seconds", elapsedTime);

        if (timeText != null)
        {
            timeText.text = "Time spent: " + formattedTime;
        }
    }

    public void UpdateHits()
    {
        hits += 1;
        hitsText.text = $"Hits: {hits}";
    }


    public void ApplyScale(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);
        scaleText.text = $"{scale * 100} %";
    }

    public void ResetGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
