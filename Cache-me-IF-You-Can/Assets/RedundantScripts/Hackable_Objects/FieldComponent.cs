using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Script is a helper script used to set custom fields 
/// This can be done within the editor
/// all fields are stored as type string
/// </summary>
/// 
public class fieldComponent : MonoBehaviour
{
    //--------------------------------------------
    //All fields inside the component
    //--------------------------------------------
    [SerializeField]
    private List<string> fieldList;

    //bool to determine if they are case sensitve 
    [SerializeField] private bool caseSensitive;

    //---------------------------------------
    // Getter for the field List
    //---------------------------------------
    public List<string> FieldList { get { return fieldList; } }

    //--------------------------------------------
    //Method called before the first update frame
    //(Speed is not and issue as this loaded before the game starts)
    //--------------------------------------------
    public void Start()
    {
        //checks if case senstive is true
        if (!caseSensitive)
        {
            //loops through and makes all entries capitalised
            for(int n = 0; n < fieldList.Count; n++) {fieldList[n] = fieldList[n].ToUpper();}
        }
    }
}
