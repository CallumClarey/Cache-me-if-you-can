using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WindowDragHandler : MonoBehaviour, IDragHandler
{
    //--------------------------------------
    //All class attributes
    //--------------------------------------
    private CustomDragHandler _dragHandler;
    private RectTransform _rectTransform;
    private Canvas _canvas;

    //------------------------------------
    //Runs on the before the first frame
    //------------------------------------
    private void Start()
    {
        //gets a reference to the windows rect transform
        _rectTransform = GetComponent<RectTransform>();
        //Gets a reference to the parents canvas
        _canvas = GetComponentInParent<Canvas>();
        //instantiates new drag handler
        _dragHandler = new CustomDragHandler(_rectTransform, _canvas);
    }

    //calls the dragging function inside the API
    public void OnDrag(PointerEventData eventData) => _dragHandler.OnDraggingObject(eventData);
    
}