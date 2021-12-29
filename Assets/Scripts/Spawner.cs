// ./Assets/Scripts/Spawner.cs

using System.Collections;

using UnityEngine;


public class Spawner : MonoBehaviour
{
    /*

    */

    // Declaring Variables
    public GameObject objectToSpawn;
    private PlacementScript PlacementIndicator;

    // Called when the script instance is being loaded.
    private void Awake()
    {
        /*

        */

        PlacementIndicator = FindObjectOfType<PlacementScript>();
    }

    // Called once per frame
    private void Update()
    {
        /*

        */

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

    // Called when
    private void Spawn()
    {
        /*

        */

        // Delete Hex Placement Marker
        Destroy(PlacementIndicator.transform.GetChild(0).gameObject);

        Instantiate(
            objectToSpawn,

            // Offseting with object's height, if any
            PlacementIndicator.transform.position + new Vector3(
                0.0f, 0.0f, objectToSpawn.transform.position.y
            ),

            // Cross-Multiplcation of 90deg in y-direction
            PlacementIndicator.transform.rotation * new Quaternion(1.0f, 0.0f, 1.0f, 0)
        );

        // Clear Trash
        Destroy(PlacementIndicator.gameObject);
        Destroy(this);
    }
}
