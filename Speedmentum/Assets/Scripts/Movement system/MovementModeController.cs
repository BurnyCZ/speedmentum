using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public enum Modes //this is global variable, each mod has its own enum value
{
    Basic, //0
    Car
}
public class MovementModeController : MonoBehaviour
{ 
    public static float velocity; //static = global promena
    public static float velocityXZ;
    public static float velocityY;
    public static float velocityAboutToBeApplied; //static = global promena
    public static float velocityXZAboutToBeApplied;
    public static float velocityYAboutToBeApplied;

    

    public static List<Modes> enabledModes = new List<Modes>();

    public BasicMovement basicMovement; //each mode has its own object so that its possible to interact with them  

    public MovementMenu movementMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enabledModes.Contains(Modes.Basic)) basicMovement.Movement();
    }

    public void ModeKeyPress(Modes mode) //mode is an enum variable, each key press calls this function with its own enum variable corresponding to how its setup (1 - basic movement - on and off)
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
    void Update()
    {

    }
    

}
