using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompileButton : MonoBehaviour
{
    public Button compileButton;
    public DropSlot[] dropSlots;
    public GameObject targetObject;

    [Header("UI")]
    public TMP_Text outputText; // <-- Reference to TMP text output

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
            ShowHackOutput(currentAction);
        }
        else
        {
            ShowHackOutput(HackAction.None);
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

    void ShowHackOutput(HackAction action)
    {
        switch (action)
        {
            case HackAction.Overheat:
                outputText.text = " Overheat initiated! Target is overheating.";
                break;
            case HackAction.TurnOff:
                outputText.text = " Power down successful! Target turned off.";
                break;
            case HackAction.None:
            default:
                outputText.text = " Hack failed. Invalid code block combination.";
                break;
        }
    }
}
