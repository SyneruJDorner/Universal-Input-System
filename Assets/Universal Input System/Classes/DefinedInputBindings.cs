using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum InputType
{
    Single,
    Vector2,
}

[System.Serializable]
public class DefinedInputBindings
{
    public string bindingName;//Key
    public InputType inputReturnType = InputType.Single;        //Value return type
    public BindingInfo bindingInfo = new BindingInfo();         //Value
    public List<string> lookupBindings = new List<string>();

    //Children need to pass thier fVal and vVal here as a globalized vaiable that the bindings control
    public float fVal = 0;
    public Vector2 vVal = new Vector2(0, 0);
    public float duration = 0;

    //Editor related variables
    public enum HardwareDeviceType
    {
        Mouse,
        Keyboard,
        Gamepad
    }
    public HardwareDeviceType selectedBindingDevice;
    public bool editing;
}

[System.Serializable]
public class BindingInfo
{
    public KeyboardBindingInfo keyboardBindingInfo = new KeyboardBindingInfo();
    public MouseBindingInfo mouseBindingInfo = new MouseBindingInfo();
    public GamepadBindingInfo gamepadBindingInfo = new GamepadBindingInfo();
}

public class UniversalBindingInfo
{
    public List<InputAction> inputActions = new List<InputAction>();
    public List<InputAction.CallbackContext> ctx = new List<InputAction.CallbackContext>();

    public List<float> fVal = new List<float>();
    public Vector2 vVal = new Vector2(0, 0);
}

[System.Serializable]
public class KeyboardBindingInfo : UniversalBindingInfo
{
    public enum KeyboardKeys
    {
        None = 0,
        A = 1, B = 2, C = 3, D = 4, E = 5, F = 6, G = 7,
        H = 8, I = 9, J = 10, K = 11, L = 12, M = 13, N = 14,
        O = 15, P = 16, Q = 17, R = 18, S = 19, T = 20, U = 21,
        V = 22, W = 23, X = 24, Y = 25, Z = 26,

        Backquote = 27, Backslash = 28, Backspace = 29, CapsLock = 30, Comma = 31, ContextMenu = 32,
        Delete = 33, DownArrow = 34, End = 35, Enter = 36, Equal = 37, Escape = 38,

        F1 = 39, F2 = 40, F3 = 41, F4 = 42, F5 = 43, F6 = 44,
        F7 = 45, F8 = 46, F9 = 47, F10 = 48, F11 = 49, F12 = 50,

        Home = 51, Insert = 52, LeftAlt = 53, LeftArrow = 54, LeftBracket = 55,
        LeftCtrl = 56, LeftMeta = 57, LeftShift = 58, Minus = 59,

        NumLock = 60, Numpad0 = 61, Numpad1 = 62, Numpad2 = 63, Numpad3 = 64, Numpad4 = 65, Numpad5 = 66,
        Numpad6 = 67, Numpad7 = 68, Numpad8 = 69, Numpad9 = 70, NumpadDivide = 71, NumpadEnter = 72, NumpadMinus = 73,
        NumpadMultiply = 74, NumpadPeriod = 75, NumpadPlus = 76,

        PageDown = 77, PageUp = 78, Pause = 79, Period = 80, PrintScreen = 81, Quote = 82, RightAlt = 83,
        RightArrow = 84, RightBracket = 85, RightCtrl = 86, RightMeta = 87, RightShift = 88,
        ScrollLock = 89, Semicolon = 90, Slash = 91, Space = 92, Tab = 93, UpArrow = 94
    }
    public List<KeyboardKeys> keyboardFlags = new List<KeyboardKeys>();
}

[System.Serializable]
public class MouseBindingInfo : UniversalBindingInfo
{
    public enum MouseKeys
    {
        None = 0,
        BackButton = 1, ForwardButton = 2, LeftButton = 3, MiddleButton = 4, RightButton = 5,
        Delta = 100, Scroll = 101, Position = 102
    }
    public List<MouseKeys> mouseKeys = new List<MouseKeys>();

    //Sensitivity control
    public float mouseSensitivity = 1;
}

[System.Serializable]
public class GamepadBindingInfo : UniversalBindingInfo
{
    public enum GamepadKeys
    {
        None = 0,
        ButtonEast = 1, ButtonNorth = 2, ButtonSouth = 3, ButtonWest = 4,
        DpadNorth = 5, DpadEast = 6, DpadSouth = 7, DpadWest = 8,
        LeftShoulder = 9, LeftTrigger = 10, LeftStickPress = 11,
        LeftStickNorth = 12, LeftStickEast = 13, LeftStickSouth = 14, LeftStickWest = 15,
        RightShoulder = 16, RightStickPress = 17, RightTrigger = 18,
        RightStickNorth = 19, RightStickEast = 20, RightStickSouth = 21, RightStickWest = 22,
        Select = 23, Start = 24,

        Dpad = 100, LeftStick = 101, RightStick = 102
    }
    public List<GamepadKeys> gamepadKeys = new List<GamepadKeys>();

    //Sensitivity control
    public float leftJoystickSensitivity = 1;
    public float rightJoystickSensitivity = 1;
}