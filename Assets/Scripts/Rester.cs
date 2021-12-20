using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rester : MonoBehaviour
{
    public Rester otherRester;
    private bool activated;
    private List<Material> materials = new List<Material>();
    private GameObject info;

    // Start is called before the first frame update
    private void Awake()
    {
        activated = false;
        info = transform.Find("info").gameObject;
        foreach (Transform child in transform.Find("LEDs"))
        {
            materials.Add(child.GetComponent<Renderer>().material);
        }
    }

    public void Toggle()
    {
        if (activated)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }

    public void Deactivate()
    {
        if (activated)
        {
            activated = false;
            foreach (Material mat in materials)
            {
                mat.DisableKeyword("_EMISSION");
            }
            info.SetActive(false);
            DynamicGI.UpdateEnvironment();
        }
    }

    public void Activate()
    {
        activated = true;
        if (otherRester.activated)
        {
            otherRester.Deactivate();
        }

        foreach (Material mat in materials)
        {
            mat.EnableKeyword("_EMISSION");
        }
        info.SetActive(true);
        DynamicGI.UpdateEnvironment();
    }
}
