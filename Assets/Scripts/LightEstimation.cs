using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.ARFoundation;

public class LightEstimation : MonoBehaviour
{

    /// Declaring Variables
    private ARCameraManager ARCamManager;

    private Light dirLight;

    /// Called when the script instance is being loaded.
    private void Awake()
    {
        dirLight = GetComponent<Light>();
        ARCamManager = FindObjectOfType<ARCameraManager>();
    }

    /// Called when the object becomes enabled and active.
    private void OnEnable()
    {
        dirLight.transform.rotation = ARCamManager.transform.rotation;
        ARCamManager.frameReceived += FrameUpdated;
    }

    /// Called when the object becomes disabled or inactive.
    private void OnDisable()
    {
        dirLight.transform.rotation = ARCamManager.transform.rotation;
        ARCamManager.frameReceived -= FrameUpdated;
    }

    private void FrameUpdated(ARCameraFrameEventArgs args)
    {
        /// Intensity
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            dirLight.intensity = args.lightEstimation.averageBrightness.Value;
        }

        /// Temperature
        if (args.lightEstimation.averageColorTemperature.HasValue)
        {
            dirLight.colorTemperature = args.lightEstimation.averageColorTemperature.Value;
        }

        /// Color
        if (args.lightEstimation.colorCorrection.HasValue)
        {
            dirLight.color = args.lightEstimation.colorCorrection.Value;
        }


        /// Spherical Harmonics
        if (args.lightEstimation.ambientSphericalHarmonics.HasValue)
        {
            RenderSettings.ambientMode = AmbientMode.Skybox;
            RenderSettings.ambientProbe = args.lightEstimation.ambientSphericalHarmonics.Value;
        }

        /// Direction
        if (args.lightEstimation.mainLightDirection.HasValue)
        {
            dirLight.transform.rotation = Quaternion.LookRotation(
                args.lightEstimation.mainLightDirection.Value
            );
        }
    }

}
