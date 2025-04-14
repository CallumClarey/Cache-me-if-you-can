using System;
using UnityEngine;

public class MenuSystemAnimComponent : MonoBehaviour
{
    [SerializeField]
    private float fadeTime = 0.5f;
    //referance to the menu system
    private CanvasGroup _menuSystem;
    
    //gets the canvas group component 
    private void Start() { _menuSystem = GetComponent<CanvasGroup>(); }
    
    private void OnEnable()
    {
        _menuSystem.alpha = 0;
        _menuSystem.LeanAlpha(1, fadeTime).setEaseOutExpo();
    }

    private void OnDisable()
    {
        _menuSystem.LeanAlpha(0, fadeTime).setEaseInExpo();
    }
}
