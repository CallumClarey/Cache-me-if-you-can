using UnityEngine;
using UnityEngine.Serialization;

public class MenuNavigationComponent : MonoBehaviour
{
   //all menu States 
    [SerializeField] private GameObject navigationMenu;
    [SerializeField] private GameObject hackSelectionMenu;
    [SerializeField] private GameObject bribeSelectionMenu;
    
    //Event for Menu Opening
    private Event _menuOpener = new();
    
    //Boolean values for the menus 
    private bool _menuOn = false;
    private bool _hackMenuOn = false;
    private bool _bribeMenuOn = false;

    //ran to make sure that interaction menu the is turned off 
    private void Start()
    {
        navigationMenu.SetActive(_menuOn);
    }
    
    //Runs all GUI events and can occur many times per frame
    private void OnGUI()
    {
        //gets the current menu event
        _menuOpener = Event.current;
        //checks to see if the menu interaction button is pressed
        if ((!Event.current.Equals(Event.KeyboardEvent("I")))) return;
        //Turns Menu ON and OFF
        _menuOn = !_menuOn;
        navigationMenu.SetActive(_menuOn);
    }
    
    //code used to close the menu
    public void CloseMenu()
    {
        _menuOn = false;
        navigationMenu.SetActive(_menuOn);
    }
    
    //-------------------------------------
    //Setters for Hack Menu States
    //-------------------------------------
    
    //function to open/close hack select
    public void TurnOnHackSubMenu()
    {
        //turns on the hack menu 
        _hackMenuOn = true;
        hackSelectionMenu.SetActive(_hackMenuOn);
    }
    
    //function to turn off the hack select menu
    public void TurnOffHackSubMenu()
    {
        //turns off the hack menu
        _hackMenuOn = false;
        hackSelectionMenu.SetActive(_hackMenuOn);
    }
    
    //-----------------------------------------
    //Setter for Bribe Menu States
    //-----------------------------------------
    
    //function to open/close bribe Menu
    public void TurnOnBribeSubMenu()
    {
        //turns on the bribe menu 
        _bribeMenuOn = true;
        bribeSelectionMenu.SetActive(_bribeMenuOn);
    }
    
    //function to turn off the bribe menu
    public void TurnOffBribeSubMenu()
    {
        //turns off the bribe menu
        _bribeMenuOn = false;
        bribeSelectionMenu.SetActive(_bribeMenuOn);
    }
}
