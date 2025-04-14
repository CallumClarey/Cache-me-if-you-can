using UnityEngine;
using System;

public class MenuEvents : MonoBehaviour
{
    //---------------------------------------
    //singleton reference to the events
    //------------------------------------------
    public static MenuEvents Current;
    private void Awake() => Current = this;
    
    //-------------------------------
    //Class Events
    //--------------------------------
    public event Action<GameObject> OnWindowOpen;
    public event Action<GameObject> OnWindowClose;
    
    //-----------------------------------------
    //methods called to invoke the event
    //------------------------------------------
    private void OnWindowOpenInvoke(GameObject windowObj) => OnWindowOpen?.Invoke(windowObj);
    private void OnWindowCloseInvoke(GameObject windowObj) => OnWindowClose?.Invoke(windowObj);
    
    //------------------------------------------------------------
    //Method used to flip between the different events triggered
    //------------------------------------------------------------
    public void OnUiButtonClick(GameObject windowObject)
    {
        //reads if the widow is active then closes or opens window based on that
        if (windowObject.activeSelf) OnWindowCloseInvoke(windowObject); 
        else OnWindowOpenInvoke(windowObject);

    }
}
