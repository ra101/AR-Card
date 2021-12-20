using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private GameObject set1, set2;

    private void Awake()
    {
        set1 = transform.Find("set1").gameObject;
        set2 = transform.Find("set2").gameObject;
    }
    private void OnEnable()
    {
        // 60%
        if (Random.Range(0, 5) < 3)
        {
            set1.SetActive(true);
            set2.SetActive(false);
        }
        else
        {
            set1.SetActive(false);
            set2.SetActive(true);
        }
    }
}
