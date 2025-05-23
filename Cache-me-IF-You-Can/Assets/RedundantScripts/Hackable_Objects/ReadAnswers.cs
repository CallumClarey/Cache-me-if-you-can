using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Script is attached to the button
/// it is used to read all the answers from the textboxes 
/// then calculate if the answer is right
/// </summary>
public class ReadAnswers : MonoBehaviour
{
    //--------------------------------
    //All script Attributes used
    //--------------------------------
    [SerializeField]
    private List<TMP_InputField> InputFields;
    [SerializeField]
    private TMP_Text textBox;
    private bool hackPassed;
    

    //-------------------------------------------
    //Used to check that the answers are correct
    //-------------------------------------------
    public void checkInputAnswers()
    {
        //loops through each object and read the correct value and field
        foreach (TMP_InputField obj in InputFields)
        {
            //Gets the user answer and correct answer as components from the input fields
            string correctAnswer = obj.GetComponent<fieldComponent>().FieldList[0]; 
            string userAnswer = obj.GetComponent<TMP_InputField>().text.ToUpper();

            //TODO: DELETE DEBUG CODE
            Debug.Log(correctAnswer);
            Debug.Log(userAnswer);

            //checks to see if the answers are true or false 
            if (verifyAnswers(correctAnswer,userAnswer)) 
            { 
                hackPassed = true;
            }
            else 
            { 
                hackPassed = false;
            }

        }
        if (hackPassed)
        {
            //TODO: DEBUG CODE DELTE LATER
            Debug.Log("Hack:" + hackPassed);
            textBox.text = "Hack Passed";

            //sets the hacking handler class to true 
            HackingHandler.doorHack = true;

            Invoke("openLevel", 4);
        }
        else { textBox.text = "Hack Failed"; }
    }

    //-------------------------------------------------------
    //Code used to verify the answers are correctly matching
    //helper function
    //------------------------------------------------------
    public bool verifyAnswers(string correctAnswer, string userAnswer)
    {
        if (correctAnswer == userAnswer) { return true; }
        else { return false; }
    }

    public void openLevel()
    {
        SceneManager.LoadScene("MainGame");
    }
}
