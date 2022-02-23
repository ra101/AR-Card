using UnityEngine;


/// <summary>
/// Rotates the attached <c>GameObject</c> in y-direction.
/// </summary>
public class Spin : MonoBehaviour
{
    /// <summary>
    /// if active, update rotatation by a bit.
    /// </summary>
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            this.transform.Rotate(new Vector3(0, 0.5f, 0));
        }
    }
}
