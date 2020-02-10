using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed;
    public float gravity = -19.81f; //default gravity
    public float jumpHeight = 3f;

    public Transform groundCheck; //invisible object on player's feet
    public float groundDistance = 0.2f; //radius of the invisible sphere
    public LayerMask groundMask; //controlling which objects the sphere should check for, so that it doesnt check isGrounded as true when standing on the player

    Vector3 velocity;
    Vector3 move;
    bool isGrounded;

    public float growingValue = 1f;

    bool[] modes = new bool[] { true, false , false};
    //0 = basic
    //1 = increasingSpeed

    // Update is called once per frame
    void Update()
    {
        //this changes the mode to the next one
        if (Input.GetKeyDown(KeyCode.M)) //if changing mode button was pressed
        {
            growingValue = 1; //set to default
            ChangeMode();            
        }
        Movement(GetMode());
    }

    public void Movement(int mode)
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            //creates a tiny invisible sphere on player's foot with specified radius groundDistance, and if it collides with anything in groundMask, then isGrounded will set to true, if not, then false

            if (isGrounded && velocity.y < 0)
        {
                velocity.y = -2f; //not 0 but -2 is because if incase it sets true too soon, it makes the player force on ground properly
        }

        float x = Input.GetAxis("Horizontal"); //getaxis function gives 1 if right key is pressed
        float z = Input.GetAxis("Vertical"); //1 if forwards key is pressed

        /* first dumb idea - https://pastebin.com/CFXXtY8s*/

        if (mode == 1) //if mode is increasingSpeed
        {
            move = (transform.right * x + transform.forward * z) * speed * growingValue;
            growingValue = growingValue * 1.001f;
        }
        else //if mode is Basic
        {
            move = (transform.right * x + transform.forward * z) * speed; //transform right is red arrow vector, from -1 to 1, forward is blue axis
                                                                                  //those arrows are multiplied by x or z, which are 0 if nothing is pressed or 1 if wasd is pressed
                                                                                  //then its added together, forming a vector pointing to the direction where i wanna go
                                                                                  //and multiplied by the speed constant
        }

        controller.Move(move * Time.deltaTime);


            /*first dumb idea  - gravity multiplier makes it grow more each time, but its would be better to square the velocity by gravity multiplier so it grows exponencialy
            velocity = velocity * gravityMultiplier;
            gravityMultiplier++;*/

            if (Input.GetButton("Jump") && isGrounded) //jumping
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //why? physics https://imgur.com/a/BQMlYuj
            }

            velocity.y = velocity.y + gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            //2x delta time - ^2, and why its like this - physics https://imgur.com/a/ulUTu7D

            //Debug.Log("transform.right " + transform.right);
            //Debug.Log("x " + x);
            //Debug.Log("transform.forward" + transform.forward);
            //Debug.Log("z " + z);
            //Debug.Log("move " + move);
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
