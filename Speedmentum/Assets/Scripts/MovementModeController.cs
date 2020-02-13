using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModeController : MonoBehaviour
{
    //enum modes { Basic, LowGravity, Test2}
    //enum modifiers { IncreasingSpeed, DecreasingSpeed, Test } //descreasing speed should be MouseShake

    bool[] modes = new bool[] { true, false, false, false, false, false, false, false, false };
    //0 = basic
    //1 = LowGravity //strafing or just flying where you are going for example
    //2 = test2 
    bool[] modifiers = new bool[] { false, false, false, false, false, false, false, false, false };
    //0 = IncreasingSpeed
    //1 = DecreasingSpeed
    //2 = mouseShake
    //3 = test

    public bool ChangeMode(KeyCode keyCode)
    {
        //different variant could be switch
        if (keyCode == KeyCode.Alpha1) return ChangeModeAlgo(0, true);
        if (keyCode == KeyCode.Alpha2) return ChangeModeAlgo(1, true);
        if (keyCode == KeyCode.Alpha3) return ChangeModeAlgo(2, true);
        if (keyCode == KeyCode.Alpha4) return ChangeModeAlgo(3, true);
        if (keyCode == KeyCode.Alpha5) return ChangeModeAlgo(4, true);
        if (keyCode == KeyCode.Alpha6) return ChangeModeAlgo(5, true);
        if (keyCode == KeyCode.Alpha7) return ChangeModeAlgo(6, true);
        if (keyCode == KeyCode.Alpha8) return ChangeModeAlgo(7, true);
        if (keyCode == KeyCode.Alpha9) return ChangeModeAlgo(8, true);
        if (keyCode == KeyCode.F1) return ChangeModeAlgo(0, false);
        if (keyCode == KeyCode.F2) return ChangeModeAlgo(1, false);
        if (keyCode == KeyCode.F3) return ChangeModeAlgo(2, false);
        if (keyCode == KeyCode.F4) return ChangeModeAlgo(3, false);
        if (keyCode == KeyCode.F5) return ChangeModeAlgo(4, false);
        if (keyCode == KeyCode.F6) return ChangeModeAlgo(5, false);
        if (keyCode == KeyCode.F7) return ChangeModeAlgo(6, false);
        if (keyCode == KeyCode.F8) return ChangeModeAlgo(7, false);
        if (keyCode == KeyCode.F9) return ChangeModeAlgo(8, false);
        else return true; //will never happen
    }

    bool ChangeModeAlgo(int index, bool isMode)
    {
        if (isMode)
        {
            if (modes[index] == false)
            {
                modes[index] = true;
                return true;
            }
            else 
            {
                modes[index] = false;
                return false;
            }
        }
        else
        {
            if (modifiers[index] == false)
            {
                modifiers[index] = true;
                return true;
            }
            else
            {
                modifiers[index] = false;
                return false;
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void 
}
