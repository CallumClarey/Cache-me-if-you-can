using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class ReadTerminalInputComponent : MonoBehaviour
{
    //reference to the class input field
    private TMP_InputField _inputField;
    private string _terminalInputText;
    private int _lastTokenPosition;
    private string[] _tokensArray = new string[5];

    //----------------------------------------
    //Start retrieves all required references
    //---------------------------------------
    private void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
    }
    
    //----------------------------------
    //function used to read the input
    //----------------------------------
    public void ReadTerminalInput()
    {
        //reads the input
        _terminalInputText = _inputField.text;
        //sets text to blank
        _inputField.text = "";
        ScanInput(_terminalInputText);
        Debug.Log(_tokensArray.ToString());
    }

    private void ScanInput(string input)
    {
        //sets the last token position to zero
        _lastTokenPosition = 0;
        //loops through the string
        for (int index = 0; index < input.Length; index++)
        {
            if (input[index] != ' ') {continue;};
            _tokensArray.Append(input.Substring(_lastTokenPosition, index - 1));
            index++;
            _lastTokenPosition = index;
        }
    }

  
    
   
    
}
