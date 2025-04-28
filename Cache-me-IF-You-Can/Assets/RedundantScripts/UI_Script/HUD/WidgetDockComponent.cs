using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WidgetDockComponent : MonoBehaviour
{
    //-------------------------------
    //All class attributes
    //------------------------------
    //referance to the child widget
    [SerializeField] private GameObject childWidget;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite highlightedSprite;

    /// <summary>
    /// Code required for docking to continue
    /// </summary>
    //referance to the graphics raycaster component
    [SerializeField] private GraphicRaycaster Raycast;
    //list of the hit results
    private List<RaycastResult> hitResults = new List<RaycastResult>();


    //ran on the first frame 
    void Start()
    {
        //centres the starting child component
        if (childWidget != null)
        {
           //centres the child on the boot
           childWidget.transform.localPosition = Vector3.zero;
        }
    }

    public void DockWidget(GameObject widget)
    {
        //---------------------------------------
        // Place the widget block in this slot
        //---------------------------------------
        // Set this slot as the parent of the dragged block
        widget.transform.SetParent(transform);
        // Position it inside the slot
        widget.transform.localPosition = Vector3.zero;

        // Store the block in the slot's currentBlock
        childWidget = widget.gameObject;
        //refers back to the widget Comp then sets the start parent to the new parent dock
        widget.GetComponent<WidgetComponent>().SetStartParent(this.gameObject);

    }

    //takes the parameters of the docked widget and the current widget from the @WidgetCompoent
    public void SwapWidgets(GameObject draggingWidget, GameObject dockedWidget)
    {
        //variables used referance the components
        WidgetComponent draggingWidgetComp = draggingWidget.GetComponent<WidgetComponent>();
        WidgetComponent dockedWidgetComp = dockedWidget.GetComponent<WidgetComponent>();

        //sets the start parent of the currently dragged widget
        dockedWidgetComp.SetStartParent(draggingWidgetComp.GetStartParent());

        //parents the currently docked widget to dragged widgets parent
        dockedWidget.gameObject.transform.SetParent(dockedWidgetComp.GetStartParent().transform);
        dockedWidget.transform.localPosition = Vector3.zero;

        //calls the function to dock the dragging widget
        DockWidget(draggingWidget);

    }

    //----------------------------------
    //Code used to change the sprites
    //----------------------------------
    public void OnHover()
    {
       //calls the raycast
       GraphicRaycast();
        //checks to see if the player is dragging a widget
        if (hitResults[0].gameObject.CompareTag("Widget"))
        {
            GetComponent<Image>().sprite = highlightedSprite;
        }
    }
    //sets the sprite to normal on the hover exit
    public void OnHoverExit()
    {
        GetComponent<Image>().sprite = normalSprite;
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


}
