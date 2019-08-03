using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class UniversalInput : MonoBehaviour
{
    #region Singleton Access
    private static UniversalInput instance;//Use of a singleton here, needs to be static in order for other scripts to access it.

    public static UniversalInput Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<UniversalInput>();
            }

            return UniversalInput.instance;
        }
    }
    #endregion

    public InputSystem inputSystem = new InputSystem();
    public Canvas canvas;

    public void Awake()
    {
        inputSystem.Awake();
    }

    public void OnEnable()
    {
        inputSystem.OnEnable();
    }

    public void OnDisable()
    {
        inputSystem.OnDisable();
    }

    public void Update()
    {
        inputSystem.Update();
    }
}

[System.Serializable]
public class InputSystem
{
    public enum ControllerType
    {
        KeyboardMouse,
        Controller,
        Touchscreen,
    }
    public ControllerType controllerType = ControllerType.KeyboardMouse;

    public KeyboardContol keyboardContol = new KeyboardContol();
    public MouseControl mouseContol = new MouseControl();
    public GamepadControl gamepadControl = new GamepadControl();
    public TouchscreenControl touchscreenControl = new TouchscreenControl();

    public void Awake()
    {
        keyboardContol.Init();
        mouseContol.Init();
        gamepadControl.Init();
        touchscreenControl.Init();
    }

    public void OnEnable()
    {
        keyboardContol.OnEnable();
        mouseContol.OnEnable();
        gamepadControl.OnEnable();
        touchscreenControl.OnEnable();
    }

    public void OnDisable()
    {
        keyboardContol.OnDisable();
        mouseContol.OnDisable();
        gamepadControl.OnDisable();
        touchscreenControl.OnDisable();
    }

    public void Update()
    {
        DetermineHardwareControllers();
        UpdateHardwareContols();
    }

    public void DetermineHardwareControllers()
    {

        if (Keyboard.current != null && Mouse.current != null)
            if ((Keyboard.current.CheckStateIsAtDefault() == false || Mouse.current.wasUpdatedThisFrame == true) && controllerType != ControllerType.KeyboardMouse)
                controllerType = ControllerType.KeyboardMouse;

        if (Gamepad.current != null)
            if (Gamepad.current.CheckStateIsAtDefault() == false && controllerType != ControllerType.Controller)
                controllerType = ControllerType.Controller;

        if (Touchscreen.current != null)
            if (Touchscreen.current.CheckStateIsAtDefault() == false && controllerType != ControllerType.Touchscreen)//Use this when they get the unity remote working with the new input system
                controllerType = ControllerType.Touchscreen;
    }

    public void UpdateHardwareContols()
    {
        switch (controllerType)
        {
            case ControllerType.KeyboardMouse:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case ControllerType.Controller:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case ControllerType.Touchscreen:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                touchscreenControl.UpdateForRemote();
                break;
            default:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
        }
    }
}
