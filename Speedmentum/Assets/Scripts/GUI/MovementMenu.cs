using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MovementMenu : MonoBehaviour
{
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
    List<BasicMovement.Modifiers> modifiers = new List<BasicMovement.Modifiers>();
    List<BasicMovement.GrowthVariants> growthVariants = new List<BasicMovement.GrowthVariants>();
    List<List<float>> growthVariantsValues = new List<List<float>>();
    List<BasicMovement.Triggers> orTriggers = new List<BasicMovement.Triggers>();
    List<List<BasicMovement.Triggers>> andTriggers = new List<List<BasicMovement.Triggers>>();
    List<BasicMovement.Triggers> tempAndTriggers = new List<BasicMovement.Triggers>(); //this is being filled in the menu and after its done its added to the andTriggers list and the insides are removed 

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
    }

    void Finish()
    {
        basicMovement.modifiers.Add(modifiers);
        basicMovement.growthVariants.Add(growthVariants);
        basicMovement.growthVariantsValues.Add(growthVariantsValues);
        basicMovement.orTriggers.Add(orTriggers);
        basicMovement.andTriggers.Add(andTriggers);
        basicMovement.growthVariantsValues.Add(growthVariantsValues);
        ResetValues();
    }

    void ResetValues() //dodělat
    {
        modifiers.Clear();
        growthVariants.Clear();
        growthVariantsValues.Clear();
        orTriggers.Clear();
        andTriggers.Clear();
        growthVariantsValues.Clear();
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

    void AddOrRemoveModifier(BasicMovement.Modifiers modifier) //BasicMovement.GrowthVariants
    {        
        if (!modifiers.Contains(modifier)) //if the enabledModes list already includes the movement mode, it removes it, if not, it adds it
        {
            modifiers.Add(modifier);
        }
        else
        {
            modifiers.Remove(modifier);
        }
    }

    void AddOrRemoveGrowthVariant(BasicMovement.GrowthVariants growthVariant) //BasicMovement.GrowthVariants
    {
        if (!growthVariants.Contains(growthVariant)) //if the enabledModes list already includes the movement mode, it removes it, if not, it adds it
        {
            growthVariants.Add(growthVariant);
        }
        else
        {
            growthVariants.Remove(growthVariant);
        }
    }

    void AddOrRemoveOrTrigger(BasicMovement.Triggers trigger) //BasicMovement.GrowthVariants
    {
        if (!orTriggers.Contains(trigger)) //if the enabledModes list already includes the movement mode, it removes it, if not, it adds it
        {
            orTriggers.Add(trigger);
        }
        else
        {
            orTriggers.Remove(trigger);
        }
    }

    void AddOrRemoveAndTrigger(BasicMovement.Triggers trigger) //BasicMovement.GrowthVariants
    {
        if (!tempAndTriggers.Contains(trigger)) //if the enabledModes list already includes the movement mode, it removes it, if not, it adds it
        {
            tempAndTriggers.Add(trigger);
        }
        else
        {
            tempAndTriggers.Remove(trigger);
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
                AddOrRemoveModifier(BasicMovement.Modifiers.PlayerSpeed);
                break;

            case Menus.growthVariantsMenu:
                AddOrRemoveGrowthVariant(BasicMovement.GrowthVariants.Constant);
                growthVariantsMenuButtonClickHandlers[0].KeyPress("Constant");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.declineVariantsMenu:
                AddOrRemoveGrowthVariant(BasicMovement.GrowthVariants.Constant);
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
                AddOrRemoveOrTrigger(BasicMovement.Triggers.Time);
                orTriggersMenuButtonClickHandlers[0].KeyPress("Time");
                break;

            case Menus.andTriggersMenu:
                AddOrRemoveAndTrigger(BasicMovement.Triggers.Time);
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
                AddOrRemoveModifier(BasicMovement.Modifiers.Gravity);
                break;

            case Menus.growthVariantsMenu:
                AddOrRemoveGrowthVariant(BasicMovement.GrowthVariants.LinearlyIcreasing);
                growthVariantsMenuButtonClickHandlers[1].KeyPress("LinearlyIcreasing");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.declineVariantsMenu:
                AddOrRemoveGrowthVariant(BasicMovement.GrowthVariants.LinearlyDecreasing);
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
                AddOrRemoveOrTrigger(BasicMovement.Triggers.Jump);
                orTriggersMenuButtonClickHandlers[1].KeyPress("Jump");
                break;

            case Menus.andTriggersMenu:
                AddOrRemoveAndTrigger(BasicMovement.Triggers.Jump);
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
                AddOrRemoveModifier(BasicMovement.Modifiers.PhysUpdates);
                break;

            case Menus.growthVariantsMenu:
                AddOrRemoveGrowthVariant(BasicMovement.GrowthVariants.ExponentiallyIncreasing);
                growthVariantsMenuButtonClickHandlers[2].KeyPress("ExponentiallyIncreasing");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.declineVariantsMenu:
                AddOrRemoveGrowthVariant(BasicMovement.GrowthVariants.ExponentiallyDecreasing);
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
                AddOrRemoveOrTrigger(BasicMovement.Triggers.MouseShaking);
                orTriggersMenuButtonClickHandlers[2].KeyPress("MouseShaking");
                break;

            case Menus.andTriggersMenu:
                AddOrRemoveAndTrigger(BasicMovement.Triggers.MouseShaking);
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
                AddOrRemoveModifier(BasicMovement.Modifiers.JumpSpeed);
                break;

            case Menus.growthVariantsMenu:
                AddOrRemoveGrowthVariant(BasicMovement.GrowthVariants.Oscillation);
                growthVariantsMenuButtonClickHandlers[3].KeyPress("Oscillation");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.declineVariantsMenu:
                AddOrRemoveGrowthVariant(BasicMovement.GrowthVariants.Oscillation);
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
                AddOrRemoveOrTrigger(BasicMovement.Triggers.WalkingForwards);
                orTriggersMenuButtonClickHandlers[3].KeyPress("WalkingForwards");
                break;

            case Menus.andTriggersMenu:
                AddOrRemoveAndTrigger(BasicMovement.Triggers.WalkingForwards);
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
                AddOrRemoveModifier(BasicMovement.Modifiers.JumpHeight);
                break;

            case Menus.growthVariantsMenu:
                AddOrRemoveGrowthVariant(BasicMovement.GrowthVariants.SuperExponencialyIncreasing);
                growthVariantsMenuButtonClickHandlers[4].KeyPress("SuperExponencialyIncreasing");
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.declineVariantsMenu:
                AddOrRemoveGrowthVariant(BasicMovement.GrowthVariants.SuperExponencialyDecreasing);
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
                AddOrRemoveOrTrigger(BasicMovement.Triggers.PlayerInAir);
                orTriggersMenuButtonClickHandlers[4].KeyPress("PlayerInAir");
                break;

            case Menus.andTriggersMenu:
                AddOrRemoveAndTrigger(BasicMovement.Triggers.PlayerInAir);
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
                AddOrRemoveOrTrigger(BasicMovement.Triggers.PlayerOnGround);
                orTriggersMenuButtonClickHandlers[5].KeyPress("PlayerOnGround");
                break;

            case Menus.andTriggersMenu:
                AddOrRemoveAndTrigger(BasicMovement.Triggers.PlayerOnGround);
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
                AddOrRemoveOrTrigger(BasicMovement.Triggers.WalkingSideways);
                orTriggersMenuButtonClickHandlers[6].KeyPress("WalkingSideways");
                break;

            case Menus.andTriggersMenu:
                AddOrRemoveAndTrigger(BasicMovement.Triggers.WalkingSideways);
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
                AddOrRemoveModifier(BasicMovement.Modifiers.PlayerMaxSpeed);
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
                AddOrRemoveModifier(BasicMovement.Modifiers.Timescale);
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
                break;

            case Menus.growthVariantsMenu:
                ChangeMenu(Menus.orTriggersMenu);
                break;

            case Menus.declineVariantsMenu:
                ChangeMenu(Menus.orTriggersMenu);
                break;

            case Menus.writeOneValueMenu:
                List<float> tempListOfOneFloatValue = new List<float>() { float.Parse(inputValue) };
                growthVariantsValues.Add(tempListOfOneFloatValue);
                inputValue = "";
                ChangeMenu(Menus.growthVariantsMenu);
                break;

            case Menus.writeTwoValuesMenu:
                List<float> tempListOTwoFloatValues = new List<float>() { float.Parse(inputValue1), float.Parse(inputValue2) };
                growthVariantsValues.Add(tempListOTwoFloatValues);
                isCurrentInputBoxTheFirstOne = true;
                inputValue1 = "";
                inputValue2 = "";
                ChangeMenu(Menus.growthVariantsMenu);                
                break;

            case Menus.orTriggersMenu:
                ChangeMenu(Menus.andTriggersMenu);
                break;

            case Menus.andTriggersMenu:
                andTriggers.Add(tempAndTriggers);
                tempAndTriggers.Clear();
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
        Debug.Log("test");
    }

}

