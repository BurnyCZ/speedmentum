using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    bool[] modes = new bool[] { true, false, false };
    //0 = basic
    //1 = increasingSpeed
    //2 = mouseShake
    // Update is called once per frame
    void Update()
    {
        
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
                        break; //stop
                    }
                    else //if the true value wasnt at last index
                    {
                        modes[i] = false; //set it to false
                        modes[i + 1] = true; //set the next one to true (activate it)
                        break; //stop
                    }
                }
            }
        }
    }
}
