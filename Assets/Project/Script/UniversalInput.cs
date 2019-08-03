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
    }
    public ControllerType controllerType = ControllerType.KeyboardMouse;

    public KeyboardContol keyboardContol = new KeyboardContol();
    public MouseControl mouseContol = new MouseControl();
    public GamepadControl gamepadControl = new GamepadControl();

    public void Awake()
    {
        keyboardContol.Init();
        mouseContol.Init();
        gamepadControl.Init();
    }

    public void OnEnable()
    {
        keyboardContol.OnEnable();
        mouseContol.OnEnable();
        gamepadControl.OnEnable();
    }

    public void OnDisable()
    {
        keyboardContol.OnDisable();
        mouseContol.OnDisable();
        gamepadControl.OnDisable();
    }

    public void Update()
    {
        DetermineHardwareControllers();
    }

    public void DetermineHardwareControllers()
    {
        if ((Keyboard.current.CheckStateIsAtDefault() == false || Mouse.current.wasUpdatedThisFrame == true) && controllerType != ControllerType.KeyboardMouse)
            controllerType = ControllerType.KeyboardMouse;
        else if (Gamepad.current.CheckStateIsAtDefault() == false && controllerType != ControllerType.Controller)
            controllerType = ControllerType.Controller;

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
            default:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
        }
    }
}
