using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input
{
    private static InputSystem inputSystem;

    public enum KeyboardKeys
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

    public enum MouseKeys
    {
        None,
        BackButton, ForwardButton, LeftClick, MiddleClick, RightClick,
        Delta, Scroll
    }

    public enum GamepadKeys
    {
        None,
        ButtonEast, ButtonNorth, ButtonSouth, ButtonWest,
        Dpad, DpadNorth, DpadEast, DpadSouth, DpadWest,
        LeftShoulder, LeftTrigger, LeftStickPress,
        LeftStick, LeftStickNorth, LeftStickEast, LeftStickSouth, LeftStickWest,
        RightShoulder, RightStickPress, RightTrigger,
        RightStick, RightStickNorth, RightStickEast, RightStickSouth, RightStickWest,
        Select, Start
    }

    public static bool IsKeyDown(string bindingName)
    {
        inputSystem = inputSystem ?? InputSystem.Instance;

        for (int i = 0; i < inputSystem.Binding.Count; i++)
        {
            if (inputSystem.Binding[i].inputType == InputBindingCollection.InputType.Single)
            {
                if (GetFloat(bindingName) != 0)
                    return true;
            }

            if (inputSystem.Binding[i].inputType == InputBindingCollection.InputType.Vector2)
            {
                if (GetVector2(bindingName) != Vector2.zero)
                    return true;
            }
        }

        return false;
    }

    public static bool IsKeyUp(string bindingName)
    {
        inputSystem = inputSystem ?? InputSystem.Instance;

        for (int i = 0; i < inputSystem.Binding.Count; i++)
        {
            if (inputSystem.Binding[i].inputType == InputBindingCollection.InputType.Single)
            {
                if (GetFloat(bindingName) == 0)
                    return true;
            }

            if (inputSystem.Binding[i].inputType == InputBindingCollection.InputType.Vector2)
            {
                if (GetVector2(bindingName) == Vector2.zero)
                    return true;
            }
        }

        return false;
    }

    public static float GetFloat(string bindingName)
    {
        inputSystem = inputSystem ?? InputSystem.Instance;

        for (int i = 0; i < inputSystem.Binding.Count; i++)
        {
            if (inputSystem.Binding[i].name == bindingName)
            {
                InputBindingCollection bind = inputSystem.Binding[i];
                if (bind.inputType == InputBindingCollection.InputType.Single)
                    return bind.fVal;
            }
        }
        return 0;
    }

    public static Vector2 GetVector2(string bindingName)
    {
        inputSystem = inputSystem ?? InputSystem.Instance;

        for (int i = 0; i < inputSystem.Binding.Count; i++)
        {
            if (inputSystem.Binding[i].name == bindingName)
            {
                InputBindingCollection bind = inputSystem.Binding[i];

                if (bind.inputType == InputBindingCollection.InputType.Vector2)
                    return bind.vVal;
            }
        }
        return Vector2.zero;
    }
}