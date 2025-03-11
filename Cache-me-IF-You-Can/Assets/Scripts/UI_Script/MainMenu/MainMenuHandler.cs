using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script used to handle all the main menu options and inputs 
/// script attached to the main menu script handler
/// </summary>
public class MainMenuHandler : MonoBehaviour
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

    public void SettingsMenu() {; }
    //----------------------------------------
    //Code run when the game is quit 
    //----------------------------------------
    public void QuitGame() { Application.Quit(); }

}
