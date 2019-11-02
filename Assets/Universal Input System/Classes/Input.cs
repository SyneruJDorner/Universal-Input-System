using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public static class Input
{
    private static UniversalInputSystem inputSystem;

#if UNITY_STANDALONE_WIN
    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
    public static extern short GetKeyState(int keyCode);
#endif

#if UNITY_STANDALONE_OSX
    [DllImport("/System/Library/Frameworks/ApplicationServices.framework/ApplicationServices")]
    public static extern long CGEventSourceFlagsState(int keyCode);
#endif

    public static bool GetKeyDown(string bindingName)
    {
        inputSystem = inputSystem ?? UniversalInputSystem.Instance;
        bool returnState = false;
        InputAction inputAction = null;

        for (int i = 0; i < inputSystem.definedBindings.Count; i++)
        {
            if (bindingName != inputSystem.definedBindings[i].bindingName)
                continue;

            KeyboardBindingInfo keyboardBindingInfo = inputSystem.definedBindings[i].bindingInfo.keyboardBindingInfo;
            MouseBindingInfo mouseBindingInfo = inputSystem.definedBindings[i].bindingInfo.mouseBindingInfo;
            GamepadBindingInfo gamepadBindingInfo = inputSystem.definedBindings[i].bindingInfo.gamepadBindingInfo;

            for (int j = 0; j < keyboardBindingInfo.inputActions.Count; j++)
            {
                inputAction = keyboardBindingInfo.inputActions[j];

                if (inputAction != null && inputAction.controls.Count > 0)
                {
                    try
                    {
                        ButtonControl bc = (ButtonControl)inputAction.controls[0];

                        if (returnState == false)
                            returnState = bc.wasPressedThisFrame;
                    }
                    catch (Exception) { }
                }
            }

            for (int j = 0; j < mouseBindingInfo.inputActions.Count; j++)
            {
                inputAction = mouseBindingInfo.inputActions[j];

                if (inputAction != null && inputAction.controls.Count > 0)
                {
                    try
                    {
                        ButtonControl bc = (ButtonControl)inputAction.controls[0];

                        if (returnState == false)
                            returnState = bc.wasPressedThisFrame;
                    }
                    catch (Exception) { }
                }
            }

            for (int j = 0; j < gamepadBindingInfo.inputActions.Count; j++)
            {
                inputAction = gamepadBindingInfo.inputActions[j];

                if (inputAction != null && inputAction.controls.Count > 0)
                {
                    try
                    {
                        ButtonControl bc = (ButtonControl)inputAction.controls[0];

                        if (returnState == false)
                            returnState = bc.wasPressedThisFrame;
                    }
                    catch (Exception) { }
                }
            }
        }

        return returnState;
    }

    public static bool GetKey(string bindingName)
    {
        inputSystem = inputSystem ?? UniversalInputSystem.Instance;
        bool returnState = false;
        InputAction inputAction = null;

        for (int i = 0; i < inputSystem.definedBindings.Count; i++)
        {
            if (bindingName != inputSystem.definedBindings[i].bindingName)
                continue;

            KeyboardBindingInfo keyboardBindingInfo = inputSystem.definedBindings[i].bindingInfo.keyboardBindingInfo;
            MouseBindingInfo mouseBindingInfo = inputSystem.definedBindings[i].bindingInfo.mouseBindingInfo;
            GamepadBindingInfo gamepadBindingInfo = inputSystem.definedBindings[i].bindingInfo.gamepadBindingInfo;

            for (int j = 0; j < keyboardBindingInfo.inputActions.Count; j++)
            {
                inputAction = keyboardBindingInfo.inputActions[j];

                if (inputAction != null && inputAction.controls.Count > 0)
                {
                    try
                    {
                        ButtonControl bc = (ButtonControl)inputAction.controls[0];

                        if (returnState == false)
                            returnState = bc.isPressed;
                    }
                    catch (Exception) { }
                }
            }

            for (int j = 0; j < mouseBindingInfo.inputActions.Count; j++)
            {
                inputAction = mouseBindingInfo.inputActions[j];

                if (inputAction != null && inputAction.controls.Count > 0)
                {
                    try
                    {
                        ButtonControl bc = (ButtonControl)inputAction.controls[0];

                        if (returnState == false)
                            returnState = bc.isPressed;
                    }
                    catch (Exception) { }
                }
            }

            for (int j = 0; j < gamepadBindingInfo.inputActions.Count; j++)
            {
                inputAction = gamepadBindingInfo.inputActions[j];

                if (inputAction != null && inputAction.controls.Count > 0)
                {
                    try
                    {
                        ButtonControl bc = (ButtonControl)inputAction.controls[0];

                        if (returnState == false)
                            returnState = bc.isPressed;
                    }
                    catch (Exception) { }
                }
            }
        }

        return returnState;
    }

    public static bool GetKeyUp(string bindingName)
    {
        inputSystem = inputSystem ?? UniversalInputSystem.Instance;
        bool returnState = false;
        InputAction inputAction = null;

        for (int i = 0; i < inputSystem.definedBindings.Count; i++)
        {
            if (bindingName != inputSystem.definedBindings[i].bindingName)
                continue;

            KeyboardBindingInfo keyboardBindingInfo = inputSystem.definedBindings[i].bindingInfo.keyboardBindingInfo;
            MouseBindingInfo mouseBindingInfo = inputSystem.definedBindings[i].bindingInfo.mouseBindingInfo;
            GamepadBindingInfo gamepadBindingInfo = inputSystem.definedBindings[i].bindingInfo.gamepadBindingInfo;

            for (int j = 0; j < keyboardBindingInfo.inputActions.Count; j++)
            {
                inputAction = keyboardBindingInfo.inputActions[j];

                if (inputAction != null && inputAction.controls.Count > 0)
                {
                    try
                    {
                        ButtonControl bc = (ButtonControl)inputAction.controls[0];

                        if (returnState == false)
                            returnState = bc.wasReleasedThisFrame;
                    }
                    catch (Exception) { }
                }
            }

            for (int j = 0; j < mouseBindingInfo.inputActions.Count; j++)
            {
                inputAction = mouseBindingInfo.inputActions[j];

                if (inputAction != null && inputAction.controls.Count > 0)
                {
                    try
                    {
                        ButtonControl bc = (ButtonControl)inputAction.controls[0];

                        if (returnState == false)
                            returnState = bc.wasReleasedThisFrame;
                    }
                    catch (Exception) { }
                }
            }

            for (int j = 0; j < gamepadBindingInfo.inputActions.Count; j++)
            {
                inputAction = gamepadBindingInfo.inputActions[j];

                if (inputAction != null && inputAction.controls.Count > 0)
                {
                    try
                    {
                        ButtonControl bc = (ButtonControl)inputAction.controls[0];

                        if (returnState == false)
                            returnState = bc.wasReleasedThisFrame;
                    }
                    catch (Exception) { }
                }
            }
        }

        return returnState;
    }

    public static float GetFloat(string bindingName)
    {
        inputSystem = UniversalInputSystem.Instance;
        DefinedInputBindings bind = inputSystem.definedBindings.Find(item => item.bindingName.Contains(bindingName));
        return (bind != null) ? bind.fVal : 0;
    }

    public static Vector2 GetVector2(string bindingName)
    {
        inputSystem = UniversalInputSystem.Instance;
        DefinedInputBindings bind = inputSystem.definedBindings.Find(item => item.bindingName.Contains(bindingName));
        Vector2 currentVal = (bind != null) ? bind.vVal : Vector2.zero;
        return currentVal;
    }

    public static bool IsCapsLockOn()
    {
#if UNITY_STANDALONE_WIN
        return (((ushort)GetKeyState(0x14)) & 0xffff) != 0;
#endif

#if UNITY_STANDALONE_OSX
        return (CGEventSourceFlagsState(1) & 0x00010000) != 0;
#endif
    }

    public static bool IsNumLockOn()
    {
#if UNITY_STANDALONE_WIN
        return (((ushort)GetKeyState(0x90)) & 0xffff) != 0;
#endif

#if UNITY_STANDALONE_OSX
        return (CGEventSourceFlagsState(1) & 0x00010000) != 0;
#endif
    }

    public static bool IsScrollLockOn()
    {
#if UNITY_STANDALONE_WIN
        return (((ushort)GetKeyState(0x91)) & 0xffff) != 0;
#endif

#if UNITY_STANDALONE_OSX
        return (CGEventSourceFlagsState(1) & 0x00010000) != 0;
#endif
    }
}
