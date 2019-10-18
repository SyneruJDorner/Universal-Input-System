using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class InputInfo
{
    public string Name;
    public enum HardwareDeviceType
    {
        None,
        Mouse,
        Keyboard,
        Gamepad
    }
    public HardwareDeviceType HardwareDevice;
    public bool isFloat;
    public bool IsVector2;
    public float fVal;
    public Vector2 vVal;
    public float duration;
    public InputAction.CallbackContext ctx;

    public Input.KeyboardKeys_Single keyboardKeys;
    public Input.MouseKeys_Single mouseKeysSingle;
    public Input.MouseKeys_Vector2 mouseKeysVector2;
    public Input.GamepadKeys_Single gamepadKeysSingle;
    public Input.GamepadKeys_Vector2 gamepadKeysVector2;

    public InputInfo()
    {
        Name = "";
        HardwareDevice = HardwareDeviceType.None;
        isFloat = false;
        IsVector2 = false;
        fVal = 0;
        vVal = Vector2.zero;
        duration = 0;

        keyboardKeys = Input.KeyboardKeys_Single.None;
        mouseKeysSingle = Input.MouseKeys_Single.None;
        mouseKeysVector2 = Input.MouseKeys_Vector2.None;
        gamepadKeysSingle = Input.GamepadKeys_Single.None;
        gamepadKeysVector2 = Input.GamepadKeys_Vector2.None;
    }
}
