using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// API class for UI raycast calls.
/// </summary>
public class CustomUIRaycast
{
    //once the reference to graphics raycaster is set it cannot be changed
    private readonly GraphicRaycaster _raycaster;
    private List<RaycastResult> _hitResults = new List<RaycastResult>();
    
    //----------------------
    //class constructor 
    //----------------------
    public CustomUIRaycast(GraphicRaycaster raycaster){this._raycaster = raycaster;}
    
    //--------------------------------------------------
    //function used to perform the graphics raycast
    //--------------------------------------------------
    private void GraphicRaycast()
    {
        //Create the PointerEventData with null for the EventSystem
        PointerEventData pointerData = new PointerEventData(null)
        {
            //Set required parameters, in this case, mouse position
            position = Input.mousePosition
        };
        //perform graphics raycast
        _raycaster.Raycast(pointerData, _hitResults);
    }
    
    /// <summary>
    /// Used to check the tag of element hit at the given index.
    /// Returns null if the index is null.
    /// Returns null if the compare tag is false.
    /// Returns the game object if the hit is true.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="compareTag"></param>
    /// <returns></returns>
    public GameObject CheckIndexHitTag(int index, string compareTag)
    {
        //performs the graphic raycast
        GraphicRaycast();
        //checks to see if the item below the mouse is null
        if (_hitResults?[index].gameObject != null)
            return _hitResults[index].gameObject.CompareTag(compareTag) ? _hitResults[index].gameObject : null;
        //debugs to console and returns null
        Debug.Log("Window Null"); return null;

    }
}
