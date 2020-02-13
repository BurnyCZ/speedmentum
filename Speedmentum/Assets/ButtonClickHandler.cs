using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    //https://www.youtube.com/watch?v=VFAXyUvwtYQ
    private Button _button;
    public KeyCode _Key;

    void Awake()
    {
        _button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_Key)) //if changing mode button was pressed
        {
            //if (_button.onClick.ToString())
            FadeToColor(_button.colors.pressedColor);
            _button.onClick.Invoke(); //click the button
        }
        else if (Input.GetKeyUp(_Key))
        {
            //FadeToColor(_button.colors.normalColor);
        }
    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, _button.colors.fadeDuration, true, true);

    }
}
