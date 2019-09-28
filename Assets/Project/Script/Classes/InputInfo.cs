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
    public InputActionPhase inputActionPhase;
    private InputActionPhase lastKnownInputActionPhase;
    public float duration;

    public Input.KeyboardKeys keyboardKeys;
    public Input.GamepadKeys gamepadKeys;

    public InputInfo()
    {
        Name = "";
        HardwareDevice = HardwareDeviceType.None;
        isFloat = false;
        IsVector2 = false;
        fVal = 0;
        vVal = Vector2.zero;
        inputActionPhase = InputActionPhase.Disabled;
        lastKnownInputActionPhase = InputActionPhase.Disabled;
        duration = 0;

        keyboardKeys = Input.KeyboardKeys.None;
        gamepadKeys = Input.GamepadKeys.None;
    }

    public virtual bool InitiatedPressed()
    {
        if (lastKnownInputActionPhase != InputActionPhase.Performed)
            if (lastKnownInputActionPhase != inputActionPhase)
                return true;
        return false;
    }

    public virtual bool IsPressed()
    {
        if (inputActionPhase == InputActionPhase.Performed)
            return true;
        return false;
    }

    public virtual bool IsReleased()
    {
        if (inputActionPhase == InputActionPhase.Canceled)
            return true;
        return false;
    }

    #region Late Update Info

    public void LateUpdate()
    {
        UpdateDuration();
        LateInputActionPhasePressedInitializer();
    }

    private void UpdateDuration()
    {
        if (fVal != 0 || vVal != Vector2.zero)
            duration += Time.deltaTime;
        else
            duration = 0;
    }

    private void LateInputActionPhasePressedInitializer()
    {
        lastKnownInputActionPhase = inputActionPhase;
    }
    #endregion
}
