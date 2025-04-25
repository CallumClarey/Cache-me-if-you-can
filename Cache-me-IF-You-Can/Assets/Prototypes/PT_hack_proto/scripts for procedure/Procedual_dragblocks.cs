using UnityEngine;
using System.Collections.Generic;

public class DropSlProcedual_dragblocks : MonoBehaviour
{
    public List<RectTransform> dropSlotRects; // Your existing slot transforms

    public void LoadHackableObjectUI(TestBlockData data)
    {

        for (int i = 0; i < dropSlotRects.Count; i++)
        {
            if (i < data.slotPositions.Count)
            {
                dropSlotRects[i].anchoredPosition = data.slotPositions[i];
                dropSlotRects[i].gameObject.SetActive(true);
            }
            else
            {
                dropSlotRects[i].gameObject.SetActive(false);
            }
        }

        // You can now also pass data.blockNames to your draggable block system (coming next)
    }
}