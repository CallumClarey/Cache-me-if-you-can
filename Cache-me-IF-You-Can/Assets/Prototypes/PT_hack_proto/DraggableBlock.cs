using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableBlock : MonoBehaviour, IDragHandler, IBeginDragHandler, IDropHandler, IEndDragHandler
{
    private RectTransform dragRectTransform;
    private CanvasGroup canvasGroup;
    private Canvas parentCanvas;

    private void Awake()
    {
        dragRectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        parentCanvas = GetComponentInParent<Canvas>(); // Get the canvas it's in
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // Makes the block semi-transparent when dragged
        canvasGroup.blocksRaycasts = false; // Prevents other UI elements from blocking the drag
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta / parentCanvas.scaleFactor; // Moves the object with the cursor
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f; // Restores full opacity
        canvasGroup.blocksRaycasts = true; // Allows interactions again
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Handle what happens when the block is dropped on a valid target slot
    }
}
