using UnityEngine;
using UnityEngine.UI;

public class CompileButton : MonoBehaviour
{
    public Button compileButton;
    public DropSlot[] dropSlots;
    public GameObject targetObject;

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
        currentAction = DetermineAction();

        if (currentAction != HackAction.None)
        {
            HackEvents.TriggerHackCompiled(targetObject, currentAction);
        }
        else
        {
            Debug.Log("Invalid hack combination.");
        }
    }

    HackAction DetermineAction()
    {
        foreach (var slot in dropSlots)
        {
            if (slot.HasBlock())
            {
                if (slot.currentBlock.name.Contains("Overheat"))
                    return HackAction.Overheat;
                else if (slot.currentBlock.name.Contains("TurnOff"))
                    return HackAction.TurnOff;
            }
        }
        return HackAction.None;
    }
}
