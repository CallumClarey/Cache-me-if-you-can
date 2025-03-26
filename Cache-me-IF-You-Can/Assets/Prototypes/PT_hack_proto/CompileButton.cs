using UnityEngine;
using UnityEngine.UI;

public class CompileButton : MonoBehaviour
{
    public Button compileButton; // Assign in Inspector
    public DropSlot[] dropSlots; // Array to store the drop slots where blocks will go (e.g., Slot1, Slot2)
    public GameObject targetObject; // The 2D object to be affected (e.g., a Camera or a HackableObject)
    
    // Create enums to represent hack actions
    public enum HackAction
    {
        None,
        TurnOff,
        Overheat
    }
    
    private HackAction currentAction = HackAction.None;

    void Start()
    {
        compileButton.onClick.AddListener(OnCompileButtonPressed);
    }

    void OnCompileButtonPressed()
    {
        // Check which action was selected based on the blocks in the slots
        currentAction = DetermineAction();

        if (currentAction != HackAction.None)
        {
            ExecuteHack();
        }
        else
        {
            Debug.Log("Failed to compile the hack. Invalid combination.");
        }
    }

    HackAction DetermineAction()
    {
        // Check the blocks in the drop slots to determine which action is being executed
        foreach (var slot in dropSlots)
        {
            // Check if a block is placed in the slot
            if (slot.HasBlock())
            {
                // Get the block and check its name or type to decide what hack to execute
                if (slot.currentBlock != null)
                {
                    if (slot.currentBlock.name.Contains("Overheat"))
                    {
                        return HackAction.Overheat; // If OverheatBlock is in the slot, execute Overheat
                    }
                    else if (slot.currentBlock.name.Contains("TurnOff"))
                    {
                        return HackAction.TurnOff; // If TurnOffBlock is in the slot, execute Turn Off
                    }
                }
            }
        }

        return HackAction.None; // No valid action found
    }

    void ExecuteHack()
    {
        switch (currentAction)
        {
            case HackAction.Overheat:
                OverheatTarget();
                break;

            case HackAction.TurnOff:
                TurnOffTarget();
                break;

            default:
                Debug.Log("Invalid action.");
                break;
        }
    }

    void OverheatTarget()
    {
        // Example Overheat effect (change color to indicate overheating)
        SpriteRenderer targetSprite = targetObject.GetComponent<SpriteRenderer>();
        if (targetSprite != null)
        {
            targetSprite.color = Color.red; // Set target color to red to simulate overheating
            Debug.Log("Target overheated!");
        }
    }

    void TurnOffTarget()
    {
        // Example Turn Off effect (disable the object or hide it)
        targetObject.SetActive(false); // Disable the object (or make it invisible)
        Debug.Log("Target turned off!");
    }
}
