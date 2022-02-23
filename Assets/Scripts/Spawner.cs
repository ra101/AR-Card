// ./Assets/Scripts/Spawner.cs

using System.Collections;

using UnityEngine;

using UnityEngine.XR.ARFoundation;


/// <summary>
/// Spawns when Tapped
/// </summary>
public class Spawner : MonoBehaviour
{
    // Declaring Variables
    public GameObject prefab, ARShadowPlane;
    private PlacementScript PlacementIndicator;

    private ARPointCloudManager pointCloudManager;

    /// <summary>
    /// Initiate Variables
    /// </summary>
    private void Awake()
    {
        PlacementIndicator = FindObjectOfType<PlacementScript>();
        pointCloudManager = FindObjectOfType<ARPointCloudManager>();
    }

    /// <summary>
    /// Spwan, if Tapped,
    /// </summary>
    private void Update()
    {
        if (PlacementIndicator.transform.childCount > 0)
        {
            if (PlacementIndicator.transform.GetChild(0).gameObject.activeSelf)
            {
                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                {
                    Spawn();
                }
            }
        }
    }

    /// <summary>
    /// Places Machinery, ARShadowPlane
    /// Disable PointClouds and Hex
    /// </summary>
    private void Spawn()
    {
        Animator aniController = PlacementIndicator.transform.GetChild(0).GetComponent<Animator>();
        aniController.SetBool("spawned", true);

        Instantiate(
            prefab,

            /// Offseting with object's height, if any
            PlacementIndicator.transform.position + new Vector3(
                0.0f, 0.0f, prefab.transform.position.y
            ),

            /// Cross-Multiplcation of 90deg in y-direction
            PlacementIndicator.transform.rotation * new Quaternion(1.0f, 0.0f, 1.0f, 0)
        );

        Instantiate(
            ARShadowPlane,
            PlacementIndicator.transform.position + new Vector3(
                0.01f, 0.01f, 0.01f
            ),
            PlacementIndicator.transform.rotation
        );

        pointCloudManager.SetTrackablesActive(false);
        Destroy(this);
    }
}
