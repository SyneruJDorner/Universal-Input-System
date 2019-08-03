using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GamepadControl
{
    private GamepadController gamepadController;
    private GamepadController.GamepadActions Gamepad_Controller;

    public bool ButtonEast;
    public bool ButtonNorth;
    public bool ButtonSouth;
    public bool ButtonWest;
    public Vector2 Dpad;
    public bool LeftShoulder;
    public Vector2 LeftStick;
    public bool LeftStickPress;
    public bool LeftTrigger;
    public bool RightShoulder;
    public Vector2 RightStick;
    public bool RightStickPress;
    public bool RightTrigger;
    public bool Select;
    public bool Start;

    public void Init()
    {
        gamepadController = new GamepadController();
        Gamepad_Controller = gamepadController.Gamepad;

        Gamepad_Controller.ButtonEast.performed += ctx => ButtonEast = true;
        Gamepad_Controller.ButtonEast.canceled += ctx => ButtonEast = false;

        Gamepad_Controller.ButtonNorth.performed += ctx => ButtonNorth = true;
        Gamepad_Controller.ButtonNorth.canceled += ctx => ButtonNorth = false;

        Gamepad_Controller.ButtonSouth.performed += ctx => ButtonSouth = true;
        Gamepad_Controller.ButtonSouth.canceled += ctx => ButtonSouth = false;

        Gamepad_Controller.ButtonWest.performed += ctx => ButtonWest = true;
        Gamepad_Controller.ButtonWest.canceled += ctx => ButtonWest = false;

        Gamepad_Controller.Dpad.performed += ctx => Dpad = ctx.ReadValue<Vector2>();
        Gamepad_Controller.Dpad.canceled += ctx => Dpad = Vector2.zero;

        Gamepad_Controller.LeftShoulder.performed += ctx => LeftShoulder = true;
        Gamepad_Controller.LeftShoulder.canceled += ctx => LeftShoulder = false;

        Gamepad_Controller.LeftStick.performed += ctx => LeftStick = ctx.ReadValue<Vector2>();
        Gamepad_Controller.LeftStick.canceled += ctx => LeftStick = Vector2.zero;

        Gamepad_Controller.LeftStickPress.performed += ctx => LeftStickPress = true;
        Gamepad_Controller.LeftStickPress.canceled += ctx => LeftStickPress = false;

        Gamepad_Controller.LeftTrigger.performed += ctx => LeftTrigger = true;
        Gamepad_Controller.LeftTrigger.canceled += ctx => LeftTrigger = false;

        Gamepad_Controller.RightShoulder.performed += ctx => RightShoulder = true;
        Gamepad_Controller.RightShoulder.canceled += ctx => RightShoulder = false;

        Gamepad_Controller.RightStick.performed += ctx => RightStick = ctx.ReadValue<Vector2>();
        Gamepad_Controller.RightStick.canceled += ctx => RightStick = Vector2.zero;

        Gamepad_Controller.RightStickPress.performed += ctx => RightStickPress = true;
        Gamepad_Controller.RightStickPress.canceled += ctx => RightStickPress = false;

        Gamepad_Controller.RightTrigger.performed += ctx => RightTrigger = true;
        Gamepad_Controller.RightTrigger.canceled += ctx => RightTrigger = false;

        Gamepad_Controller.Select.performed += ctx => Select = true;
        Gamepad_Controller.Select.canceled += ctx => Select = false;

        Gamepad_Controller.Start.performed += ctx => Start = true;
        Gamepad_Controller.Start.canceled += ctx => Start = false;
    }

    public void OnEnable()
    {
        Gamepad_Controller.Enable();
    }

    public void OnDisable()
    {
        Gamepad_Controller.Disable();
    }

    public void ControlState(bool state)
    {
        if (state == true)
            Gamepad_Controller.Enable();
        else if (state == false)
            Gamepad_Controller.Disable();
    }
}
