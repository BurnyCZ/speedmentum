using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;

    float speed = 12;
    float gravity;// = -20f; //default gravity
    float jumpHeight = 3f;

    //public Transform groundCheck; //invisible object on player's feet
    float groundDistance = 0.4f; //radius of the invisible sphere
    //public LayerMask groundMask; //controlling which objects the sphere should check for, so that it doesnt check isGrounded as true when standing on the player

    Vector3 velocityY;
    Vector3 velocityXZ;
    Vector3 prevVelocityXZ;
    public Vector3 velocity;

    bool isGrounded;

    float x, z;

    public float growingValue = 1f;
    public float decreasingValue = 1f;
    public float mouseShakeValue;

    float mouseX;
    float mouseY;

    void Start()
    {
        mouseShakeValue = 1f; //its here since for some reason without it if its initialized up there its by default set to 0 even tho i set it to 1 there?! wtf
    }
    //void FixedUpdate()
    //{
    //    Debug.Log(mouseShakeValue);
    //}

    public void Movement()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
        //Debug.Log(mouseX);
        //Debug.Log(mouseY);
        //type float value, default 100

        gravity = -20f; //default gravity value, must be here because each update its set to that value first, and then depending on the combination of other gravity modifiers it adds or removes to that original value (might be better with multiple conditions? probs not) (might be better if the gravity was made as a slider instead)
        if (MovementModeController.enabledModes.Contains(Modes.LowGravity)) gravity += 10f;
        if (MovementModeController.enabledModes.Contains(Modes.HighGravity)) gravity += -10f;


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

        //Debug.Log("velXY " + velocityXZ + " tr.right " + transform.right + " x " + x + " tr.for " + transform.forward + " z " + z );
        //-> velXY (-6.2, 0.0, 15.8) tr.right (0.9, 0.0, -0.4) x -1 tr.for (0.4, 0.0, 0.9) z 1

        if (!MovementModeController.enabledModes.Contains(Modes.IncreasingSpeed) && !MovementModeController.enabledModes.Contains(Modes.DecreasingSpeed)) //if no increasing or decreasing spee
        {
            decreasingValue = 1;
            growingValue = 1;
        }
        else
        {
            if (MovementModeController.enabledModes.Contains(Modes.IncreasingSpeed))
            {
                growingValue = growingValue * 1.001f;
                velocityXZ = velocityXZ * growingValue;
                if (!MovementModeController.enabledModes.Contains(Modes.DecreasingSpeed))
                    decreasingValue = 1f;
            }
            if (MovementModeController.enabledModes.Contains(Modes.DecreasingSpeed))
            {
                decreasingValue = decreasingValue / 1.001f;
                velocityXZ = velocityXZ * decreasingValue;
                if (!MovementModeController.enabledModes.Contains(Modes.DecreasingSpeed))
                    growingValue = 1f;
            }
        }

        if (MovementModeController.enabledModes.Contains(Modes.MouseShake))
        {
            //Debug.Log(mouseShakeValue);
            mouseShakeValue = mouseShakeValue + (Math.Abs(mouseY))/20;
            velocityXZ = velocityXZ * mouseShakeValue;
        }

        /*first dumb idea  - gravity multiplier makes it grow more each time, but its would be better to square the velocity by gravity multiplier so it grows exponencialy
        velocity = velocity * gravityMultiplier;
        gravityMultiplier++;*/
        if (isGrounded) velocityY.y = 0;

        if (Input.GetButton("Jump") && isGrounded) //jumping
            {
                velocityY.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //why? physics https://imgur.com/a/BQMlYuj
            }

        if (!isGrounded) velocityY.y = velocityY.y + gravity * Time.deltaTime;



        controller.Move(new Vector3(velocityXZ.x, velocityY.y, velocityXZ.z) * Time.deltaTime); //forward backwards sideways gravity, //2x delta time - ^2, and why its like this - physics https://imgur.com/a/ulUTu7D
        //Debug.Log("move " + (velocityXZ * Time.deltaTime*1000));
        //Debug.Log("velocity" + (velocityY * Time.deltaTime*1000));
        //Debug.Log(velocityY + velocityXZ);
        MovementModeController.velocity = controller.velocity.magnitude;
        MovementModeController.velocityXZ = new Vector3(controller.velocity.x,0,controller.velocity.z).magnitude;
        MovementModeController.velocityY = Math.Abs(controller.velocity.y); //same as new Vector3(0,controller.velocity.y,0).magnitude;
        MovementModeController.velocityAboutToBeApplied = (velocityXZ + velocityY).magnitude;
        MovementModeController.velocityXZAboutToBeApplied = velocityXZ.magnitude;
        Debug.Log(velocityXZ);
        MovementModeController.velocityYAboutToBeApplied = velocityY.magnitude;

        //4188538
        //Debug.Log("added vel xz var " + velocityXZ);
        //Debug.Log("added vel y var " + velocityY);
        //Debug.Log("reading controller velocity " + controller.velocity);


    }
}