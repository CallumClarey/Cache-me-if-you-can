using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    //reference to the normal and hovered sprite images
    [SerializeField]private Sprite normal;
    [SerializeField]private Sprite hovered;
    //reference to the image component
    private Image _image;
    //reference to the button text
    private TMP_Text _buttonText;
    private readonly Vector3 _enlargedScale = new(0.05f, 0.05f,0.05f);
    
    //------------------------------------
    // Gets required references on start
    //------------------------------------
    private void Start()
    {
        //gets a reference to image component
        _image = GetComponent<Image>();
        //gets the component in the game object below 
        _buttonText = GetComponentInChildren<TMP_Text>();        
    }
    
    //---------------------------------------------
    //Interfaces required for hovered effect
    //---------------------------------------------
    
    //sets sprite to hovered and changes text colour
    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.sprite = hovered;
        _buttonText.color = Color.white;
    }
    
    //Sets sprite to normal and changes text colour to black
    public void OnPointerExit(PointerEventData eventData)
    {
        _image.sprite = normal;
        _buttonText.color = Color.black;
    }
    
    //-----------------------------------------
    //functions require for enlarge press
    //-----------------------------------------
    public void OnPointerClick(PointerEventData eventData) => OnPressEnlarger();
    
    private void OnPressEnlarger()
    {
        transform.transform.localScale = Vector3.one - _enlargedScale;
        Invoke(nameof(OnPressDescale), 0.3f);
    }

    private void OnPressDescale()
    {
        transform.transform.localScale = Vector3.one + _enlargedScale;
    }

    
}
