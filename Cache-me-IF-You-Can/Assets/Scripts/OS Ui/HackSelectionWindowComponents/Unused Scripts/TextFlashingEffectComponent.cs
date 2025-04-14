using System;
using UnityEngine;
using TMPro;
public class TextFlashingEffectComponent : MonoBehaviour
{
    [SerializeField]private float flashDuration = 0.2f;
    //reference the component
    private TextMeshProUGUI _text;
    private void OnEnable()
    {
        //gets the text component
        _text = GetComponent<TextMeshProUGUI>();
        Invoke(nameof(HideText),flashDuration);
    }
    //-----------------------------------------
    //Function required to create the effect
    //-----------------------------------------
    private void HideText()
    {
        _text.alpha = 0f;
        Invoke(nameof(ShowText),flashDuration);
    }

    private void ShowText()
    {
        _text.alpha = 1f;
        Invoke(nameof(HideText),flashDuration);
    }
}
