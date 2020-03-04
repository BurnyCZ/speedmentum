using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{


    // more this 




    public Button button; //this script is applied to every single button = this variable
    public KeyCode buttonKeyCode; //this script is applied to every single button and each button has its own KeyCode attached to it

    public Modes buttonMode;

    public MovementModeController movementModeController; //to read/change values of what movement modes/modifiers are enabled

    public Button startMode; //what mode is active at the start

    public MovementMenu movementMenu;

    void Start()
    {
        button = GetComponent<Button>();

        Graphic graphic = startMode.GetComponent<Graphic>();
        graphic.CrossFadeColor(startMode.colors.pressedColor, startMode.colors.fadeDuration, true, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            EnablePressedButtonAnimationWhenEnablingMovementMenu();
        }
    }
    public void KeyPress(KeyCode pressedKeyCode)
    {
        if (buttonKeyCode == pressedKeyCode) //if changing mode button was pressed
        {
            if (movementModeController.enabledModes.Contains(buttonMode)) { 
                FadeToColor(button.colors.pressedColor);
            //Debug.Log("FadeToColor(button.colors.pressedColor)");
            }
            else
            {
                FadeToColor(button.colors.normalColor);
            //Debug.Log("button.colors.normalColor");
        }
        //click the button
        //button.onClick.Invoke();
    }
    }
    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }
    
    public void EnablePressedButtonAnimationWhenEnablingMovementMenu()
    {
        Debug.Log("in function");
        Debug.Log(movementMenu.onAndOff);
        if (movementMenu.onAndOff)
        {
            Debug.Log("onAndOff true");
            if (movementModeController.enabledModes.Contains(buttonMode))
            {
                Debug.Log("animation");
                FadeToColor(button.colors.pressedColor);
            }
        }
    }
        
    

}
