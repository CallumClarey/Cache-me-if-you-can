using UnityEngine;
using System;

public class HackableObject : MonoBehaviour
{
    public HackDefinition hackDefinition;

    // This event is raised when this object is selected
    public static event Action<HackableObject> OnHackSelected;

    void OnMouseDown()
    {
        // Only if this object has a hack assigned
        if (hackDefinition != null)
        {
            OnHackSelected?.Invoke(this);
        }
    }
}
