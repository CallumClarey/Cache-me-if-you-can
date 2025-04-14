using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableBlock : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform dragRectTransform;
    private CanvasGroup canvasGroup;
    private Canvas parentCanvas;

    private Transform originalParent;
    private Vector3 originalPosition;

    private void Awake()
    {
        dragRectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        parentCanvas = GetComponentInParent<Canvas>();
    }

    private void Start()
    {
        // Cache the original spawn location
        originalParent = transform.parent;
        originalPosition = transform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        // If dragged out of a DropSlot, clear that slot
        if (transform.parent.TryGetComponent(out DropSlot slot))
        {
            slot.ClearSlot(gameObject);
        }

        // Move to canvas so it draws on top
        transform.SetParent(parentCanvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta / parentCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // If dropped outside of a DropSlot, reset
        if (transform.parent == parentCanvas.transform)
        {
            ReturnToOriginalPosition();
        }
    }

    public void ReturnToOriginalPosition()
    {
        transform.SetParent(originalParent);
        transform.localPosition = originalPosition;
    }
}
