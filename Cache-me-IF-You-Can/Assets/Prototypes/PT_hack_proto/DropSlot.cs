using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject currentBlock; // This will store the block that is currently placed in the slot

    public void OnDrop(PointerEventData eventData)
    {
        DraggableBlock draggedBlock = eventData.pointerDrag.GetComponent<DraggableBlock>();

        if (draggedBlock != null)
        {
            // Place the dragged block in this slot
            draggedBlock.transform.SetParent(transform); // Set this slot as the parent of the dragged block
            draggedBlock.transform.localPosition = Vector3.zero; // Position it inside the slot

            // Store the block in the slot's currentBlock
            currentBlock = draggedBlock.gameObject;
        }
    }

    // Method to check if a block is placed in the slot
    public bool HasBlock()
    {
        return currentBlock != null;
    }
}
