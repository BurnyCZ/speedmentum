using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public InputMaster controls;
    public MovementMenu movementMenu;
    public VelocityMeter velocityMeter;
    public BasicMovement basicMovement;
    public MouseLook mouseLook;

    void Awake()
    {
        controls = new InputMaster();
        controls.PlayerControls.Move.performed += context => basicMovement.movementInput = context.ReadValue<Vector2>(); //reads if w a s d keys were pressed and sends it to basicMovement script //could also be a method with a parmeter
        //controls.PlayerControls.Mouse.performed += context => mouseLook.mouseXY = context.ReadValue<float>(); //flaws - cant find GetRawAxis equivalent and idk how to find x and y invidually, just finds how to do xy combined, idea is to have two Mouse.performed, one for x and one for y, not for both like here
        //controls.PlayerControls.WasForwardsPressed.performed += context => method();


        controls.GuiControls.ShowMovementMenu.performed += context => movementMenu.ShowMovementMenuKeyPress(); //if ShowMovementMenu is performed, then do ShowMovementMenu() function... ctx is context, variable that has to be there
        controls.GuiControls.ChangeVelMode.performed += context => velocityMeter.ChangeVelModeKeyPress();
        controls.GuiControls.ChangeVelToFloat.performed += context => velocityMeter.ChangeVelToFloatKeyPress();


        controls.GuiControls.MenuKey1.performed += context => MenuKey1();
        controls.GuiControls.MenuKey2.performed += context => MenuKey2();
        controls.GuiControls.MenuKey3.performed += context => MenuKey3();
        controls.GuiControls.MenuKey4.performed += context => MenuKey4();
        controls.GuiControls.MenuKey5.performed += context => MenuKey5();
        controls.GuiControls.MenuKey6.performed += context => MenuKey6();
        controls.GuiControls.MenuKey7.performed += context => MenuKey7();
        controls.GuiControls.MenuKey8.performed += context => MenuKey8();
        controls.GuiControls.MenuKey9.performed += context => MenuKey9();

    }

    void MenuKey1()
    {

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
