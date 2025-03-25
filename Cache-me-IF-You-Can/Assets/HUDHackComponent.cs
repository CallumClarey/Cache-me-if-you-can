using UnityEngine;
using TMPro;

public class HUDHackComponent : MonoBehaviour
{
    //----------------------------
    //Class Attributes
    //---------------------------
    //Hack 1 and 2 Attributes
    [SerializeField]
    private GameObject Hack1;
    [SerializeField]
    private GameObject Hack2;

    //Value used for the damping animation
    [SerializeField]
    private float _Damping; 

    //Used for the scale of the animation
    private Vector3 _MaxScale;
    private Vector3 _MinScale;

    //used for the vector positions
    private float _MinPosX;
    private float _MaxPosX;


    private void Start()
    {
        //sets the attributes of the scales
        _MaxScale = Hack1.transform.localScale;
        _MinScale = Hack2.transform.localScale;

        //sets the attribute of the postions
        _MaxPosX= Hack1.transform.localPosition.x;
        _MinPosX = Hack2.transform.localPosition.x;
    }
    // Update is called once per frame
    void Update()
    {
        Hack1.transform.localPosition = Vector3.Slerp(Hack1.transform.localPosition,new Vector3(_MinPosX, Hack1.transform.localPosition.y, 0),Time.deltaTime / _Damping);
        Hack1.transform.localScale = Vector3.Lerp(Hack1.transform.localScale,_MinScale,Time.deltaTime / _Damping);

    }
}
