using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject currentBlock;

    public void OnDrop(PointerEventData eventData)
    {
        DraggableBlock draggedBlock = eventData.pointerDrag.GetComponent<DraggableBlock>();

        if (draggedBlock != null)
        {
            draggedBlock.transform.SetParent(transform);
            draggedBlock.transform.localPosition = Vector3.zero;

            currentBlock = draggedBlock.gameObject;
        }
    }

    public bool HasBlock()
    {
        return currentBlock != null;
    }
}
