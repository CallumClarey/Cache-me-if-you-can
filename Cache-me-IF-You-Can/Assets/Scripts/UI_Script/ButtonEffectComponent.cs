using UnityEngine;
using UnityEngine.Serialization;
using Image = UnityEngine.UI.Image;

namespace UI_Script
{
   public class ButtonEffectComponent : MonoBehaviour
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
   
      //-------------------------------------------------
      //Code used to handle the effects of the button
      //-------------------------------------------------
   
      //ran on button hover
      //Set the sprite to the hovered effect
      public void OnHover() {_image.sprite = hoveredSprite; }
   
      //ran on the button hover exit
      //sets the sprite back to normal
      public void OnHoverExit(){_image.sprite = normalSprite; }
 
      //code ran on the pressed
      //sets the sprite to the pressed effect
      public void OnPressed() { _image.sprite = pressedSprite; }

      //code ran on the released
      //sets the sprite back to normal
      public void OnReleased(){_image.sprite = normalSprite;}
   
   }
}
