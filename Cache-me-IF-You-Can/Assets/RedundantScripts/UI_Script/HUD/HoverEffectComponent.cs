using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class HoverEffectComponent : MonoBehaviour, IEndDragHandler,IBeginDragHandler
{
    //variable used to increase the scale
    [SerializeField]
    private Vector3 scaleIncrease = new Vector3(0.05f, 0.05f, 0.05f);
    [SerializeField]
    private Sprite highlightSprite;
    [SerializeField]
    private Sprite normalSprite;
    [SerializeField]
    private Sprite dragSprite;
    private Image imageComp;


    private void Awake()
    {
        imageComp = GetComponent<Image>();
    }
    /*
    public void onHover()
    {
        transform.localScale =  transform.localScale - scaleIncrease;
        imageComp.sprite = highlightSprite;
    }

    public void onHoverExit()
    {
        transform.localScale = transform.localScale + scaleIncrease;
        imageComp.sprite = normalSprite;
    }
    */

    //called on the end of the drag to enable raycasting and set the correct sprite
    public void OnBeginDrag(PointerEventData eventData)
    {
        imageComp.sprite = dragSprite;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        imageComp.sprite = highlightSprite;
    }
}
