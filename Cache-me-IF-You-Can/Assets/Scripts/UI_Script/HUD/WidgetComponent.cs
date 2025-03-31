using UnityEngine;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class WidgetComponent : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //referance to the canvas
    [SerializeField] private Canvas canvas;
    //referance to the current object rectTransform
    private RectTransform rectTransform;
    //start parent referance
    private Transform startParent;
    //referance to the current image
    private Image image;

    /// <summary>
    /// Code required for docking to continue
    /// </summary>
    //referance to the graphics raycaster component
    [SerializeField] private GraphicRaycaster Raycast;
    //list of the hit results
    private List<RaycastResult> hitResults = new List<RaycastResult>();


    //gets the rect transform component on the awake of the object
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startParent = rectTransform.parent;
        image = GetComponent<Image>();
    }

    // Code runs on every begin drag event of the mouse
    public void OnBeginDrag(PointerEventData eventData)
    {
        //referance to the start parent
        startParent = transform.parent;
        Debug.Log("On drag" + startParent);
        //unparents the widget to allow for dragging
        transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //calls the graphics raycast
        GraphicRaycast();

        //checks to see if it has found a dock if not sets it to the start point
        if (!readRaycast())
        {
            transform.SetParent(startParent);
            Debug.Log(startParent);
            transform.localPosition = Vector3.zero;
        }
    }

    //function used to perform the graphics raycast
    private void GraphicRaycast()
    {
        //Create the PointerEventData with null for the EventSystem
        PointerEventData ped = new PointerEventData(null);
        //Set required parameters, in this case, mouse position
        ped.position = Input.mousePosition;
        //Raycast it
        Raycast.Raycast(ped, hitResults);
    }

    private bool readRaycast()
    {
        //-----------------------------------------------------------
        //checks the tag of the obj to see if is a dock or a widget
        //-----------------------------------------------------------
        for (int i = 0; i < hitResults.Count; i++)
        {
            //sets the game object to the hit result
            GameObject Obj = hitResults[i].gameObject;

            //checks to find a dock
            if (Obj.gameObject.tag == "Dock")
            {
                int compareInt = i - 2;

                //if equals - 1 dock the widget in the empty dock
                //else the widget requires a swap with another widget
                if (compareInt > - 1)
                {
                    //calls the function for the dock and then passes in the 2 widgets above it
                    Obj.GetComponent<WidgetDockComponent>().SwapWidgets(hitResults[i - 2].gameObject, hitResults[i - 1].gameObject);
                    //clears the list of hits
                    hitResults.Clear();
                }
                else //runs code for docking to an empty widget
                {
                    //calls the dock widget function on the dock
                    Obj.GetComponent<WidgetDockComponent>().DockWidget(gameObject);

                    //set the start parent to the 
                    startParent = Obj.GetComponent<RectTransform>().parent;
                    //clear the results list
                    hitResults.Clear();
                    return true;
                }
            }
           
        }
        return false;
    }

    //function used to externally read the list
    public bool readHitList()
    {
        GraphicRaycast();
        return hitResults[0].gameObject.tag == "Dock";
    }

    //setter for the start parent
    public void setStartParent(GameObject parent)
    {
        startParent = parent.transform;
    }
    public GameObject getStartParent()
    {
        return startParent.gameObject;
    }
}
