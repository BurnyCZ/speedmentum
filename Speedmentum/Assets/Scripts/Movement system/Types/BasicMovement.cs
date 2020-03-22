using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BasicMovement : MonoBehaviour
{
    public enum Modifiers
    {
        PlayerSpeed,
        Gravity,
        PhysUpdates,
        JumpSpeed, //if holding w, you also gain forward speed
        JumpHeight,
        PlayerMaxSpeed,
        Timescale
    }
    public enum GrowthVariants
    {
        Constant, //y=LastFrame
        LinearlyIcreasing, //y=LastFrame+x
        LinearlyDecreasing, //y=LastFrame-x
        ExponentiallyIncreasing, //y=LastFrame*x
        ExponentiallyDecreasing, //y=LastFrame/x
        Oscillation,
        SuperExponencialyIncreasing, //y=lastframe^x
        SuperExponencialyDecreasing //y=sqr(lastframe)
    }

    public enum Triggers
    {
        Time,
        Jump,
        MouseShaking,
        Walking,
        PlayerInAir,
        PlayerOnGround
    }

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

    //Dictionary<List, Tuple<List<Modifiers>, List<GrowthVariants>, List<List<float>>, List<Triggers>, List<Triggers>, int>> //triggers are: or, and //tuple can be object of its own, list in dictionary is weird

    public List<List<Modifiers>> modifiers = new List<List<Modifiers>>();
    public List<List<GrowthVariants>> growthVariants = new List<List<GrowthVariants>>();
    public List<List<List<float>>> growthVariantsValues = new List<List<List<float>>>();
    public List<List<Triggers>> orTriggers = new List<List<Triggers>>();
    public List<List<Triggers>> andTriggers = new List<List<Triggers>>();
    //List<List<int>> andTriggersConditions = new List<List<int>>();
    public List<int> andTriggersConditions = new List<int>(); //adds one 0 when a new modifier pack is added, before this code goes though it gets set to 0, and if one condition in andTriggers is true, it gets +1, when the number is as big as the andTriggers list, its completed and the game executes the code

    void Start()
    {

        modifiers.Add(new List<Modifiers> { Modifiers.PlayerMaxSpeed, Modifiers.Gravity });
        growthVariants.Add(new List<GrowthVariants> { GrowthVariants.ExponentiallyIncreasing });

        //orTriggers.Add(new List<Triggers> { Triggers.PlayerOnGround });
        //andTriggers.Add(new List<Triggers> { Triggers.MouseShaking, Triggers.PlayerInAir });

        //orTriggers.Add(new List<Triggers> { Triggers.PlayerOnGround, Triggers.MouseShaking });
        //andTriggers.Add(new List<Triggers> { Triggers.PlayerInAir });

        orTriggers.Add(new List<Triggers> { Triggers.Time});

        andTriggersConditions.Add(0); 
    }
    //void FixedUpdate()
    //{
    //    Debug.Log(mouseShakeValue);
    //}
    public void Movement()
    {
        for (int i = 0; i<andTriggersConditions.Count; i++) //reset all completed conditions
        {
            andTriggersConditions[i] = 0;
        }

        ScanTriggers(Triggers.Time);

        //if ()
        

        mouseY = Input.GetAxisRaw("Mouse Y");

        if (mouseY != 0)
        {
            ScanTriggers(Triggers.MouseShaking);
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

                ScanTriggers(Triggers.Jump);
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

    void ScanTriggers(Triggers trigger)
    {
        for (int i = 0; i < orTriggers.Count; i++)
        {
            if (orTriggers[i].Contains(trigger))
            {
                ScanModifierList(i);
            }
        }
        for (int i = 0; i < andTriggers.Count; i++)
        {
            if (andTriggers[i].Contains(trigger))
            {
                andTriggersConditions[i]++; //one condition of the and triggers is completed
                if (andTriggersConditions[i] == andTriggers[i].Count) ScanModifierList(i); //if triggers are completed, start the code
            }
        }
    }

    void ScanModifierList(int i)
    {
        if (modifiers[i].Contains(Modifiers.PlayerSpeed))
        {
            PlayerSpeed(i);
        }
        if (modifiers[i].Contains(Modifiers.Gravity))
        {
            Gravity(i);
        }
        if (modifiers[i].Contains(Modifiers.PhysUpdates))
        {
            PhysUpdates(i);
        }
        if (modifiers[i].Contains(Modifiers.JumpSpeed))
        {
            JumpSpeed(i);
        }
        if (modifiers[i].Contains(Modifiers.JumpHeight))
        {
            JumpHeight(i);
        }
        if (modifiers[i].Contains(Modifiers.PlayerMaxSpeed))
        {
            PlayerMaxSpeed(i);
        }
        if (modifiers[i].Contains(Modifiers.Timescale))
        {
            Timescale(i);
        }
    }
    void PlayerSpeed(int i)
    {

    }

    void Gravity(int i)
    {
        if (growthVariants[i].Contains(GrowthVariants.Constant))
        {
            gravity = gravity; //wrong, should be whichever gravity the user has input ( gravity = gravity + input );
        }
        if (growthVariants[i].Contains(GrowthVariants.LinearlyIcreasing))
        {
            gravity = gravity - 0.01f; //munis instead of plus because gravity is by default negative so to make it stronger (increase it) it has to go more into negative
            //Debug.Log(gravity);
        }
        if (growthVariants[i].Contains(GrowthVariants.LinearlyDecreasing))
        {
            gravity = gravity + 0.01f;
            //Debug.Log(gravity);
        }
        if (growthVariants[i].Contains(GrowthVariants.ExponentiallyIncreasing))
        {
            gravity = gravity * 1.001f;
            //true exponencialy increasing should be gravity*gravity
            //Debug.Log(gravity);
        }
        if (growthVariants[i].Contains(GrowthVariants.ExponentiallyDecreasing))
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
        if (growthVariants[i].Contains(GrowthVariants.Oscillation))
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
        if (growthVariants[i].Contains(GrowthVariants.Constant))
        {
            speed = speed * 1.001f;
            gravity = gravity; //wrong, should be whichever gravity the user has input ( gravity = gravity + input );
        }
        if (growthVariants[i].Contains(GrowthVariants.LinearlyIcreasing)) 
        {
            speed = speed + 0.001f;
            velocityXZ = velocityXZ * speed;
            //Debug.Log(speed);
        }
        if (growthVariants[i].Contains(GrowthVariants.LinearlyDecreasing))
        {
            speed = speed - 0.001f;
            velocityXZ = velocityXZ * speed;
            //Debug.Log(speed);
        }
        if (growthVariants[i].Contains(GrowthVariants.ExponentiallyIncreasing))
        {
            speed = speed * 1.001f;
            velocityXZ = velocityXZ * speed;
           // Debug.Log(speed);
        }
        if (growthVariants[i].Contains(GrowthVariants.ExponentiallyDecreasing))
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
        if (growthVariants[i].Contains(GrowthVariants.Oscillation))
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