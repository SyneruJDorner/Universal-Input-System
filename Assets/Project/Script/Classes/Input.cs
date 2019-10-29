using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[DefaultExecutionOrder(2)]
public class Input
{
    private static InputSystem inputSystem;

#if UNITY_STANDALONE_WIN
    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
    public static extern short GetKeyState(int keyCode);
#endif

#if UNITY_STANDALONE_OSX
    [DllImport("/System/Library/Frameworks/ApplicationServices.framework/ApplicationServices")]
    public static extern long CGEventSourceFlagsState(int keyCode);
#endif

    #region Keyboard Keys
    public enum KeyboardKeys_Single
    {
        None,
        A, B, C, D, E, F, G, H, I, J, K, L, M,
        N, O, P, Q, R, S, T, U, V, W, X, Y, Z,

        Backquote, Backslash, Backspace, CapsLock, Comma, ContextMenu,
        Delete, DownArrow, End, Enter, Equal, Escape,

        F1, F2, F3, F4, F5, F6,
        F7, F8, F9, F10, F11, F12,

        Home, Insert, LeftAlt, LeftArrow, LeftBracket,
        LeftCtrl, LeftMeta, LeftShift, Minus,

        NumLock, Numpad0, Numpad1, Numpad2, Numpad3, Numpad4, Numpad5,
        Numpad6, Numpad7, Numpad8, Numpad9, NumpadDivide, NumpadEnter, NumpadMinus,
        NumpadMultiply, NumpadPeriod, NumpadPlus,

        PageDown, PageUp, Pause, Period, PrintScreen, Quote, RightAlt,
        RightArrow, RightBracket, RightCtrl, RightMeta, RightShift,
        ScrollLock, Semicolon, Slash, Space, Tab, UpArrow
    }
    #endregion

    #region Mouse Keys
    public enum MouseKeys_Single
    {
        None,
        BackButton, ForwardButton, LeftButton, MiddleButton, RightButton
    }

    public enum MouseKeys_Vector2
    {
        None,
        Delta, Scroll, Position
    }
    #endregion

    #region Mouse Keys
    public enum GamepadKeys_Single
    {
        None,
        ButtonEast, ButtonNorth, ButtonSouth, ButtonWest,
        DpadNorth, DpadEast, DpadSouth, DpadWest,
        LeftShoulder, LeftTrigger, LeftStickPress,
        LeftStickNorth, LeftStickEast, LeftStickSouth, LeftStickWest,
        RightShoulder, RightStickPress, RightTrigger,
        RightStickNorth, RightStickEast, RightStickSouth, RightStickWest,
        Select, Start
    }

    public enum GamepadKeys_Vector2
    {
        None,
        Dpad, LeftStick, RightStick
    }
    #endregion

    public static void UpdateKeyDurations()
    {
        inputSystem = inputSystem ?? InputSystem.Instance;

        for (int i = 0; i < inputSystem.dictionaryBinding.Count; i++)
        {
            if (inputSystem.dictionaryBinding[i].inputAction != null &&
                inputSystem.dictionaryBinding[i].inputAction.controls.Count > 0)
            {
                try
                {
                    //Skip bindings that have occured. Prevent active bindings and prevent them from being 0
                    ButtonControl bc = (ButtonControl)inputSystem.dictionaryBinding[i].inputAction.controls[0];

                    if (bc != null)
                    {
                        bool state = bc.isPressed;

                        if (state == true)
                            inputSystem.dictionaryBinding[i].duration += Time.deltaTime;
                        else
                            inputSystem.dictionaryBinding[i].duration = 0;
                    }
                    else
                        inputSystem.dictionaryBinding[i].duration = 0;
                }
                catch (Exception) { }
            }
        }
    }

    public static bool GetKeyDown(string bindingName)
    {
        inputSystem = inputSystem ?? InputSystem.Instance;

        for (int i = 0; i < inputSystem.dictionaryBinding.Count; i++)
        {
            if (bindingName != inputSystem.dictionaryBinding[i].Key)
                continue;

            if (inputSystem.dictionaryBinding[i].inputAction != null &&
                inputSystem.dictionaryBinding[i].inputAction.controls.Count > 0)
            {
                try
                {
                    ButtonControl bc = (ButtonControl)inputSystem.dictionaryBinding[i].inputAction.controls[0];
                    return bc.wasPressedThisFrame;
                }
                catch (Exception) { }
            }
        }

        return false;
    }

    public static bool GetKey(string bindingName)
    {
        inputSystem = inputSystem ?? InputSystem.Instance;

        for (int i = 0; i < inputSystem.dictionaryBinding.Count; i++)
        {
            if (bindingName != inputSystem.dictionaryBinding[i].Key)
                continue;

            if (inputSystem.dictionaryBinding[i].inputAction != null &&
                inputSystem.dictionaryBinding[i].inputAction.controls.Count > 0)
            {
                try
                {
                    ButtonControl bc = (ButtonControl)inputSystem.dictionaryBinding[i].inputAction.controls[0];
                    return bc.isPressed;
                }
                catch (Exception) { }
            }
        }


        return false;
    }

    public static bool GetKeyUp(string bindingName)
    {
        inputSystem = inputSystem ?? InputSystem.Instance;

        for (int i = 0; i < inputSystem.dictionaryBinding.Count; i++)
        {
            if (bindingName != inputSystem.dictionaryBinding[i].Key)
                continue;

            if (inputSystem.dictionaryBinding[i].inputAction != null &&
                inputSystem.dictionaryBinding[i].inputAction.controls.Count > 0)
            {
                try
                {
                    ButtonControl bc = (ButtonControl)inputSystem.dictionaryBinding[i].inputAction.controls[0];
                    return bc.wasReleasedThisFrame;
                }
                catch (Exception) { }
            }
        }

        return false;
    }

    public static float GetFloat(string bindingName)
    {
        inputSystem = InputSystem.Instance;
        InputSystem.KeyValuePair bind = inputSystem.dictionaryBinding.Find(item => item.Key.Contains(bindingName));
        return (bind != null) ? bind.fVal : 0;
    }

    public static Vector2 GetVector2(string bindingName)
    {
        inputSystem = InputSystem.Instance;
        InputSystem.KeyValuePair bind = inputSystem.dictionaryBinding.Find(item => item.Key.Contains(bindingName));
        return (bind != null) ? bind.vVal : Vector2.zero;
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