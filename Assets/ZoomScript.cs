using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZoomScript : MonoBehaviour
{

    private GameObject raText;
    private bool wasZoomingLastFrame;
    private bool zoomed;
    private Vector2[] lastZoomPositions;

    // Start is called before the first frame update
    void Start()
    {
        raText = transform.GetChild(0).gameObject;
        wasZoomingLastFrame = false;
        zoomed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!zoomed && Input.touchCount == 2)
        {
            Vector2[] newPositions = new Vector2[] { Input.GetTouch(0).position, Input.GetTouch(1).position };
            if (!wasZoomingLastFrame)
            {
                lastZoomPositions = newPositions;
                wasZoomingLastFrame = true;
            }
            else
            {
                // Zoom based on the distance between the new positions compared to the 
                // distance between the previous positions.
                float newDistance = Vector2.Distance(newPositions[0], newPositions[1]);
                float oldDistance = Vector2.Distance(lastZoomPositions[0], lastZoomPositions[1]);
                float offset = newDistance - oldDistance;

                if(offset > 40){
                    zoomed = true;
                    raText.GetComponent<TextMeshPro>().text ="<RA>";
                }

                lastZoomPositions = newPositions;
            }
        }
    }
}
