using UnityEngine;

public class HackableEffectHandler : MonoBehaviour
{
    private void OnEnable()
    {
        HackEvents.OnHackCompiled += HandleHack;
    }

    private void OnDisable()
    {
        HackEvents.OnHackCompiled -= HandleHack;
    }

    void HandleHack(GameObject target, CompileButton.HackAction action)
    {
        if (target != gameObject) return;

        switch (action)
        {
            case CompileButton.HackAction.Overheat:
                Overheat();
                break;
            case CompileButton.HackAction.TurnOff:
                TurnOff();
                break;
        }
    }

    void Overheat()
    {
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null) sr.color = Color.red;
        Debug.Log($"{name} overheated!");
    }

    void TurnOff()
    {
        gameObject.SetActive(false);
        Debug.Log($"{name} turned off!");
    }
}
