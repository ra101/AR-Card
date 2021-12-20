using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;


public class HelpText : MonoBehaviour
{
    private GameObject button, textArea;
    private Animator aniController;

    private void Awake()
    {
        button = transform.GetChild(0).gameObject;
        textArea = transform.GetChild(0).GetChild(0).gameObject;
        aniController = this.GetComponent<Animator>();
    }

    public void StartAnimation(float delay, float width, string text)
    {
        StartCoroutine(AnimationCoroutine(delay, width, text));
    }

    private IEnumerator AnimationCoroutine(float delay, float width, string text)
    {
        yield return new WaitForSeconds(delay);

        button.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 30);
        textArea.GetComponent<TextMeshProUGUI>().text = text;
        aniController.Play("Base Layer.help_text");
    }
}
