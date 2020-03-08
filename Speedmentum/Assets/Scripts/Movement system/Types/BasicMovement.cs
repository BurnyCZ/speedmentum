using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public CharacterController controller;
    //public Transform test;
    public Transform groundCheck;
    public LayerMask groundMask;

    public bool isEnabled = true;
    public bool isIncreasingSpeedEnabled = false;

    public float speed = 12;
    public float gravity = -19.81f; //default gravity
    public float jumpHeight = 3f;

    //public Transform groundCheck; //invisible object on player's feet
    public float groundDistance = 0.4f; //radius of the invisible sphere
    //public LayerMask groundMask; //controlling which objects the sphere should check for, so that it doesnt check isGrounded as true when standing on the player

    Vector3 velocityY;
    Vector3 velocityXZ;
    public Vector3 velocity;

    bool isGrounded;

    float x, z;

    public float growingValue = 1f;

    void Update()
    {

    }

    public void Movement()
    {
       
        
            //Debug.Log(mode);
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //creates a tiny invisible sphere on player's foot with specified radius groundDistance, and if it collides with anything in groundMask, then isGrounded will set to true, if not, then false

        if (isGrounded && velocityY.y < 0)
        {
            velocityY.y = -2f; //not 0 but -2 is because if incase it sets true too soon, it makes the player force on ground properly
        }

        x = Input.GetAxis("Horizontal"); //getaxis function gives 1 if right key is pressed
            z = Input.GetAxis("Vertical"); //1 if forwards key is pressed
                                                 //forward backwards sideways calculating

            /* first dumb idea - https://pastebin.com/CFXXtY8s*/


        

        velocityXZ = (transform.right * x + transform.forward * z) * speed; //transform right is red arrow vector, from -1 to 1, forward is blue axis //forward backwards sideways direction
                                                                          //those arrows are multiplied by x or z, which are 0 if nothing is pressed or 1 if wasd is pressed
                                                                          //then its added together, forming a vector pointing to the direction where i wanna go
                                                                          //and multiplied by the speed constant
                                                                          //}

            controller.Move(velocityXZ * Time.deltaTime); //forward backwards sideways


        /*first dumb idea  - gravity multiplier makes it grow more each time, but its would be better to square the velocity by gravity multiplier so it grows exponencialy
        velocity = velocity * gravityMultiplier;
        gravityMultiplier++;*/
        if (isGrounded) velocityY.y = 0;

        if (Input.GetButton("Jump") && isGrounded) //jumping
            {
                velocityY.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //why? physics https://imgur.com/a/BQMlYuj
            }

        if (!isGrounded) velocityY.y = velocityY.y + gravity * Time.deltaTime;
        

            controller.Move(velocityY * Time.deltaTime); //gravity
                                                         //2x delta time - ^2, and why its like this - physics https://imgur.com/a/ulUTu7D

        //Debug.Log("move " + (velocityXZ * Time.deltaTime*1000));
        //Debug.Log("velocity" + (velocityY * Time.deltaTime*1000));
        Debug.Log(velocityY + velocityXZ);
        MovementModeController.velocity = (velocityY + velocityXZ).magnitude;
        //4188538


    }
}