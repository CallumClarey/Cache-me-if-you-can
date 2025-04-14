using UnityEngine;

public static class HackEvents
{
    public delegate void CompileAction(GameObject target, CompileButton.HackAction action);
    public static event CompileAction OnHackCompiled;

    public delegate void HackTargetSelected(GameObject target);
    public static event HackTargetSelected OnTargetSelected;

    public static void TriggerHackCompiled(GameObject target, CompileButton.HackAction action)
    {
        OnHackCompiled?.Invoke(target, action);
    }

    public static void TriggerTargetSelected(GameObject target)
    {
        OnTargetSelected?.Invoke(target);
    }
}
