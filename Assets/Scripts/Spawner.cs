// ./Assets/Scripts/Spawner.cs

using System.Collections;

using UnityEngine;

using UnityEngine.XR.ARFoundation;


public class Spawner : MonoBehaviour
{
    // Declaring Variables
    public GameObject prefab, ARShadowPlane;
    private PlacementScript PlacementIndicator;

    private ARPointCloudManager pointCloudManager;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// <summary>
    private void Awake()
    {
        PlacementIndicator = FindObjectOfType<PlacementScript>();
        pointCloudManager = FindObjectOfType<ARPointCloudManager>();
    }

    /// Called once per frame
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
    /// Called when
    /// <summary>
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
        Destroy(pointCloudManager);
        Destroy(this);
    }
}
