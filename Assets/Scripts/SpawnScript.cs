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
                Instantiate(
                    objectToSpawn,

                    // Adding height
                    PlacementIndicator.transform.position + new Vector3(0.0f, 0.225f, 0.0f),

                    // Cross-Multiplcation of 90deg in y-direction 
                    PlacementIndicator.transform.rotation * new Quaternion(1.0f, 0.0f, 1.0f, 0)
                );

                // Clear Trash
                Destroy(PlacementIndicator);
                Destroy(this);
            }
        }
    }
}
