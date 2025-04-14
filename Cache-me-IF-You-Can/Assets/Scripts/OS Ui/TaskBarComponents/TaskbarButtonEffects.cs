using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TaskbarButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   //--------------------------------
   //Button Sprites
   //--------------------------------
   [SerializeField] private Sprite unOpened;
   [SerializeField] private Sprite hoveredUnopened;
   [SerializeField] private Sprite opened;
   [SerializeField] private Sprite hoveredOpened;
   
   //Window the button is linked too
   [SerializeField] private GameObject linkedWindow;
   
   //----------------------------
   //Sprites to be used
   //------------------------------
   private Sprite _normal;
   private Sprite _hovered;
   private Image _imageRef;

   //function called before first frame
   private void Start()
   {
      //adds the event listeners
      MenuEvents.Current.OnWindowOpen += SetButtonOpen;
      MenuEvents.Current.OnWindowClose += SetButtonClose;
      _imageRef = GetComponent<Image>();
   }

   //-------------------------------------------
   //Event listeners to swap the sprites
   //---------------------------------------------
   private void SetButtonOpen(GameObject windowObject)
   {
      //checks to see if this is the linked window
      if (!linkedWindow.Equals(windowObject)) return;
      //sets sprites
       _normal = opened;
       _hovered = hoveredOpened;
       _imageRef.sprite = _hovered;
   }
   
   private void SetButtonClose(GameObject windowObject)
   {
      //checks to see if this is the linked window
      if (!linkedWindow.Equals(windowObject)) return;
      _normal = unOpened;
      _hovered = hoveredUnopened;
      _imageRef.sprite = _hovered;
   }
   
   //--------------------------------------------------
   //Pointer exit and enter effects 
   //--------------------------------------------------
   public void OnPointerEnter(PointerEventData eventData)
   {
      _imageRef.sprite = _hovered;
   }

   public void OnPointerExit(PointerEventData eventData)
   {
      _imageRef.sprite = _normal;
   }
   
}
