using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using Unity.UI;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// Script used to handle all the main menu options and inputs 
/// script attached to the main menu script handler
/// EVERY TIME SCENE NEEDS LOADING IT MUST BE ADDED TO THE BUILD PROFILE OF PROJECT
/// </summary>
public class MenuHandler : MonoBehaviour
{
    //-----------------------------
    //All class attributes
    //-----------------------------
    //Game Objet referance to the canvas stored in the settings menu
    [SerializeField]
    private GameObject settingsMenu;
    //gameobject referance the main menu
    [SerializeField]
    private GameObject mainMenu;

    //--------------------------------------------------
    //Code ran when the main menu play button is pressed
    //loads the main game scene
    //TODO: Implement Level selection into the system 
    //--------------------------------------------------
    public void PlayGame() { SceneManager.LoadScene("MainGame"); }

    //------------------------
    //code for settings menu
    //------------------------
    public void SettingsMenu() {; }


    //----------------------------------------
    //Code run when the game is quit 
    //----------------------------------------
    public void QuitGame() { Application.Quit(); }



    //--------------------------------------------
    //Code used to create the button hover effect
    //--------------------------------------------
    public void OnCursorEnter(PointerEventData eventTrigger)
    {
        Debug.Log("On Enter");
    }

    public void OnCursorExit()
    {
        Debug.Log("On Exit");
    }
}
