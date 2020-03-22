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
        triggersOrMenu,
        triggerAndMenu,
        moreOrMenu
    }
    public List<ButtonClickHandler> modesMenuButtonClickHandlers = new List<ButtonClickHandler>();
    //public List<ButtonClickHandler> modesMenuButtonClickHandlers = new List<ButtonClickHandler>(); //cant be List<List<ButtonClickHandler>> buttonClickHandlers = new List<List<ButtonClickHandler>>(); because then it doesnt show in the unity editor inspector, it must be done manually - https://www.youtube.com/watch?v=uoHc-Lz9Lsc //includes all buttons from the movementmenu inside so its possible to interact with them in this code (the button objects are set in unity editor)
    public List<ButtonClickHandler> addReplaceMenuButtonClickHandlers = new List<ButtonClickHandler>();
    public List<ButtonClickHandler> modifiersMenuButtonClickHandlers = new List<ButtonClickHandler>();
    public List<ButtonClickHandler> growthVariantsMenuButtonClickHandlers = new List<ButtonClickHandler>();
    public List<ButtonClickHandler> writeValuesMenuButtonClickHandlers = new List<ButtonClickHandler>();
    public List<ButtonClickHandler> triggersOrMenuButtonClickHandlers = new List<ButtonClickHandler>();
    public List<ButtonClickHandler> triggerAndMenuButtonClickHandlers = new List<ButtonClickHandler>();
    public List<ButtonClickHandler> moreOrMenuButtonClickHandlers = new List<ButtonClickHandler>();

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
    List<BasicMovement.Triggers> andTriggers = new List<BasicMovement.Triggers>();

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

    void lol()
    {
        
        if (!modifiers.Contains(BasicMovement.Modifiers.PlayerSpeed)) //if the enabledModes list already includes the movement mode, it removes it, if not, it adds it
        {
            modifiers.Add(BasicMovement.Modifiers.PlayerSpeed);
        }
        else
        {
            modifiers.Remove(BasicMovement.Modifiers.PlayerSpeed);
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
                modifiers.Add(BasicMovement.Modifiers.PlayerSpeed);
                break;

            case Menus.growthVariantsMenu: 
                growthVariants.Add(BasicMovement.GrowthVariants.Constant);
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('1');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('1');
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
                modifiers.Add(BasicMovement.Modifiers.Gravity);
                break;

            case Menus.growthVariantsMenu:
                growthVariants.Add(BasicMovement.GrowthVariants.LinearlyIcreasing);
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('2');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('2');
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
                modifiers.Add(BasicMovement.Modifiers.PhysUpdates);
                break;

            case Menus.growthVariantsMenu:
                growthVariants.Add(BasicMovement.GrowthVariants.ExponentiallyIncreasing);
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('3');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('3');
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
                modifiers.Add(BasicMovement.Modifiers.JumpSpeed);
                break;

            case Menus.growthVariantsMenu:
                growthVariants.Add(BasicMovement.GrowthVariants.Oscillation);
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('4');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('4');
                break;
        }
    }
    public void Button5Press()
    {
        switch (currentMenu)
        {
            case Menus.modifiersMenu: 
                modifiers.Add(BasicMovement.Modifiers.JumpHeight);
                break;

            case Menus.growthVariantsMenu:
                growthVariants.Add(BasicMovement.GrowthVariants.SuperExponencialyIncreasing);
                ChangeMenu(Menus.writeOneValueMenu);
                break;

            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('5');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('5');
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
        }
    }
    public void Button8Press()
    {
        switch (currentMenu)
        {
            case Menus.modifiersMenu: 
                modifiers.Add(BasicMovement.Modifiers.PlayerMaxSpeed);
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
                modifiers.Add(BasicMovement.Modifiers.Timescale);
                break;

            case Menus.writeOneValueMenu:
                AddCharToAnInputValueInOneValueMenu('9');
                break;

            case Menus.writeTwoValuesMenu:
                AddCharToAnInputValueInTwoValuesMenu('9');
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
                Restart();
                break;

            case Menus.modifiersMenu:
                Restart();
                break;

            case Menus.growthVariantsMenu:
                Restart();
                break;

            case Menus.writeOneValueMenu:
                inputValue = inputValue.Remove(inputValue1.Length - 1); //remove last char
                valueInputBox.text = inputValue;
                break;

            case Menus.writeTwoValuesMenu:
                RemCharToAnInputValueInTwoValuesMenu();
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
                ChangeMenu(Menus.triggersOrMenu);
                break;

            case Menus.writeOneValueMenu:
                ChangeMenu(Menus.growthVariantsMenu);
                break;

            case Menus.writeTwoValuesMenu:
                ChangeMenu(Menus.growthVariantsMenu);
                isCurrentInputBoxTheFirstOne = true;
                break;
        }
    }

    public void TabKeyPress()
    {
        switch (currentMenu)
        {
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

    void Restart() //dodělat
    {
        ChangeMenu(Menus.modesMenu);
        //dodělat vymazat proměnný 
    }

    public void ShowMovementMenuKeyPress() //happens when showmovement key is pressed
    {
        isCurrentMenuEnabled = !isCurrentMenuEnabled;
        if (isCurrentMenuEnabled) menus[(int)currentMenu].position = menus[(int)currentMenu].position - new Vector3(0, 1000, 0);  //makes the current menu screen visible/invisible
        else menus[(int)currentMenu].position = menus[(int)currentMenu].position + new Vector3(0, 1000, 0);
        Debug.Log("test");
    }

}

