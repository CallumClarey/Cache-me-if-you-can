using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Class used to handle dragging of UI Object
/// Example use cases: Windows and Widgets
/// </summary>
public class CustomDragHandler
{
    //reference to the RectComponent
    private RectTransform _rectTransform;
    //reference to the canvas component
    private Canvas _canvas;


    //--------------------------------------
    //Constructor for the class
    //------------------------------------
    public CustomDragHandler(RectTransform rectTransform, Canvas canvas)
    {
        _rectTransform = rectTransform;
        _canvas = canvas;
    }

    /// <summary>
    /// Function used to perform dragging of objects
    /// Drags are bound to the canvas 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDraggingObject(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
    public void OnDraggingObject(PointerEventData eventData, bool isBound){}
    
}
