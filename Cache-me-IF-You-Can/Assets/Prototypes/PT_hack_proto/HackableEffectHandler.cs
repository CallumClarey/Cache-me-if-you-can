using System;
using UnityEngine;

public class HackableEffectHandler : MonoBehaviour
{
    //------------------------------
    //Class attributes 
    //-------------------------------
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;
    private SpriteRenderer _spriteRenderer;
    
    
    
    //-------------------------
    //Function called on start
    //--------------------------
    private void Start(){ _spriteRenderer = GetComponent<SpriteRenderer>();}
    
    //---------------------------------------
    //Function called on disable and enable
    //---------------------------------------
    private void OnEnable()
    {
        HackEvents.OnHackCompiled += HandleHack;
    }

    private void OnDisable()
    {
        HackEvents.OnHackCompiled -= HandleHack;
    }

    
    
    //----------------------------------------
    //Code used to handle the hacking System
    //----------------------------------------
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

    //----------------------------------
    //Calls function for the overheat
    //----------------------------------
    void Overheat()
    {
        _spriteRenderer.sprite = offSprite;
        Debug.Log($"{name} overheated!");
        Invoke(nameof(ResetState),10f);
    }

    void TurnOff()
    {
        gameObject.SetActive(false);
        Debug.Log($"{name} turned off!");
        Invoke(nameof(ResetState),5f);
    }

    private void ResetState() { _spriteRenderer.sprite = onSprite; }
}
