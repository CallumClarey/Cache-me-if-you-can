using System;
using UnityEngine;


/// <summary>
/// Class component used to animate the submenus
/// </summary>
public class SubMenuAnimComponent : MonoBehaviour
{
    [SerializeField] private float scaleTime = 0.8f;
    private Vector3 _originalScale;
    
    //gets the original scale of the object
    private void Start()
    {
        //sets the start scale to zero
        _originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    private void OnEnable()
    {
        transform.LeanScale(_originalScale, scaleTime).setEaseOutSine();
    }

    private void OnDisable()
    {
        transform.LeanScale(Vector2.zero, scaleTime).setEaseInBack();
    }
}
