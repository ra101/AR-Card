using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            this.transform.Rotate(new Vector3(0, 0.5f, 0));
        }
    }
}
