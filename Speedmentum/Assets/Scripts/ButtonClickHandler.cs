using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public Button button; //this script is applied to every single button = this variable
    public KeyCode keyCode; //this script is applied to every single button and each button has its own KeyCode attached to it
    public MovementModeController movementModeController; //to read/change values of what movement modes/modifiers are enabled

    public Button startMode; //what mode is active at the start

    void Start()
    {
        button = GetComponent<Button>();

        Graphic graphic = startMode.GetComponent<Graphic>();
        graphic.CrossFadeColor(startMode.colors.pressedColor, startMode.colors.fadeDuration, true, true);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("test");
        if (Input.GetKeyDown(keyCode)) //if changing mode button was pressed
        {
            if(movementModeController.ChangeMode(keyCode)) 
                FadeToColor(button.colors.pressedColor);
            else 
                FadeToColor(button.colors.normalColor);
            //click the button
            //button.onClick.Invoke();
        }
        //else if (Input.GetKeyUp(key))
        //{
        //    FadeToColor(button.colors.normalColor);
        //}
    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }
}
