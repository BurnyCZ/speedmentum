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
    float gravity = -20f;// = -20f; //default gravity
    //float defaultGravity = -20f;
    float jumpHeight = 3f;
    float jumpSpeed = 0f;

    //public Transform groundCheck; //invisible object on player's feet
    float groundDistance = 0.4f; //radius of the invisible sphere
    //public LayerMask groundMask; //controlling which objects the sphere should check for, so that it doesnt check isGrounded as true when standing on the player

    Vector3 velocityY;
    Vector3 velocityXZ;
    Vector3 prevVelocityXZ;
    public Vector3 velocity;

    bool isGrounded;

    float x, z;

    //public float velocityMultiplier = 1f;

    float mouseY;


    public Vector2 movementInput;

    public bool isItJump = false;

    public MovementMenu movementMenu;



    void Start()
    {

        ////modifiers.Add(new List<Modifiers> { Modifiers.PlayerMaxSpeed, Modifiers.Gravity });
        ////growthVariants.Add(new List<GrowthVariants> { GrowthVariants.ExponentiallyIncreasing });
        ////orTriggers.Add(new List<Triggers> { Triggers.Time });

        //orTriggers.Add(new List<Triggers> { Triggers.PlayerOnGround });
        //andTriggers.Add(new List<Triggers> { Triggers.MouseShaking, Triggers.PlayerInAir });

        //orTriggers.Add(new List<Triggers> { Triggers.PlayerOnGround, Triggers.MouseShaking });
        //andTriggers.Add(new List<Triggers> { Triggers.PlayerInAir });



        //andTriggersConditions.Add(new List<int> { 0, 0 });
    }
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.H))
    //    {
    //        foreach (Modifiers modifier in modifiers[0])
    //        {
    //            Debug.Log(modifier);
    //        }
    //        foreach (GrowthVariants growthVariant in growthVariants[0])
    //        {
    //            Debug.Log(growthVariant);
    //        }
    //        foreach (Triggers orTrigger in orTriggers[0])
    //        {
    //            Debug.Log(orTrigger);
    //        }

    //    }
    //}
    public void Movement()
    {
        for (int i = 0; i<movementMenu.andTriggersConditions.Count; i++) //reset all completed conditions
        {
            for (int y = 0; y < movementMenu.andTriggersConditions.Count; y++) //reset all completed conditions
            {
                movementMenu.andTriggersConditions[i][y] = 0;
            }
        }

        ScanTriggers(MovementMenu.Triggers.Time);

        //if ()
        

        mouseY = Input.GetAxisRaw("Mouse Y");

        if (mouseY != 0)
        {
            ScanTriggers(MovementMenu.Triggers.MouseShaking);
        }

        //Debug.Log(mouseX);
        //Debug.Log(mouseY);
        //type float value, default 100

        //gravity = defaultGravity; //default gravity value, must be here because each update its set to that value first, and then depending on the combination of other gravity modifiers it adds or removes to that original value (might be better with multiple conditions? probs not) (might be better if the gravity was made as a slider instead)
        //if (MovementModeController.enabledModes.Contains(Modes.LowGravity)) gravity += 10f;
        //if (MovementModeController.enabledModes.Contains(Modes.HighGravity)) gravity += -10f;
        


        //Debug.Log(mode);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //creates a tiny invisible sphere on player's foot with specified radius groundDistance, and if it collides with anything in groundMask, then isGrounded will set to true, if not, then false

        if (isGrounded && velocityY.y < 0)
        {
            velocityY.y = -2f; //not 0 but -2 is because if incase it sets true too soon, it makes the player force on ground properly
        }

        //old
        x = movementInput.x; //getaxis function gives 1 if right key is pressed
        z = movementInput.y; //1 if forwards key is pressed
                                           //forward backwards sideways calculating

        /* first dumb idea - https://pastebin.com/CFXXtY8s*/


        velocityXZ = (transform.right * x + transform.forward * z) * speed; //transform right is red arrow vector, from -1 to 1, forward is blue axis //forward backwards sideways direction
                                                                            //those arrows are multiplied by x or z, which are 0 if nothing is pressed or 1 if wasd is pressed
                                                                            //then its added together, forming a vector pointing to the direction where i wanna go
                                                                            //and multiplied by the speed constant
                                                                            //}

      




        if (isGrounded) velocityY.y = 0;


        //G R A V I T Y nejpozději, muze byt kdykoliv pred tim

        if (isItJump)
        {
            //if (Input.GetButton("Jump") && isGrounded) //jumping
            if (isGrounded)
            {
                velocityY.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //why? physics https://imgur.com/a/BQMlYuj
                //velocityXZ = velocityXZ + something //jump speed, not impelmented

                ScanTriggers(MovementMenu.Triggers.Jump);
            }
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
        //Debug.Log(velocityXZ);
        MovementModeController.velocityYAboutToBeApplied = velocityY.magnitude;

        //4188538
        //Debug.Log("added vel xz var " + velocityXZ);
        //Debug.Log("added vel y var " + velocityY);
        //Debug.Log("reading controller velocity " + controller.velocity);

    }

    public void Jump()
    {
        //if (isGrounded)
        //{
        //    velocityY.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //why? physics https://imgur.com/a/BQMlYuj
        //        //velocityXZ = velocityXZ + something //jump speed, not impelmented

        //        ScanTriggers(Triggers.Jump);
        //}
    }

    void ScanTriggers(MovementMenu.Triggers trigger)
    {
        for (int i = 0; i < movementMenu.orTriggers.Count; i++)
        {
            if (movementMenu.orTriggers[i].Contains(trigger))
            {
                ScanModifierList(i);
            }
        }
        for (int i = 0; i < movementMenu.andTriggers.Count; i++)
        {
            for (int y = 0; y < movementMenu.andTriggers[i].Count; y++)
            {
                if (movementMenu.andTriggers[i][y].Contains(trigger))
                {
                    movementMenu.andTriggersConditions[i][y]++; //one condition of the and triggers is completed
                    if (movementMenu.andTriggersConditions[i][y] == movementMenu.andTriggers[y].Count) ScanModifierList(y); //if triggers are completed, start the code
                }
            }

        }
    }

    void ScanModifierList(int i)
    {
        if (movementMenu.modifiers[i].Contains(MovementMenu.Modifiers.PlayerSpeed))
        {
            PlayerSpeed(i);
        }
        if (movementMenu.modifiers[i].Contains(MovementMenu.Modifiers.Gravity))
        {
            Gravity(i);
        }
        if (movementMenu.modifiers[i].Contains(MovementMenu.Modifiers.PhysUpdates))
        {
            PhysUpdates(i);
        }
        if (movementMenu.modifiers[i].Contains(MovementMenu.Modifiers.JumpSpeed))
        {
            JumpSpeed(i);
        }
        if (movementMenu.modifiers[i].Contains(MovementMenu.Modifiers.JumpHeight))
        {
            JumpHeight(i);
        }
        if (movementMenu.modifiers[i].Contains(MovementMenu.Modifiers.PlayerMaxSpeed))
        {
            PlayerMaxSpeed(i);
        }
        if (movementMenu.modifiers[i].Contains(MovementMenu.Modifiers.Timescale))
        {
            Timescale(i);
        }
    }
    void PlayerSpeed(int i)
    {

    }

    void Gravity(int i)
    {
        if (movementMenu.growthVariants[i].Contains(MovementMenu.GrowthVariants.Constant))
        {
            gravity = gravity; //wrong, should be whichever gravity the user has input ( gravity = gravity + input );
        }
        if (movementMenu.growthVariants[i].Contains(MovementMenu.GrowthVariants.LinearlyIcreasing))
        {
            gravity = gravity - 0.01f; //munis instead of plus because gravity is by default negative so to make it stronger (increase it) it has to go more into negative
            //Debug.Log(gravity);
        }
        if (movementMenu.growthVariants[i].Contains(MovementMenu.GrowthVariants.LinearlyDecreasing))
        {
            gravity = gravity + 0.01f;
            //Debug.Log(gravity);
        }
        if (movementMenu.growthVariants[i].Contains(MovementMenu.GrowthVariants.ExponentiallyIncreasing))
        {
            gravity = gravity * 1.001f;
            //true exponencialy increasing should be gravity*gravity
            //Debug.Log(gravity);
        }
        if (movementMenu.growthVariants[i].Contains(MovementMenu.GrowthVariants.ExponentiallyDecreasing))
        {
            gravity = gravity * 0.999f;
            //Debug.Log(gravity);
        }
        //if (growthVariants[i].Contains(GrowthVariants.ExponencialIncreasing))
        //{
        //    gravity = gravity * gravity;
        //    //Debug.Log(gravity);
        //}
        //if (growthVariants[i].Contains(GrowthVariants.ExponencialDecreasing))
        //{
            
        //    //Debug.Log(gravity);
        //}
        if (movementMenu.growthVariants[i].Contains(MovementMenu.GrowthVariants.Oscillation))
        {

        }
    }

    void PhysUpdates(int i)
    {

    }

    void JumpSpeed(int i)
    {

    }

    void JumpHeight(int i)
    {

    }

    void PlayerMaxSpeed(int i)
    {
        if (movementMenu.growthVariants[i].Contains(MovementMenu.GrowthVariants.Constant))
        {
            speed = speed * 1.001f;
            gravity = gravity; //wrong, should be whichever gravity the user has input ( gravity = gravity + input );
        }
        if (movementMenu.growthVariants[i].Contains(MovementMenu.GrowthVariants.LinearlyIcreasing)) 
        {
            speed = speed + 0.001f;
            velocityXZ = velocityXZ * speed;
            //Debug.Log(speed);
        }
        if (movementMenu.growthVariants[i].Contains(MovementMenu.GrowthVariants.LinearlyDecreasing))
        {
            speed = speed - 0.001f;
            velocityXZ = velocityXZ * speed;
            //Debug.Log(speed);
        }
        if (movementMenu.growthVariants[i].Contains(MovementMenu.GrowthVariants.ExponentiallyIncreasing))
        {
            speed = speed * 1.001f;
            velocityXZ = velocityXZ * speed;
           // Debug.Log(speed);
        }
        if (movementMenu.growthVariants[i].Contains(MovementMenu.GrowthVariants.ExponentiallyDecreasing))
        {
            speed = speed * 0.999f;
            velocityXZ = velocityXZ * speed;
            //Debug.Log(speed);
        }
        //if (growthVariants[i].Contains(GrowthVariants.ExponencialIncreasing))
        //{
        //    speed = speed * velocityXZ.magnitude;
        //    velocityXZ = velocityXZ * speed;
        //    //Debug.Log(speed);
        //}
        //if (growthVariants[i].Contains(GrowthVariants.ExponencialDecreasing))
        //{
        //    //velocityMultiplier = velocityMultiplier * velocityXZ.magnitude;
        //    //velocityXZ = velocityXZ * velocityMultiplier;
        //    //Debug.Log(velocityMultiplier);
        //}
        if (movementMenu.growthVariants[i].Contains(MovementMenu.GrowthVariants.Oscillation))
        {

        }
    }

    void Timescale(int i)
    {

    }

    


    /*     
     
        if (growthVariants[i].Contains(GrowthVariants.Constant))
        {

        }
        if (growthVariants[i].Contains(GrowthVariants.LinearyIncreasing))
        {

        }
        if (growthVariants[i].Contains(GrowthVariants.LinearyDecreasing))
        {

        }
        if (growthVariants[i].Contains(GrowthVariants.ExponencialyIncreasing))
        {

        }
        if (growthVariants[i].Contains(GrowthVariants.ExponencialyDecreasing))
        {

        }
        if (growthVariants[i].Contains(GrowthVariants.Oscillation))
        {

        }

    */
}