using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDHackComponent : MonoBehaviour
{
    //----------------------------
    //Class Attributes
    //---------------------------
    //Hack 1 and 2 Attributes
    public GameObject Hack1;
    public GameObject Hack2;

    //On and off sprites
    public Sprite OffSprite;
    public Sprite OnSprite;
    public Sprite NullSprite;

    //Value used for the damping animation
    [SerializeField]
    private float _Damping;

    private Bounds xBounds;


    bool go = false;

    private void Start()
    {
        xBounds = Hack1.GetComponent<MeshRenderer>().bounds;
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("space"))
        {
            go = true;
            Hack1.GetComponent<Image>().sprite = OffSprite;
        }

        if (go)
        {
            Debug.Log("Started");
            //float _damperClamped = Mathf.Clamp(Time.deltaTime / _Damping, 0.05f, _Damping);
            //Hack1.transform.localPosition = Vector3.Lerp(Hack1.transform.localPosition, new Vector3(_MinPosX, 0, 0), Time.deltaTime / _Damping);
            //Vector3 finalLocation = new(,,,);
           // Hack1.transform.localPosition = Vector3.Lerp(Hack1.transform.localPosition,);
        }
    }
}
