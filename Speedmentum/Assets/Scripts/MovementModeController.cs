using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Modes
{
    Basic, //0
    LowGravity, //1
    HighGravity, //2
    IncreasingSpeed, //3
    DecreasingSpeed, //4
    MouseShake //5
}
public class MovementModeController : MonoBehaviour
{

    //enum modes { Basic, LowGravity, Test2}
    //enum modifiers { IncreasingSpeed, DecreasingSpeed, Test } //descreasing speed should be MouseShake
    public ButtonClickHandler[] buttonClickHandlers = new ButtonClickHandler[18];

    public List<Modes> enabledModes = new List<Modes>();

    public BasicMovement basicMovement;
    
    //1 = basic
    //2 = LowGravity //strafing or just flying where you are going for example
    //3 = HighGravity 
    //4 = IncreasingSpeed
    //5 = DecreasingSpeed
    //6 = mouseShake
    //7 = test

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ModeKeyPress(Modes mode)
    {
        if (!enabledModes.Contains(mode))
        {
            enabledModes.Add(mode);
        }
        else
        {
            enabledModes.Remove(mode);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enabledModes.Count; i++)
        {
            switch (enabledModes[i])
            {
                case Modes.Basic:
                    basicMovement.Movement();
                    break;
            }
        }


        //for (int i = 0; i<enabledModes.Count; i++)
        //{
        //    Debug.Log(enabledModes[i]);
        //}
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ModeKeyPress(Modes.Basic);
            buttonClickHandlers[0].KeyPress(KeyCode.Alpha1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ModeKeyPress(Modes.LowGravity);
            buttonClickHandlers[1].KeyPress(KeyCode.Alpha2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ModeKeyPress(Modes.HighGravity);
            buttonClickHandlers[2].KeyPress(KeyCode.Alpha3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //ModeKeyPress(Modes.Basic);
            buttonClickHandlers[3].KeyPress(KeyCode.Alpha4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //ModeKeyPress(Modes.Basic);
            buttonClickHandlers[4].KeyPress(KeyCode.Alpha5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //ModeKeyPress(Modes.Basic);
            buttonClickHandlers[5].KeyPress(KeyCode.Alpha6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            //ModeKeyPress(Modes.Basic);
            buttonClickHandlers[6].KeyPress(KeyCode.Alpha7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            //ModeKeyPress(Modes.Basic);
            buttonClickHandlers[7].KeyPress(KeyCode.Alpha8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            //ModeKeyPress(Modes.Basic);
            buttonClickHandlers[8].KeyPress(KeyCode.Alpha9);
        }
        else if (Input.GetKeyDown(KeyCode.F1))
        {
            ModeKeyPress(Modes.IncreasingSpeed);
            buttonClickHandlers[9].KeyPress(KeyCode.F1);
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            ModeKeyPress(Modes.DecreasingSpeed);
            buttonClickHandlers[10].KeyPress(KeyCode.F2);
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            ModeKeyPress(Modes.MouseShake);
            buttonClickHandlers[11].KeyPress(KeyCode.F3);
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            //ModeKeyPress(Modes.Basic);
            buttonClickHandlers[12].KeyPress(KeyCode.F4);
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            //ModeKeyPress(Modes.Basic);
            buttonClickHandlers[13].KeyPress(KeyCode.F5);
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            //ModeKeyPress(Modes.Basic);
            buttonClickHandlers[14].KeyPress(KeyCode.F6);
        }
        else if (Input.GetKeyDown(KeyCode.F7))
        {
            //ModeKeyPress(Modes.Basic);
            buttonClickHandlers[15].KeyPress(KeyCode.F7);
        }
        else if (Input.GetKeyDown(KeyCode.F8))
        {
            //ModeKeyPress(Modes.Basic);
            buttonClickHandlers[16].KeyPress(KeyCode.F8);
        }
        else if (Input.GetKeyDown(KeyCode.F9))
        {
            //ModeKeyPress(Modes.Basic);
            buttonClickHandlers[17].KeyPress(KeyCode.F9);
        }
    }

}
