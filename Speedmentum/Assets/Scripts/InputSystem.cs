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
    //public MovementModeController movementModeController;
    public PauseMenu pauseMenu;

    void Awake()
    {
        controls = new InputMaster();
        controls.PlayerControls.Move.performed += context => basicMovement.movementInput = context.ReadValue<Vector2>(); //reads if w a s d keys were pressed and sends it to basicMovement script //could also be a method with a parmeter
        //controls.PlayerControls.MouseX.performed += context => mouseLook.mouseX = context.ReadValue<float>();
        //controls.PlayerControls.MouseY.performed += context => mouseLook.mouseY = context.ReadValue<float>();  //not in the new input system because that is much less smooth and accurate it feels like
        //controls.PlayerControls.WasForwardsPressed.performed += context => method();
        controls.PlayerControls.Jump.started += context => basicMovement.isItJump = true; //jump started
        controls.PlayerControls.Jump.canceled += context => basicMovement.isItJump = false; //jump ended
        controls.PlayerControls.LookStraight.performed += context => mouseLook.LookStraight();

        controls.GuiControls.ShowMovementMenu.performed += context => movementMenu.ShowMovementMenuKeyPress(); //if ShowMovementMenu is performed, then do ShowMovementMenu() function... ctx is context, variable that has to be there
        controls.GuiControls.ChangeVelMode.performed += context => velocityMeter.ChangeVelModeKeyPress();
        controls.GuiControls.ChangeVelToFloat.performed += context => velocityMeter.ChangeVelToFloatKeyPress();
        controls.GuiControls.PauseKey.performed += context => pauseMenu.EscapePressed();

        controls.GuiControls.ChangeKey.performed += context => movementMenu.ChangeKeyPress();
        controls.GuiControls.StopKey.performed += context => movementMenu.StopKeyPress();
        controls.GuiControls.TabKey.performed += context => movementMenu.TabKeyPress();
        controls.GuiControls.MenuKey1.performed += context => movementMenu.Button1Press();
        controls.GuiControls.MenuKey2.performed += context => movementMenu.Button2Press();
        controls.GuiControls.MenuKey3.performed += context => movementMenu.Button3Press();
        controls.GuiControls.MenuKey4.performed += context => movementMenu.Button4Press();
        controls.GuiControls.MenuKey5.performed += context => movementMenu.Button5Press();
        controls.GuiControls.MenuKey6.performed += context => movementMenu.Button6Press();
        controls.GuiControls.MenuKey7.performed += context => movementMenu.Button7Press();
        controls.GuiControls.MenuKey8.performed += context => movementMenu.Button8Press();
        controls.GuiControls.MenuKey9.performed += context => movementMenu.Button9Press();
        controls.GuiControls.MenuKeyF1.performed += context => movementMenu.ButtonF1Press();
        controls.GuiControls.MenuKeyF2.performed += context => movementMenu.ButtonF2Press();
        controls.GuiControls.MenuKeyF3.performed += context => movementMenu.ButtonF3Press();
        controls.GuiControls.MenuKeyF4.performed += context => movementMenu.ButtonF4Press();
        controls.GuiControls.MenuKeyF5.performed += context => movementMenu.ButtonF5Press();
        controls.GuiControls.MenuKeyF6.performed += context => movementMenu.ButtonF6Press();
        controls.GuiControls.MenuKeyF7.performed += context => movementMenu.ButtonF7Press();
        controls.GuiControls.MenuKeyF8.performed += context => movementMenu.ButtonF8Press();
        controls.GuiControls.MenuKeyF9.performed += context => movementMenu.ButtonF9Press();
        controls.GuiControls.MenuKey0.performed += context => movementMenu.Button0Press();

    }

    //void MenuKey1()
    //{

    //}

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
