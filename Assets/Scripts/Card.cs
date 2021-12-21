// ./Assets/Scripts/Card.cs

using UnityEngine;


public class Card : MonoBehaviour
{
    /*

    */

    // Declaring Variables
    private GameObject set1, set2;

    // Called when the script instance is being loaded.
    private void Awake()
    {
        /*

        */

        set1 = transform.Find("set1").gameObject;
        set2 = transform.Find("set2").gameObject;
    }


    // Called when the object becomes enabled and active.
    private void OnEnable()
    {
        /*

        */

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
