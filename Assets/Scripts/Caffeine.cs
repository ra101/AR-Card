// ./Assets/Scripts/Caffeine.cs

using UnityEngine;


public class Caffeine : MonoBehaviour
{
    /*

    */

    // Called when the script instance is being loaded.
    private void Awake() => Screen.sleepTimeout = SleepTimeout.NeverSleep;
}
