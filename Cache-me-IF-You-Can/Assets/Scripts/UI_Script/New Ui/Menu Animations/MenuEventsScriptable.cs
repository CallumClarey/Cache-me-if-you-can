using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Class used to handle animation for the Hack/Bribe Menu System
/// </summary>
[CreateAssetMenu(fileName = "MenuEventsScriptable", menuName = "Scriptable Objects/MenuEventsScriptable")]
public class MenuEventsScriptable : ScriptableObject
{
    //all unity events for the menu states
    //these are used to handle animation:
    //@MenuSystemAnimComponent and @SubMenuAnimComponent
    [NonSerialized] public UnityEvent MenuOpened;
    [NonSerialized] public UnityEvent MenuClosed;
    [NonSerialized] public UnityEvent SubMenuOpened;
    [NonSerialized] public UnityEvent SubMenuClosed;
    
    //code used to call the menu closed and open events
    public void OpenMenu(){MenuOpened.Invoke();}
    public void CloseMenu(){MenuClosed.Invoke();}
    
    //code used to call the sub menu open and closed even
    public void OpenSubMenu(){SubMenuOpened.Invoke();}
    public void CloseSubMenu(){SubMenuClosed.Invoke();}
}
