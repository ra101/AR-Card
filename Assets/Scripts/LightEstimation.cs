// ./Assets/Scripts/LightEstimation.cs

using UnityEngine;

using UnityEngine.Rendering;
using UnityEngine.XR.ARFoundation;


/// <summary>
/// A component that can be used to access the most recently received HDR light estimation information
/// for the physical environment as observed by an AR device.
/// </summary>
public class LightEstimation : MonoBehaviour
{

    // Declaring Variables

    /// <summary>
    /// ARCameraManager will produce frame events containing light estimation information.
    /// <summary>
    private ARCameraManager ARCamManager;

    /// <summary>
    /// Main Light of our scene.
    /// <summary>
    private Light dirLight;


    /// <summary>
    /// Initialize Variables.
    /// <summary>
    private void Awake()
    {
        dirLight = GetComponent<Light>();
        ARCamManager = FindObjectOfType<ARCameraManager>();
    }

    /// <summary>
    /// Set ARCamManagers rotation as Main Lights default rotation,
    /// Subscribe <c>EstimateLight</c> function to <c>frameReceived</c> event.
    /// <summary>
    private void OnEnable()
    {
        dirLight.transform.rotation = ARCamManager.transform.rotation;
        ARCamManager.frameReceived += EstimateLight;
    }

    /// <summary>
    /// Set ARCamManagers rotation as Main Lights default rotation,
    /// Unsubscribe <c>EstimateLight</c> function from <c>frameReceived</c> event.
    /// <summary>
    private void OnDisable()
    {
        dirLight.transform.rotation = ARCamManager.transform.rotation;
        ARCamManager.frameReceived -= EstimateLight;
    }


    /// <summary>
    /// Update <c>Light</c> with the estimated value of main light of the physical environment, if available
    /// (calculated by <c>ARCameraManager</c>).
    /// <summary>
    private void EstimateLight(ARCameraFrameEventArgs args)
    {
        // Intensity
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            dirLight.intensity = args.lightEstimation.averageBrightness.Value;
        }

        // Temperature
        if (args.lightEstimation.averageColorTemperature.HasValue)
        {
            dirLight.colorTemperature = args.lightEstimation.averageColorTemperature.Value;
        }

        // Color
        if (args.lightEstimation.colorCorrection.HasValue)
        {
            dirLight.color = args.lightEstimation.colorCorrection.Value;
        }


        // Spherical Harmonics
        if (args.lightEstimation.ambientSphericalHarmonics.HasValue)
        {
            RenderSettings.ambientMode = AmbientMode.Skybox;
            RenderSettings.ambientProbe = args.lightEstimation.ambientSphericalHarmonics.Value;
        }

        // Direction
        if (args.lightEstimation.mainLightDirection.HasValue)
        {
            dirLight.transform.rotation = Quaternion.LookRotation(
                args.lightEstimation.mainLightDirection.Value
            );
        }
    }

}
