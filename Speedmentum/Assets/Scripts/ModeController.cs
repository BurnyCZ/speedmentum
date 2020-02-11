using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeController : MonoBehaviour
{
    public Text modeText;
    string[] begginingTextParts = { "[M] Mode: ", "Basic", "\r\n", "[N] Modifiers: ", "None"};//list of possible strings that will together make the final text in GUI
    string[] modesTextParts = { "Basic", "test1", "test2"}; //modes
    string[] modifiersTextParts = {"None", "Increasing Speed", "Mouse Shake", "test1", "test2" }; //modifiers
    List<string> finalStringParts = new List<string>(); //list of strings that WILL together make the final text in GUI
    string finalString; //the final string sent to GUI
    bool[] modes = new bool[] { true, false, false };
    //0 = basic
    //1 = test1 //strafing or just flying where you are going for example
    //2 = test2 
    bool[] modifiers = new bool[] { true, false, false, false, false };
    //0 = basic
    //1 = increasingSpeed
    //2 = mouseShake
    //3 = test
    //implement combos

    void Start()
    {
        finalStringParts.AddRange(begginingTextParts); //add whole textparts string array into final list of strings (done like this so that its
        //ShowOnGui(); //shows mode and modifie
    }

    void Update()
    {
        //this changes the mode to the next one
        if (Input.GetKeyDown(KeyCode.M)) //if changing mode button was pressed
        {
            ChangeMode(); //calls a method changemode from ModeController.cs, changes the mode to the next one   
            ShowOnGui();
        }
        if (Input.GetKeyDown(KeyCode.N)) //if changing mode button was pressed
        {
            //growingValue = 1; //set to default
            ChangeModifier(); //calls a method changemode from ModeController.cs, changes the mode to the next one        
            ShowOnGui();
        }
    }

    void ShowOnGui()
    {
        finalString = string.Concat(finalStringParts.ToArray()); //puts the prepared list of strings into one single string
        modeText.text = finalString; //shows the string on the screen
    }

    public int GetMode() //returns 1 of which 
    {
        for (int i = 0; i < modes.Length; ++i) //go through the modes array
        {
            if (modes[i]) //if true found
            return i; //return at which index it is
        }
        return 0; //impossible scenario i think
    }

    public void ChangeMode()
    {
        {
            for (int i = 0; i < modes.Length; ++i)//go through the whole modes array
            {
                if (modes[i]) //if you find a value thats true (active mode), go in the loop
                {
                    if (i == modes.Length - 1) //if the true value is at the last index
                    {
                        modes[i] = false; //set it to false
                        modes[0] = true; //set first one to true
                        //GUI text change begin
                        finalStringParts[1] = modesTextParts[0]; //last mode -> basic (first mode)
                        //GUI text change stop
                        break; //stop
                    }
                    else //if the true value wasnt at last index
                    {
                        modes[i] = false; //set it to false
                        modes[i + 1] = true; //set the next one to true (activate it)
                        //GUI text change begin
                        finalStringParts[1] = modesTextParts[i+1]; //last mode -> i+1 mode
                        //GUI text change stop
                        break; //stop
                        
                    }
                }
            }
        }
    }

    public void ChangeModifier()
    {
        
        for (int i = 0; i < modifiers.Length; ++i)//go through the whole modes array
        {
            if (modifiers[i]) //if you find a value thats true (active mode), go in the loop
            {
                if (i == modifiers.Length - 1) //if the true value is at the last index
                {
                    modifiers[i] = false; //set it to false
                    modifiers[0] = true; //set first one to true
                    //GUI text change begin
                    finalStringParts[4] = modifiersTextParts[0]; //last mode -> basic (first mode)
                    //GUI text change stop
                    break; //stop
                }
                else //if the true value wasnt at last index
                {
                    modifiers[i] = false; //set it to false
                    modifiers[i + 1] = true; //set the next one to true (activate it)
                    //GUI text change begin
                    finalStringParts[4] = modifiersTextParts[i+1]; //last mode -> i+1 mode
                    //GUI text change stop
                    break; //stop
                }
            }
        }
    }
}
