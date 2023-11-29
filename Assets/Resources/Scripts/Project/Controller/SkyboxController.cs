using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Material daySkybox;
    public Material nightSkybox;
    public Material sunsetSkybox;

    void Start()
    {
        // Load skybox materials from Resources folder
        daySkybox = Resources.Load<Material>("Skybox/Project/day");
        nightSkybox = Resources.Load<Material>("Skybox/Project/night");
        sunsetSkybox = Resources.Load<Material>("Skybox/Project/sunset");
    }

    public void SetDaySkybox()
    {
        RenderSettings.skybox = daySkybox;
    }

    public void SetNightSkybox()
    {
        RenderSettings.skybox = nightSkybox;
    }

    public void SetSunsetSkybox()
    {
        RenderSettings.skybox = sunsetSkybox;
    }

}