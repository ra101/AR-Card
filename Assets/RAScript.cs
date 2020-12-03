using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAScript : MonoBehaviour
{

    public GameObject objectToSpawn;
    private PlacementScript hex;
    
    // Start is called before the first frame update
    void Start()
    {
        hex = FindObjectOfType<PlacementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
            GameObject obj = Instantiate(objectToSpawn, hex.transform.position, hex.transform.rotation);
        }
        
    }
}
