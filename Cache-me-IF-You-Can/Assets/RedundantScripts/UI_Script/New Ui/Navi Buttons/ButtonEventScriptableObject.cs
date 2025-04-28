using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "ButtonEventScriptableObject", menuName = "Scriptable Objects/ButtonEventScriptableObject")]
public class ButtonEventScriptableObject : ScriptableObject
{
    //public fields for the different sprites
    public Sprite normalSprite;
    public Sprite hoveredSprite;
    public Sprite pressedSprite;
    //Events that other scripts can subscribe to listen too
    [System.NonSerialized] public UnityEvent<BaseEventData> NewButtonPressed;
    
    //creates new instance of New ButtonPressed Event
    public void OnEnable()
    {
        //checks to see if the new button press is null if not it creates an instance
        if(NewButtonPressed == null)
            NewButtonPressed = new UnityEvent<BaseEventData>();
    }
    
    //Function called to invoke a new button press
    public void NewButtonPress()
    {
        //gets the current event data
        //in this instance the event data of the button pressed
        BaseEventData eventData = new(EventSystem.current);
        NewButtonPressed.Invoke(eventData);
    }
}
