using System;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Class used to control the opening and closing of the interaction menu
/// Note 18/04/2025: May require reprogramming to use event system (That's never going to happen)
/// </summary>
public class MenuControllerComponent : MonoBehaviour
{
    //reference to the menu component system
    [SerializeField] private GameObject interactionMenu;
    //bool to determine menu on or off
    private bool _menuOn = false;

    //Only runs on the first frame
    private void Start() => interactionMenu.SetActive(_menuOn);
    
    //----------------------------------------------
    //Runs multiple times per frame 
    //open and closes the menu on a button press 
    //-----------------------------------------------
    private void OnGUI()
    {
        //sets the menu opener to the current event 
        if((!Event.current.Equals(Event.KeyboardEvent("Y")))){return;}
        //toggles the menu on and off
        _menuOn = !_menuOn;
        //turns the menu off
        interactionMenu.SetActive(_menuOn);
        //pauses the game and unpauses the game
        //Time.timeScale = _menuOn ? 0f : 1f;
    }
}
