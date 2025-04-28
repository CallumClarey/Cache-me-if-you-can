using UnityEngine;
using System;
using System.Collections;
using System.Threading.Tasks;

/// <summary>
/// Note: For the window to function properly it must be enabled upon the start call
/// If this is not followed it WILL BREAK 
/// </summary>
public class WindowActionComponent : MonoBehaviour
{
    //effect component for the window
    private WindowEffectsComponent _windowEffectsComponent;
    //reference to the scale time in the effect
    private float _scaleTime;
    
    //----------------------------------------------------------
    //Adds listeners to the window event 
    //Sets the timescale for animations and handles dependency
    //----------------------------------------------------------
    private void Start()
    {
        MenuEvents.Current.OnWindowOpen += OpenWindow;
        MenuEvents.Current.OnWindowClose += CloseWindow;
        _windowEffectsComponent = GetComponent<WindowEffectsComponent>();
        //check to see if the effect component is null is so scale time is set to zero
        _scaleTime = _windowEffectsComponent == null ? 0f : _windowEffectsComponent.GetScaleTime();
        Disable();
    }
    //------------------------------------
    //Opens the window 
    //------------------------------------
    public void OpenWindow(GameObject window)
    {
        if(!gameObject.Equals(window)) return;
        _windowEffectsComponent?.WindowOpenEffect();
        window.SetActive(true);
    }
    //--------------------------------------
    //Closes the window
    //-----------------------------------------
    public void CloseWindow(GameObject window)
    {
        if (!gameObject.Equals(window)) return;
        _windowEffectsComponent?.WindowCloseEffect();
        //invokes the disable after the scale time
        Invoke(nameof(Disable),_scaleTime);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
