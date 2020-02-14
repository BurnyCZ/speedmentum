using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*
    toDo:
    1) udělat to tak aby šel updatovat movement bez toho aby byla závislost na growingValue, ale místo toho se to jen přišetlo/odečetlo od    předchozí value
    
    */
    


    bool[] modes = new bool[] { true, false, false, false, false, false, false, false, false };
    //0 = basic
    //1 = LowGravity //strafing or just flying where you are going for example
    //2 = test2 
    bool[] modifiers = new bool[] { false, false, false, false, false, false, false, false, false };
    //0 = IncreasingSpeed
    //1 = DecreasingSpeed
    //2 = mouseShake
    //3 = test

    void OnEnable()
    {
        //CreateNew();
        //basicMovement.controller = GetComponent<CharacterController>();
        //basicMovement.groundCheck.transform = GameObject.Find("GroundCheck");
    }
    void Update()
    {
        //basicMovement.Movement();
    }

    void CreateNew()
    {
        //BasicMovement basicMovement = new BasicMovement();
    }
    public void EnableDisable()
    {
        //isEnabled = !isEnabled;

    }

}


