using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Modes //this is global variable, each mod has its own enum value
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
    public static float velocity; //static = global promena

    public ButtonClickHandler[] buttonClickHandlers = new ButtonClickHandler[18]; //includes all buttons from the movementmenu inside so its possible to interact with them in this code (the button objects are set in unity editor)

    public static List<Modes> enabledModes = new List<Modes>(); //has all modes that are enabled currently, has nothing in it by default, when 1-9 or f1-f9 is pressed, it gets a new mode in it, and according to whats inside, the game is releasing certain physics updates every tick

    public BasicMovement basicMovement; //each mode has its own object so that its possible to interact with them
    public LowGravity lowGravity;
    public IncreasingSpeed increasingSpeed;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //for (int i = 0; i < enabledModes.Count; i++) //every tick it checks which modes are enabled and according to that it updates the physics in those certain ways, each basicMovement, lowGravity etc. have their own update functions localized in their own script that are all attached to the player and being disabled/enabled on key presses
        //{
        //    switch (enabledModes[i])
        //    {
        //        case Modes.Basic:
        //            basicMovement.Movement(); //function that updates the physics - gets released every tick if its enabled
        //            break;
        //        case Modes.LowGravity:
        //            lowGravity.Movement();
        //            break;
        //        case Modes.IncreasingSpeed:
        //            increasingSpeed.Movement();
        //            break;
        //    }
        //}

        if (enabledModes.Contains(Modes.Basic)) basicMovement.Movement();




        //the following lines of code are used to find out how many units per second i move each tick
        //Debug.Log((transform.position.x - lastXPos));
        //lastXPos = transform.position.x;


    }

    void Update()
    {
        //for (int i = 0; i<enabledModes.Count; i++)
        //{
        //    Debug.Log(enabledModes[i]);
        //}
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ModeKeyPress(Modes.Basic);
            buttonClickHandlers[0].KeyPress(KeyCode.Alpha1); //button pressed color animation on or off
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



        if (Input.GetKeyDown(KeyCode.T))
        {
            float slowTimeScale = UnityEngine.Random.Range(0.001f, 1f);
            float fastTimeScale = UnityEngine.Random.Range(1.001f, 10f);
            int randomBool = UnityEngine.Random.Range(0, 2);
            if (randomBool == 0)
            {
                Time.timeScale = slowTimeScale;
                Debug.Log("Timescale changed to " + slowTimeScale);
            }
            else
            {
                Time.timeScale = fastTimeScale;
                Debug.Log("Timescale changed to " + fastTimeScale);
            }

            
        }

    }

    void ModeKeyPress(Modes mode) //mode is an enum variable, each key press calls this function with its own enum variable corresponding to how its setup (1 - basic movement - on and off)
    {
        if (!enabledModes.Contains(mode)) //if the enabledModes list already includes the movement mode, it removes it, if not, it adds it
        {
            enabledModes.Add(mode);
        }
        else
        {
            enabledModes.Remove(mode);
        }


        if (enabledModes.Contains(Modes.Basic)) basicMovement.enabled = true; else basicMovement.enabled = false; //if basic mode is active, it enables it, if its not active, it disables it for performance 
        //if (enabledModes.Contains(Modes.LowGravity)) lowGravity.enabled = true; else lowGravity.enabled = false;
        //if (enabledModes.Contains(Modes.IncreasingSpeed)) increasingSpeed.enabled = true; else increasingSpeed.enabled = false;
    }

}
