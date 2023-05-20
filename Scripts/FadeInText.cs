using System.Collections;
using UnityEngine;
using TMPro;

public class FadeInText : MonoBehaviour
{
    private TextMeshProUGUI tmproText;
    private float fadeInDuration = 2f;

    private string textToDisplay = "";

    public string TextToDisplay { get => textToDisplay; set => textToDisplay = value; }

    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }
    
    private void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        tmproText.color = new Color(tmproText.color.r, tmproText.color.g, tmproText.color.b, 0);
        tmproText.text = textToDisplay;
        float currentTime = 0f;
        while (currentTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / fadeInDuration);
            tmproText.color = new Color(tmproText.color.r, tmproText.color.g, tmproText.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}