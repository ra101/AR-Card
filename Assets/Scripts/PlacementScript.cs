// ./Assets/Scripts/PlacementScript.cs

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class PlacementScript : MonoBehaviour
{
    /*

    */

    // Declaring Variables
    private ARRaycastManager rayManager;
    private GameObject HexPlane;

    // Called before the first frame update
    private void Start()
    {
        /*

        */

        // Get the components
        rayManager = FindObjectOfType<ARRaycastManager>();
        HexPlane = transform.GetChild(0).gameObject;

        // Hide the placement indicator visual
        HexPlane.SetActive(false);
    }

    // Called once per frame
    private void Update()
    {
        /*

        */

        // Shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        rayManager.Raycast(
            new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes
        );

        // If we hit an AR plane surface, update the position and rotation
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            // Enable the visual if it's disabled
            if (HexPlane && !HexPlane.activeInHierarchy)
            {
                HexPlane.SetActive(true);
            }
        }
    }
}
