// ./Assets/Scripts/HelpText.cs

using System.Collections;
using UnityEngine;

using TMPro;


public class HelpText : MonoBehaviour
{
    /*

    */

    // Declaring Variables
    private GameObject button, textArea;
    private Animator aniController;

    // Called when the script instance is being loaded.
    private void Awake()
    {
        /*

        */

        button = transform.GetChild(0).gameObject;
        textArea = transform.GetChild(0).GetChild(0).gameObject;
        aniController = this.GetComponent<Animator>();
    }

    // Called when
    public void StartAnimation(float delay, float width, string text)
    {
        /*

        */

        StartCoroutine(AnimationCoroutine(delay, width, text));
    }

    // Called when
    private IEnumerator AnimationCoroutine(float delay, float width, string text)
    {
        /*

        */

        yield return new WaitForSeconds(delay);

        button.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 30);
        textArea.GetComponent<TextMeshProUGUI>().text = text;
        aniController.Play("Base Layer.help_text");
    }
}
