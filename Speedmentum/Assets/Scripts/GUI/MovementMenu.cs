using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MovementMenu : MonoBehaviour
{
    public enum Modifiers
    {
        Null,
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
        Null,
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
        Null,
        Time,
        Jump,
        MouseShaking,
        WalkingForwards,
        PlayerInAir,
        PlayerOnGround,
        WalkingSideways
    }

    //Dictionary<List, Tuple<List<Modifiers>, List<GrowthVariants>, List<List<float>>, List<Triggers>, List<Triggers>, int>> //triggers are: or, and //tuple can be object of its own, list in dictionary is weird
    //float nullValue = 0.694203147f;
    //first layer of lists = addons = modifier[0], growthVariants[0] etc. is the first addon
    public List<List<Modifiers>> modifiers = new List<List<Modifiers>> { new List<Modifiers> { Modifiers.Null }};
    public List<List<GrowthVariants>> growthVariants = new List<List<GrowthVariants>> { new List<GrowthVariants> { GrowthVariants.Null } };
    public List<List<List<float>>> growthVariantsValues = new List<List<List<float>>> { new List<List<float>> { new List<float>()} };
    public List<List<Triggers>> orTriggers = new List<List<Triggers>> { new List<Triggers> { Triggers.Null } };
    public List<List<List<Triggers>>> andTriggers = new List<List<List<Triggers>>> { new List<List<Triggers>> { new List<Triggers>() { Triggers.Null } } };
    //List<List<int>> andTriggersConditions = new List<List<int>>();
    public List<List<int>> andTriggersConditions = new List<List<int>>(); //adds one 0 when a new modifier pack is added, before this code goes though it gets set to 0, and if one condition in andTriggers is true, it gets +1, when the number is as big as the andTriggers list, its completed and the game executes the code

    public MovementModeController movementModeController;
    public BasicMovement basicMovement;

    //List<List<ButtonClickHandler>> buttonClickHandlers = new List<List<ButtonClickHandler>>(); //includes all buttons from the movementmenu inside so its possible to interact with them in this code (the button objects are set in unity editor)
    public List<RectTransform> menus = new List<RectTransform>(); //get position of the menu (by default its y is 1000, its hidden above the screen
    public enum Menus
    {
        modesMenu,
        addReplaceMenu,
        modifiersMenu,        
        growthVariantsMenu,
        declineVariantsMenu,
        writeOneValueMenu,
        writeTwoValuesMenu,
        orTriggersMenu,
        andTriggersMenu,
        moreOrMenu
    }
    public List<ButtonClickHandler> modesMenuButtonClickHandlers = new List<ButtonClickHandler>();
    //public List<ButtonClickHandler> modesMenuButtonClickHandlers = new List<ButtonClickHandler>(); //cant be List<List<ButtonClickHandler>> buttonClickHandlers = new List<List<ButtonClickHandler>>(); because then it doesnt show in the unity editor inspector, it must be done manually - https://www.youtube.com/watch?v=uoHc-Lz9Lsc //includes all buttons from the movementmenu inside so its possible to interact with them in this code (the button objects are set in unity editor)
    //public List<ButtonClickHandler> addReplaceMenuButtonClickHandlers = new List<ButtonClickHandler>();
    public List<ButtonClickHandler> modifiersMenuButtonClickHandlers = new List<ButtonClickHandler>();
    public List<ButtonClickHandler> growthVariantsMenuButtonClickHandlers = new List<ButtonClickHandler>();
    public List<ButtonClickHandler> declineVariantsMenuButtonClickHandlers = new List<ButtonClickHandler>();
    //public List<ButtonClickHandler> writeValuesMenuButtonClickHandlers = new List<ButtonClickHandler>();
    public List<ButtonClickHandler> orTriggersMenuButtonClickHandlers = new List<ButtonClickHandler>();
    public List<ButtonClickHandler> andTriggersMenuButtonClickHandlers = new List<ButtonClickHandler>();
    //public List<ButtonClickHandler> moreOrMenuButtonClickHandlers = new List<ButtonClickHandler>();

    public Menus currentMenu = Menus.modesMenu;
    bool isCurrentMenuEnabled = false;

    //variables for movement modifier adding process
    //what to do with the modifier
    enum Actions
    {
        Add,
        Replace,
        Remove,
        EnableOnly
    }
    Actions action;
    //setting up the modifier properties
    //List<Modifiers> tempModifiers = new List<Modifiers> {Modifiers.Null};
    //List<GrowthVariants> tempGrowthVariants = new List<GrowthVariants> { GrowthVariants.Null };
    //List<List<float>> tempGrowthVariantsValues = new List<List<float>> { null };
    //List<Triggers> tempOrTriggers = new List<Triggers> { Triggers.Null };
    ////List<List<Triggers>> tempAndTriggers = new List<List<Triggers>> { Modifiers.Null };
    //List<Triggers> tempForTempAndTriggers = new List<Triggers> { Triggers.Null }; //this is being filled in the menu and after its done its added to the andTriggers list and the insides are removed 

    [SerializeField] TextMeshProUGUI valueInputBox; //for one value menu
    [SerializeField] TextMeshProUGUI valueInputBox1; //for two values menu
    [SerializeField] TextMeshProUGUI valueInputBox2; //for two values menu
    bool isCurrentInputBoxTheFirstOne = true;
    string inputValue;
    string inputValue1;
    string inputValue2;

    void Start()
    {
        for (int i = 0; i<menus.Count; i++)
        {
            // menus[(int)Menus.modesMenu].position = menus[(int)Menus.modesMenu].position + new Vector3(0, 1000, 0);
            menus[i].position = menus[i].position + new Vector3(0, 1000, 0);
        } //offset at first frame - done like this instead of having its default position somewhere else because if its the other case, it behaves differently on different resolutions for some reason so the movement menu does wont be in the middl of the screen if triggered


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            ChangeMenu((Menus)((int)currentMenu + 1));
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            List<Modifiers> temppModifiers = new List<Modifiers>();
            temppModifiers.Add(Modifiers.Gravity);
                temppModifiers.Add(Modifiers.PlayerMaxSpeed);
            modifiers.Add(temppModifiers);
            growthVariants.Add(new List<GrowthVariants> { GrowthVariants.ExponentiallyIncreasing });
            orTriggers.Add(new List<Triggers> { Triggers.Time });

            string modifiesString = "";
            foreach (Modifiers modifier in temppModifiers)
            {
                modifiesString = modifiesString + System.Convert.ToString(modifier);
            }
            Debug.Log("Adding modifiers:" + modifiesString);
            string modifiesStringBasicMovement = "";
            for (int i = 0; i < modifiers.Count; i++)
            {
                foreach (Modifiers modifier in modifiers[i])
                {
                    modifiesStringBasicMovement = modifiesStringBasicMovement + System.Convert.ToString(modifier);
                }
            }
            Debug.Log("Added modifiers:" + modifiesStringBasicMovement);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("yo");
            string modifiesStringBasicMovement = "";
            for (int i = 0; i < modifiers.Count; i++)
            {
                foreach (Modifiers modifier in modifiers[i])
                {
                    modifiesStringBasicMovement = modifiesStringBasicMovement + System.Convert.ToString(modifier);
                }
            }
            Debug.Log("modifiers:" + modifiesStringBasicMovement);
            string growthVariantsStringBasicMovement = "";
            for (int i = 0; i < growthVariants.Count; i++)
            {
                foreach (GrowthVariants growthVariant in growthVariants[i])
                {
                    growthVariantsStringBasicMovement = growthVariantsStringBasicMovement + System.Convert.ToString(growthVariant);
                }
            }
            Debug.Log("growthVariants:" + growthVariantsStringBasicMovement);
            string orTriggersStringBasicMovement = "";
            for (int i = 0; i < orTriggers.Count; i++)
            {
                foreach (Triggers orTrigger in orTriggers[i])
                {
                    orTriggersStringBasicMovement = orTriggersStringBasicMovement + System.Convert.ToString(orTrigger);
                }
            }
            Debug.Log("orTriggers:" + orTriggersStringBasicMovement);
        }
    }

    void Finish()
    {
        //modifiers.Add(List);
        //modifiers.Add(new List<Modifiers>());
        //modifiers[modifiers.Count - 1] = tempModifiers;
        //var tempModifiersArray = modifiers.ToArray();
        //modifiers.Add(tempModifiersArray);

        //string modifiesString = "";
        //foreach (Modifiers modifier in tempModifiers)
        //{
        //    modifiesString = modifiesString + System.Convert.ToString(modifier);
        //}
        //Debug.Log("Adding modifiers:" + modifiesString);
        string modifiesStringBasicMovement = "";
        for (int i = 0; i< modifiers.Count; i++)
        {
            foreach (Modifiers modifier in modifiers[i])
            {
                modifiesStringBasicMovement = modifiesStringBasicMovement + System.Convert.ToString(modifier);
            }
        }
        Debug.Log("modifiers:" + modifiesStringBasicMovement);

        
        //growthVariants[growthVariants.Count - 1] = tempGrowthVariants;
        //growthVariants.Add(tempGrowthVariants);

        //string growthVariantsString = "";
        //foreach (GrowthVariants growthVariant in tempGrowthVariants)
        //{
        //    growthVariantsString = growthVariantsString + System.Convert.ToString(growthVariant);
        //}
        //Debug.Log("Adding growthVariants:" + growthVariantsString);
        string growthVariantsStringBasicMovement = "";
        for (int i = 0; i < growthVariants.Count; i++)
        {
            foreach (GrowthVariants growthVariant in growthVariants[i])
            {
                growthVariantsStringBasicMovement = growthVariantsStringBasicMovement + System.Convert.ToString(growthVariant);
            }
        }
        Debug.Log("growthVariants:" + growthVariantsStringBasicMovement);

        //////////////////growthVariantsValues.Add(float i );
        //////////////////growthVariants[growthVariants.Count - 1] = tempGrowthVariants;
        //////////////////growthVariantsValues.Add(tempGrowthVariantsValues);

        //string growthVariantsValuesString = "";
        //foreach (BasicMovement.GrowthVariantsValues growthVariantsValues in modifiers)
        //{
        //    modifiesString = modifiesString + System.Convert.ToString(modifier);
        //}
        //Debug.Log("Adding modifiers:" + modifiesString);
        //string modifiesStringBasicMovement = "";
        //for (int i = 0; i < basicMovement.modifiers.Count; i++)
        //{
        //    foreach (BasicMovement.Modifiers modifier in basicMovement.modifiers[i])
        //    {
        //        modifiesStringBasicMovement = modifiesStringBasicMovement + System.Convert.ToString(modifier);
        //    }
        //}
        //Debug.Log("Added modifiers:" + modifiesStringBasicMovement);

        //orTriggers.Add(tempOrTriggers);
        
        //orTriggers[orTriggers.Count - 1] = tempOrTriggers;


        //string orTriggersString = "";
        //foreach (Triggers orTrigger in tempOrTriggers)
        //{
        //    orTriggersString = orTriggersString + System.Convert.ToString(orTrigger);
        //}
        //Debug.Log("Adding orTriggers:" + orTriggersString);
        string orTriggersStringBasicMovement = "";
        for (int i = 0; i < orTriggers.Count; i++)
        {
            foreach (Triggers orTrigger in orTriggers[i])
            {
                orTriggersStringBasicMovement = orTriggersStringBasicMovement + System.Convert.ToString(orTrigger);
            }
        }
        Debug.Log("orTriggers:" + orTriggersStringBasicMovement);


        modifiers.Add(new List<Modifiers>());
        growthVariants.Add(new List<GrowthVariants>());
        //growthVariantsValues.Add(new List<float>());
        orTriggers.Add(new List<Triggers>());
        //andTriggers.Add(new List<Triggers>());
        //ResetValues();
    }

    void ResetValues() //dodělat
    {
        modifiers[modifiers.Count - 1].Clear();
        growthVariants[modifiers.Count - 1].Clear();
        //growthVariantsValues[modifiers.Count - 1].Clear();
        orTriggers[modifiers.Count - 1].Clear();
        //andTriggers[modifiers.Count - 1].Clear();
        ChangeMenu(Menus.modesMenu);
    }

    void ChangeMenu(Menus nextMenu)
    {
        menus[(int)currentMenu].position = menus[(int)currentMenu].position + new Vector3(0, 1000, 0);
        menus[(int)nextMenu].position = menus[(int)nextMenu].position - new Vector3(0, 1000, 0);
        currentMenu = nextMenu;
    }

    void AddCharToAnInputValueInTwoValuesMenu(char number)
    {
        if (isCurrentInputBoxTheFirstOne)
        {
            inputValue1 = inputValue1 + number;
            valueInputBox1.text = inputValue1;
        }
        else
        {
            inputValue2 = inputValue2 + number;
            valueInputBox2.text = inputValue2;
        }       
    }

    void AddCharToAnInputValueInOneValueMenu(char number)
    {
        inputValue = inputValue + number;
        valueInputBox.text = inputValue;

    }

    void AddOrRemoveModifier(Modifiers modifier) //BasicMovement.GrowthVariants
    {   
        if (modifiers[modifiers.Count - 1].Count == 1)
        {
            if (modifiers[modifiers.Count - 1][0] == Modifiers.Null)
            {
                modifiers[modifiers.Count - 1][0] = modifier;
            }
            else if (modifiers[modifiers.Count - 1][0] == modifier)
            {
                modifiers[modifiers.Count - 1][0] = Modifiers.Null;
            }
            else modifiers[modifiers.Count - 1].Add(modifier);
        }
        else
        {
            if (!modifiers[modifiers.Count - 1].Contains(modifier)) //if the enabledModes list already includes the movement mode, it removes it, if not, it adds it
            {
                modifiers[modifiers.Count - 1].Add(modifier);
            }
            else
            {
                modifiers[modifiers.Count - 1].Remove(modifier);
            }
        }        
    }

    void AddOrRemoveGrowthVariant(GrowthVariants growthVariant) //BasicMovement.GrowthVariants
    {
        if (growthVariants[growthVariants.Count - 1].Count == 1)
        {
            if (growthVariants[growthVariants.Count - 1][0] == GrowthVariants.Null)
            {
                growthVariants[growthVariants.Count - 1][0] = growthVariant;
            }
            else if (growthVariants[growthVariants.Count - 1][0] == growthVariant)
            {
                growthVariants[growthVariants.Count - 1][0] = GrowthVariants.Null;
            }
            else growthVariants[growthVariants.Count - 1].Add(growthVariant);
        }
        else
        {
            if (!growthVariants[growthVariants.Count - 1].Contains(growthVariant)) //if the enabledModes list already includes the movement mode, it removes it, if not, it adds it
            {
                growthVariants[growthVariants.Count - 1].Add(growthVariant);
            }
            else
            {
                growthVariants[growthVariants.Count - 1].Remove(growthVariant);
            }
        }
    }

    void AddOrRemoveOrTrigger(Triggers trigger) //BasicMovement.GrowthVariants
    {
        if (orTriggers[orTriggers.Count - 1].Count == 1)
        {
            if (orTriggers[orTriggers.Count - 1][0] == Triggers.Null)
            {
                orTriggers[orTriggers.Count - 1][0] = trigger;
            }
            else if (orTriggers[orTriggers.Count - 1][0] == trigger)
            {
                orTriggers[orTriggers.Count - 1][0] = Triggers.Null;
            }
            else orTriggers[orTriggers.Count - 1].Add(trigger);
        }
        else
        {
            if (!orTriggers[orTriggers.Count - 1].Contains(trigger)) //if the enabledModes list already includes the movement mode, it removes it, if not, it adds it
            {
                orTriggers[orTriggers.Count - 1].Add(trigger);
            }
            else
            {
                orTriggers[orTriggers.Count - 1].Remove(trigger);
            }
        }
    }

    void AddOrRemoveAndTrigger(Triggers trigger) //BasicMovement.GrowthVariants
    {
        //if (andTriggers[0] == null)
        //{
        //    andTriggers[0][0].Add(trigger);
        //}
        if (!andTriggers[andTriggers.Count - 1][andTriggers.Count - 1].Contains(trigger)) //if the enabledModes list already includes the movement mode, it removes it, if not, it adds it
        {
            andTriggers[andTriggers.Count - 1][andTriggers.Count - 1].Add(trigger);
        }
        else
        {
            if (andTriggers[andTriggers.Count - 1].Count == 1)
            {
                //andTriggers[andTriggers.Count - 1][0] = Triggers.Null;
            }
            else
            {
                //andTriggers[andTriggers.Count - 1].Remove(trigger);
            }
        }

    }

    public void Button1Press()
    {
        switch (currentMenu)
        {
            case Menus.modesMenu:
                movementModeController.ModeKeyPress(Modes.Basic);
                modesMenuButtonClickHandlers[0].KeyPress("BasicMovement"); //button pressed color animation on or off
                break;

            case Menus.addReplaceMenu:
                action = Actions.Add;
                ChangeMenu(Menus.modifiersMenu);
                break;

            case Menus.modifiersMenu: //dont forget to clean the lists after
                modifiersMenuButtonClickHandlers[0].KeyPress("PlayerSpeed");
                AddOrRemoveModifier(Modifiers.PlayerSpeed);
                break;

            case Menus.growthVariantsMenu:
                AddOrRemoveGrowthVariant(GrowthVariants.Constant);
                growthVariantsMenuButtonClickHandlers[0].KeyPress("Constant");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.declineVariantsMenu:
                AddOrRemoveGrowthVariant(GrowthVariants.Constant);
                declineVariantsMenuButtonClickHandlers[0].KeyPress("Constant");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('1');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('1');
                break;

            case Menus.orTriggersMenu:
                AddOrRemoveOrTrigger(Triggers.Time);
                orTriggersMenuButtonClickHandlers[0].KeyPress("Time");
                break;

            case Menus.andTriggersMenu:
                AddOrRemoveAndTrigger(Triggers.Time);
                andTriggersMenuButtonClickHandlers[0].KeyPress("Time");
                break;

            case Menus.moreOrMenu:
                ChangeMenu(Menus.andTriggersMenu);
                break;
        }
    }
    public void Button2Press()
    {
        switch (currentMenu)
        {
            case Menus.addReplaceMenu:
                action = Actions.Replace;
                ChangeMenu(Menus.modifiersMenu);
                break;

            case Menus.modifiersMenu:
                modifiersMenuButtonClickHandlers[1].KeyPress("Gravity");
                AddOrRemoveModifier(Modifiers.Gravity);
                break;

            case Menus.growthVariantsMenu:
                AddOrRemoveGrowthVariant(GrowthVariants.LinearlyIcreasing);
                growthVariantsMenuButtonClickHandlers[1].KeyPress("LinearlyIcreasing");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.declineVariantsMenu:
                AddOrRemoveGrowthVariant(GrowthVariants.LinearlyDecreasing);
                declineVariantsMenuButtonClickHandlers[1].KeyPress("LinearlyDecreasing");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('2');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('2');
                break;

            case Menus.orTriggersMenu:
                AddOrRemoveOrTrigger(Triggers.Jump);
                orTriggersMenuButtonClickHandlers[1].KeyPress("Jump");
                break;

            case Menus.andTriggersMenu:
                AddOrRemoveAndTrigger(Triggers.Jump);
                andTriggersMenuButtonClickHandlers[1].KeyPress("Jump");
                break;

            case Menus.moreOrMenu:
                Finish();
                break;
        }
    }
    public void Button3Press()
    {
        switch (currentMenu)
        {
            case Menus.addReplaceMenu:
                action = Actions.Remove;
                ChangeMenu(Menus.modifiersMenu);
                break;

            case Menus.modifiersMenu: 
                modifiersMenuButtonClickHandlers[2].KeyPress("PhysUpdates");
                AddOrRemoveModifier(Modifiers.PhysUpdates);
                break;

            case Menus.growthVariantsMenu:
                AddOrRemoveGrowthVariant(GrowthVariants.ExponentiallyIncreasing);
                growthVariantsMenuButtonClickHandlers[2].KeyPress("ExponentiallyIncreasing");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.declineVariantsMenu:
                AddOrRemoveGrowthVariant(GrowthVariants.ExponentiallyDecreasing);
                declineVariantsMenuButtonClickHandlers[2].KeyPress("ExponentiallyDecreasing");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('3');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('3');
                break;

            case Menus.orTriggersMenu:
                AddOrRemoveOrTrigger(Triggers.MouseShaking);
                orTriggersMenuButtonClickHandlers[2].KeyPress("MouseShaking");
                break;

            case Menus.andTriggersMenu:
                AddOrRemoveAndTrigger(Triggers.MouseShaking);
                andTriggersMenuButtonClickHandlers[2].KeyPress("MouseShaking");
                break;
        }
    }
    public void Button4Press()
    {
        switch (currentMenu)
        {
            case Menus.addReplaceMenu:
                action = Actions.EnableOnly;
                ChangeMenu(Menus.modifiersMenu);
                break;

            case Menus.modifiersMenu:
                modifiersMenuButtonClickHandlers[3].KeyPress("JumpSpeed");
                AddOrRemoveModifier(Modifiers.JumpSpeed);
                break;

            case Menus.growthVariantsMenu:
                AddOrRemoveGrowthVariant(GrowthVariants.Oscillation);
                growthVariantsMenuButtonClickHandlers[3].KeyPress("Oscillation");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.declineVariantsMenu:
                AddOrRemoveGrowthVariant(GrowthVariants.Oscillation);
                declineVariantsMenuButtonClickHandlers[3].KeyPress("Oscillation");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('4');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('4');
                break;

            case Menus.orTriggersMenu:
                AddOrRemoveOrTrigger(Triggers.WalkingForwards);
                orTriggersMenuButtonClickHandlers[3].KeyPress("WalkingForwards");
                break;

            case Menus.andTriggersMenu:
                AddOrRemoveAndTrigger(Triggers.WalkingForwards);
                andTriggersMenuButtonClickHandlers[3].KeyPress("WalkingForwards");
                break;
        }
    }
    public void Button5Press()
    {
        switch (currentMenu)
        {
            case Menus.modifiersMenu:
                modifiersMenuButtonClickHandlers[4].KeyPress("JumpHeight");
                AddOrRemoveModifier(Modifiers.JumpHeight);
                break;

            case Menus.growthVariantsMenu:
                AddOrRemoveGrowthVariant(GrowthVariants.SuperExponencialyIncreasing);
                growthVariantsMenuButtonClickHandlers[4].KeyPress("SuperExponencialyIncreasing");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.declineVariantsMenu:
                AddOrRemoveGrowthVariant(GrowthVariants.SuperExponencialyDecreasing);
                declineVariantsMenuButtonClickHandlers[4].KeyPress("SuperExponencialyDecreasing");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('5');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('5');
                break;

            case Menus.orTriggersMenu:
                AddOrRemoveOrTrigger(Triggers.PlayerInAir);
                orTriggersMenuButtonClickHandlers[4].KeyPress("PlayerInAir");
                break;

            case Menus.andTriggersMenu:
                AddOrRemoveAndTrigger(Triggers.PlayerInAir);
                andTriggersMenuButtonClickHandlers[4].KeyPress("PlayerInAir");
                break;
        }
    }
    public void Button6Press()
    {
        switch (currentMenu)
        {
            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('6');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('6');
                break;

            case Menus.orTriggersMenu:
                AddOrRemoveOrTrigger(Triggers.PlayerOnGround);
                orTriggersMenuButtonClickHandlers[5].KeyPress("PlayerOnGround");
                break;

            case Menus.andTriggersMenu:
                AddOrRemoveAndTrigger(Triggers.PlayerOnGround);
                andTriggersMenuButtonClickHandlers[5].KeyPress("PlayerOnGround");
                break;
        }
    }
    public void Button7Press()
    {
        switch (currentMenu)
        {
            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('7');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('7');
                break;

            case Menus.orTriggersMenu:
                AddOrRemoveOrTrigger(Triggers.WalkingSideways);
                orTriggersMenuButtonClickHandlers[6].KeyPress("WalkingSideways");
                break;

            case Menus.andTriggersMenu:
                AddOrRemoveAndTrigger(Triggers.WalkingSideways);
                andTriggersMenuButtonClickHandlers[6].KeyPress("WalkingSideways");
                break;
        }
    }
    public void Button8Press()
    {
        switch (currentMenu)
        {
            case Menus.modifiersMenu:
                modifiersMenuButtonClickHandlers[7].KeyPress("PlayerMaxSpeed");
                AddOrRemoveModifier(Modifiers.PlayerMaxSpeed);
                break;

            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('8');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('8');
                break;


        }
    }
    public void Button9Press()
    {
        switch (currentMenu)
        {
            case Menus.modifiersMenu:
                modifiersMenuButtonClickHandlers[8].KeyPress("Timescale");
                AddOrRemoveModifier(Modifiers.Timescale);
                break;

            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('9');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('9');
                break;
        }
    }
    public void Button0Press()
    {
        switch (currentMenu)
        {
            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('0');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('0');
                break;
        }
    }
    public void ButtonF1Press()
    {
        switch (currentMenu)
        {
            case Menus.modesMenu:
                ChangeMenu(Menus.addReplaceMenu);
                break;
        }
    }
    public void ButtonF2Press()
    {

    }
    public void ButtonF3Press()
    {

    }
    public void ButtonF4Press()
    {

    }
    public void ButtonF5Press()
    {

    }
    public void ButtonF6Press()
    {

    }
    public void ButtonF7Press()
    {

    }
    public void ButtonF8Press()
    {

    }
    public void ButtonF9Press()
    {

    }
    public void StopKeyPress() //backspace //add cleaning the lists
    {
        switch (currentMenu)
        {
            case Menus.addReplaceMenu:
                ResetValues();
                break;

            case Menus.modifiersMenu:
                ResetValues();
                break;

            case Menus.growthVariantsMenu:
                ResetValues();
                break;

            case Menus.declineVariantsMenu:
                ResetValues();
                break;

            case Menus.writeOneValueMenu:
                inputValue = inputValue.Remove(inputValue.Length - 1); //remove last char
                valueInputBox.text = inputValue;
                break;

            case Menus.writeTwoValuesMenu:
                RemCharToAnInputValueInTwoValuesMenu();
                break;

            case Menus.orTriggersMenu:
                ResetValues();
                break;

            case Menus.andTriggersMenu:
                ResetValues();
                break;
        }
    }
    public void ChangeKeyPress() //enter
    {
        switch (currentMenu)
        {
            case Menus.modifiersMenu:
                ChangeMenu(Menus.growthVariantsMenu);
                //Debug.Log("Added:");
                //foreach (Modifiers modifier in tempModifiers)
                //{
                //    Debug.Log(modifier);
                //}
                break;

            case Menus.growthVariantsMenu:
                ChangeMenu(Menus.orTriggersMenu);
                break;

            case Menus.declineVariantsMenu:
                ChangeMenu(Menus.orTriggersMenu);
                break;

            case Menus.writeOneValueMenu:
                List<float> tempListOfOneFloatValue = new List<float>() { float.Parse(inputValue) };
                //tempGrowthVariantsValues.Add(tempListOfOneFloatValue);
                inputValue = "";
                ChangeMenu(Menus.growthVariantsMenu);
                break;

            case Menus.writeTwoValuesMenu:
                List<float> tempListOTwoFloatValues = new List<float>() { float.Parse(inputValue1), float.Parse(inputValue2) };
                //tempGrowthVariantsValues.Add(tempListOTwoFloatValues);
                isCurrentInputBoxTheFirstOne = true;
                inputValue1 = "";
                inputValue2 = "";
                ChangeMenu(Menus.growthVariantsMenu);                
                break;

            case Menus.orTriggersMenu:
                ChangeMenu(Menus.andTriggersMenu);
                break;

            case Menus.andTriggersMenu:
                //tempAndTriggers.Add(tempForTempAndTriggers);
                
                ChangeMenu(Menus.moreOrMenu);
                break;
        }
    }

    public void TabKeyPress()
    {
        switch (currentMenu)
        {
            case Menus.growthVariantsMenu:
                ChangeMenu(Menus.declineVariantsMenu);
                break;

            case Menus.declineVariantsMenu:
                ChangeMenu(Menus.growthVariantsMenu);
                break;

            case Menus.writeTwoValuesMenu:
                isCurrentInputBoxTheFirstOne = !isCurrentInputBoxTheFirstOne;
                break;
        }
    }

    void RemCharToAnInputValueInTwoValuesMenu()
    {
        if (isCurrentInputBoxTheFirstOne)
        {
            inputValue1 = inputValue1.Remove(inputValue1.Length - 1); //remove last char
            valueInputBox1.text = inputValue1;
        }
        else
        {
            inputValue2 = inputValue2.Remove(inputValue2.Length - 1); //remove last char
            valueInputBox2.text = inputValue2;
        }
    }



    public void ShowMovementMenuKeyPress() //happens when showmovement key is pressed
    {
        isCurrentMenuEnabled = !isCurrentMenuEnabled;
        if (isCurrentMenuEnabled) menus[(int)currentMenu].position = menus[(int)currentMenu].position - new Vector3(0, 1000, 0);  //makes the current menu screen visible/invisible
        else menus[(int)currentMenu].position = menus[(int)currentMenu].position + new Vector3(0, 1000, 0);
        //Debug.Log("test");
    }

}

