using System;
using UnityEngine;

/// <summary>
/// Attaches onto the menu navigation Game Object
/// </summary>
public class MenuNaviComponent : MonoBehaviour
{
    private MenuEventsScriptable MenuEvents;
    //Game object references to the two menu states
    public GameObject menuSystem;
    public GameObject hackMenu;
    public GameObject bribeMenu;

    private void OnEnable()
    {
       
    }

    //-------------------------------------
    //Code used to handle menu behaviour
    //-------------------------------------
    //Enables the Bribe Menu
    public void EnableBribeMenu()
    {
        //sets the state of the Menu Navigation to true
        hackMenu.SetActive(false);
        bribeMenu.SetActive(true);
    }
    //Enables the hack Menu
    public void EnableHackMenu()
    {
        //sets the state of the Menu Navigation to true
        hackMenu.SetActive(true);
        bribeMenu.SetActive(false);
    }
    public void CloseSubMenus()
    {
        //checks to see if the currently any sub menus open
        if (hackMenu.activeSelf || bribeMenu.activeSelf)
        {
            //closes all the sub menu's
            hackMenu.SetActive(false);
            bribeMenu.SetActive(false);
            //returns
            return;
        }
        //runs if there is no sub Menus to close
        CloseMenu();
    }
    //closes the menu fully 
    private void CloseMenu() { menuSystem.SetActive(false); }
}
