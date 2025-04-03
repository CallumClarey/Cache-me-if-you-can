using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonGraphicsComponent : MonoBehaviour 
{
    //---------------------------------
    //Class references
    //---------------------------------
    [SerializeField]
    private ButtonEventScriptableObject buttonEvents;
    private Image _image;
    
    private void Start()
    { 
        //gets the image component on start
        _image = GetComponent<Image>();
    }
        
    //-------------------------------------------------------
    //Code used to remove and add listens to the script
    //------------------------------------------------------
    private void OnEnable() { buttonEvents.NewButtonPressed.AddListener(ButtonPressed); }
    private void OnDisable() { buttonEvents.NewButtonPressed.RemoveListener(ButtonPressed); }
        
    //-------------------------------------------------
    //Code used to listen for the button pressed event
    //-------------------------------------------------
    private void ButtonPressed(BaseEventData eventData) 
    {
        //checks to see if this is the current game Object 
        //if not current the object enables to the selected object
        if (eventData.selectedObject != gameObject)
        {
            //not the current object should be interactable
            GetComponent<ButtonFunctionComponent>().EnableButton();
            _image.sprite = buttonEvents.normalSprite;
        }
        else 
        {
            //it is current object and should not be interactable
            GetComponent<ButtonFunctionComponent>().DisableButton();
            _image.sprite = buttonEvents.pressedSprite;
        }
    }
    
    //-------------------------------------------------
    //Code used to handle the effects of the button
    //-------------------------------------------------
           
    //ran on button hover
    //Set the sprite to the hovered effect
    public void OnHover(BaseEventData baseEventData){ _image.sprite = buttonEvents.hoveredSprite; }
           
    //ran on the button hover exit
    //sets the sprite back to normal
    public void OnHoverExit(BaseEventData baseEventData) { _image.sprite = buttonEvents.normalSprite; }
    
    //code runs when the object is selected
    //Sets the sprite back to normal
    public void OnSelect(BaseEventData baseEventData) { _image.sprite = buttonEvents.pressedSprite; }

    //code runs after being invoked @ButtonPressed
    //Sets Sprite back to normal
    public void OnSinglePress() { _image.sprite = buttonEvents.normalSprite; }
}


