using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonFunctionComponent : MonoBehaviour
{
    //private enum for class states
    private enum ButtonType
    {
        SinglePress,
        InfinitePress,
    }
    //--------------------------------
    //All Class References
    //----------------------------------
    //scriptable object reference
    [SerializeField]
    private ButtonEventScriptableObject buttonEventsObject;
    //enum reference
    [SerializeField]
    private ButtonType buttonTypeValue;
    
    //---------------------------------------------------
    //Code Used to handle the logic of a button press
    //----------------------------------------------------
    //called the button press function
    public void OnClick() { buttonEventsObject.NewButtonPress();}
    
    //---------------------------------------------------
    //Functionality components called by the graphics
    //----------------------------------------------------
    //Enables button
    public void DisableButton()
    {
        //returns if the button is a single press 
        if(buttonTypeValue == ButtonType.InfinitePress){return;}
        GetComponent<Button>().interactable = false;
        GetComponent<EventTrigger>().enabled = false;
    }
    //Disables button
    public void EnableButton()
    {
        //returns if the button is a single press 
        if(buttonTypeValue == ButtonType.InfinitePress){return;}
        GetComponent<EventTrigger>().enabled = true;
        GetComponent<Button>().interactable = true;
    }
    
    
}
