using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

public class InputHandlerHackingProblem : MonoBehaviour
{
    //--------------------------------
    //All script Attributes used
    //--------------------------------
    [SerializeField]
    private List<TMP_InputField> AvalibleInputFields;
    //set to minus one so the first tab works
    private int currentIndex = -1;

    /*
    private void OnGUI()
    {
        if (TMP_InputField.SelectionEvent != true )
        {

        }
        //runs when the tab key is pressed
        if (Event.current.Equals(Event.KeyboardEvent("Tab"))) 
        {
            
            //cycles through avaliable text boxes
            Debug.Log("Tab has been pressed");
            if (currentIndex < AvalibleInputFields.Count) { currentIndex++; }
            else { currentIndex = 0; }

            //focuses the user onto inputfield with the index inside the Avaliable InputFields
            AvalibleInputFields[currentIndex].Select();
            AvalibleInputFields[currentIndex].ActivateInputField();
        }
    }*/
}
    
