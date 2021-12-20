using UnityEngine;

public class Caffeine : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake() => Screen.sleepTimeout = SleepTimeout.NeverSleep;
}
