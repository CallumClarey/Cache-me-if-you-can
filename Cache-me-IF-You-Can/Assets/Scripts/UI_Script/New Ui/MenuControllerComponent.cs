using System;
using UnityEngine;

public class MenuControllerComponent : MonoBehaviour
{
    //referance to the menu component system
    [SerializeField]
    private GameObject navigationMenu;
    //bool to determine menu on or off
    private bool _menuOn = false;

    //Only runs on the first frame
    private void Start()
    {
        navigationMenu.SetActive(_menuOn);
    }

    //RUNS ON EVERY GUI EVENT CALL
    private void OnGUI()
    {
        //sets the menu opener to the current event 
        if((!Event.current.Equals(Event.KeyboardEvent("I")))){return;}
        //toggles the menu on and off
        _menuOn = !_menuOn;
        //turns the menu off
        navigationMenu.SetActive(_menuOn);
    }
}
