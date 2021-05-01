using System.Collections;

using UnityEngine;


public class SpawnScript : MonoBehaviour
{

    public GameObject objectToSpawn;
    private PlacementScript PlacementIndicator;

    // Start is called before the first frame update
    void Start()
    {
        PlacementIndicator = FindObjectOfType<PlacementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlacementIndicator.transform.GetChild(0).gameObject.activeSelf)
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                StartCoroutine(SpawnAnimationCoroutine());
            }
        }
    }

    IEnumerator SpawnAnimationCoroutine()
    {
        // Activate Electric Discharge
        PlacementIndicator.transform.GetChild(1).gameObject.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        // Delete Hex Placement Marker
        Destroy(PlacementIndicator.transform.GetChild(0).gameObject);

        Instantiate(
            objectToSpawn,

            // Adding height
            PlacementIndicator.transform.position + new Vector3(0.0f, 0.225f, 0.0f),

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
