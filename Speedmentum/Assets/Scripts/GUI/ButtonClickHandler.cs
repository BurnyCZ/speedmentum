using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{

    public Button button; //this script is applied to every single button = this variable
    public string buttonFunction; //this script is applied to every single button and each button has its own function assigned to it

    //public Modes buttonMode; //each button has their own buttonMode set to each other (thats set up in the unity editor)

    bool isEnabled = false;

    //public MovementModeController movementModeController; //to read/change values of what movement modes/modifiers are enabled

    //public Button startMode; //what mode is active at the start

    public MovementMenu movementMenu; //menu that is enabled by "M"

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void KeyPress(string requestedFunction) //each button has this function and with each mode key press on the keyboard it scans all the buttons and tries to find which button's KeyCode is the same like the one that just got pressed
    {
        if (buttonFunction == requestedFunction) 
        {
            isEnabled = !isEnabled;
            //if (MovementModeController.enabledModes.Contains(buttonMode)) //if the enabledModes list that includes all currently enabled modes has the button's set button mode in it, it plays an animation of the button being pressed, if it doesnt include it, it reverts that animation (animation of the key being unpressed)
            if (isEnabled)
            {
                FadeToColor(button.colors.pressedColor);
            //Debug.Log("FadeToColor(button.colors.pressedColor)");
            }
            else
            {
                FadeToColor(button.colors.normalColor);
            //Debug.Log("button.colors.normalColor");
            }
        }
    }
    void FadeToColor(Color color) //animation of the key being pressed or unpressed, pressedColor and normalColor
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }
    
   

}
