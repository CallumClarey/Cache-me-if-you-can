using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UI_Script
{
   public class ButtonEffectComponent : MonoBehaviour, IDeselectHandler, ISelectHandler
   {
      //All sprite required for effect
      [SerializeField] private Sprite normalSprite;
      [SerializeField] private Sprite hoveredSprite;
      [SerializeField] private Sprite pressedSprite;
      //reference to the component
      private Image _image;
   
      //Code ran on the start
      public void Start()
      {
         //retrieves the image component
         _image = GetComponent<Image>();
      }

      public void DebugCode(BaseEventData eventData)
      {
         Debug.Log("DEBUG HERE" + eventData);
      }
      
      //-------------------------------------------------
      //Code used to handle the effects of the button
      //-------------------------------------------------
   
      //ran on button hover
      //Set the sprite to the hovered effect
      public void OnHover(BaseEventData baseEventData){ _image.sprite = hoveredSprite; }
   
      //ran on the button hover exit
      //sets the sprite back to normal
      public void OnHoverExit(BaseEventData baseEventData) { _image.sprite = normalSprite; }
      
      //code runs when the object is selected
      //Sets the sprite back to normal
      public void OnSelect(BaseEventData baseEventData)
      {
         _image.sprite = pressedSprite;
         GetComponent<EventTrigger>().enabled = false;
      }
      
      //code runs when object is deselected 
      //Sets the sprite back to normal
      public void OnDeselect(BaseEventData baseEventData)
      {
         _image.sprite = normalSprite;
         GetComponent<EventTrigger>().enabled = true;
      }
      
   }
}
