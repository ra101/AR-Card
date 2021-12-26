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

        if (PlacementIndicator.transform.childCount > 1)
        {
            if (PlacementIndicator.transform.GetChild(0).gameObject.activeSelf)
            {
                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                {
                    StartCoroutine(SpawnAnimationCoroutine());
                }
            }
        }
    }

    // Called when
    private IEnumerator SpawnAnimationCoroutine()
    {
        /*

        */

        // Activate Electric Discharge
        PlacementIndicator.transform.GetChild(1).gameObject.SetActive(true);

        yield return new WaitForSeconds(0.1f);

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

        // Wait for Electric Discharge to complete (1s)
        yield return new WaitForSeconds(0.9f);

        // Clear Trash
        Destroy(PlacementIndicator.gameObject);
        Destroy(this);
    }
}
