using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeController : MonoBehaviour
{
    public Text modeText;
    
    string[] begginingTextParts = { "[M] Mode: ", "Basic", "\r\n", "[N] Modifiers: "};//list of possible strings that will together make the final text in GUI
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

    int[] trueValuesIndexes = new int[0];

    void Start()
    {
        finalStringParts.AddRange(begginingTextParts); //add whole textparts string array into final list of strings (done like this so that its
        //ShowOnGui(); //shows mode and modifie
    }

    void Update()
    {
        Debug.Log("test");
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

    public int GetMode() //returns 1 of which  mode is active
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
        int amountOfTrueValues = 0;
        trueValuesIndexes = new int[modifiers.Length]; //int[], array of where true values are located in the modifier array
        for (int i = 0; i < modifiers.Length; i++)
        {
            trueValuesIndexes[i] = 69420; //fill the whole array with garbage value
        }
        for (int i = 0; i < modifiers.Length; ++i)//go through the whole modifiers array
        {
            if (modifiers[i] == true) //if you find a true value in modifier array
            {
                trueValuesIndexes[amountOfTrueValues] = i; //save its location to the array (first find will be at index 0, 2nd find at index 1 etc.)
                amountOfTrueValues++; //counter that tells how many times "true" is in the modifier array (for combinations)
            }
        }
        AddModifierToFinalStrings();// (amountOfTrueValues); 
    }
    public void AddModifierToFinalStrings()//(int amountOfTrueValues)
    {
        for (int i = 0; trueValuesIndexes[i] != 69420; i++) //goes through the indexes and if one isnt garbage value (if 2 are activated then the array will have normal values at index 0 and 1 and garbage values at other indexes
        {
                while (finalStringParts.Count > 4)
                {
                    finalStringParts.RemoveAt(finalStringParts.Count - 1); //this makes it so that when there's one modifier, its not added again but rather delted and then added again (or one is deleted and another one is added, not just appended)
                }
            finalStringParts.Add(modifiersTextParts[trueValuesIndexes[i]]); //then it adds it to the finalstrings (trueValuesIndexes have numbers that say at which index at modifiersTextParts is an active modifier
        }
    }

}
