using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Material daySkybox;
    public Material nightSkybox;
    public Material sunsetSkybox;

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