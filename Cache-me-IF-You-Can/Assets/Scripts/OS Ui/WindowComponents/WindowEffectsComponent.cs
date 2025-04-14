using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class WindowEffectsComponent : MonoBehaviour
{
    //reference to the amount of time the scale should take
    [SerializeField] private float scaleTime = 0.5f;
    //the original scale of the menu
    private Vector3 _originalScale;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _originalScale = transform.localScale;
    }
    
    //--------------------------------------
    //Effect animations for the windows
    //--------------------------------------
    public void WindowOpenEffect()
    {
        transform.LeanScale(_originalScale, scaleTime).setEaseOutSine();
    }
    
    public void WindowCloseEffect()
    {
        Debug.Log("WindowCloseAnim");
        transform.LeanScale(Vector3.zero, scaleTime).setEaseInSine();
    }
    
    //------------------------------
    //Class getter for scale time
    //------------------------------
    public float GetScaleTime() => scaleTime;
    
   
}
