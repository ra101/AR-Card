// ./Assets/Scripts/Rester.cs

using System.Collections.Generic;

using UnityEngine;


public class Rester : MonoBehaviour
{
    // Declaring Variables
    private bool activated;
    private List<Material> materials = new List<Material>();
    private GameObject info;
    public Rester otherRester;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// <summary>
    private void Awake()
    {
        activated = false;
        info = transform.Find("info").gameObject;
        foreach (Transform child in transform.Find("LEDs"))
        {
            materials.Add(child.GetComponent<Renderer>().material);
        }
    }

    /// <summary>
    /// Called when
    /// <summary>
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

    /// <summary>
    /// Called when
    /// <summary>
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

    /// <summary>
    /// Called when
    /// <summary>
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
