using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject currentBlock;

    public void OnDrop(PointerEventData eventData)
    {
        DraggableBlock draggedBlock = eventData.pointerDrag?.GetComponent<DraggableBlock>();

        if (draggedBlock != null)
        {
            if (currentBlock != null)
            {
                draggedBlock.ReturnToOriginalPosition();
                return;
            }

            // Accept and place
            draggedBlock.transform.SetParent(transform);
            draggedBlock.transform.localPosition = Vector3.zero;

            currentBlock = draggedBlock.gameObject;
        }
    }

    public void ClearSlot(GameObject block)
    {
        if (currentBlock == block)
        {
            currentBlock = null;
        }
    }

    public bool HasBlock()
    {
        return currentBlock != null;
    }
}

