using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    #region Singleton Access
    private static InputSystem instance;//Use of a singleton here, needs to be static in order for other scripts to access it.

    public static InputSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<InputSystem>();
            }

            return instance;
        }
    }
    #endregion

    #region Variables
    [HideInInspector] private InputControls inputControls;
    [HideInInspector] private InputControls.KeyboardActions keyboard_Controller;
    [HideInInspector] private InputControls.GamepadActions gamepad_Controller;
    [HideInInspector] private InputControls.MouseActions mouse_Controller;
    public List<InputBindingCollection> Binding = new List<InputBindingCollection>();
    #endregion

    #region Init
    public void Awake()
    {
        inputControls = new InputControls();
        InitKeyboard();
        InitMouse();
        InitGamepad();
        SortToMatch();
    }

    public void InitKeyboard()
    {
        keyboard_Controller = inputControls.Keyboard;
        inputControls.Keyboard.Enable();

        InitBinding(keyboard_Controller.A, typeof(float));
        InitBinding(keyboard_Controller.B, typeof(float));
        InitBinding(keyboard_Controller.C, typeof(float));
        InitBinding(keyboard_Controller.D, typeof(float));
        InitBinding(keyboard_Controller.E, typeof(float));
        InitBinding(keyboard_Controller.F, typeof(float));
        InitBinding(keyboard_Controller.G, typeof(float));
        InitBinding(keyboard_Controller.H, typeof(float));
        InitBinding(keyboard_Controller.I, typeof(float));
        InitBinding(keyboard_Controller.J, typeof(float));
        InitBinding(keyboard_Controller.K, typeof(float));
        InitBinding(keyboard_Controller.L, typeof(float));
        InitBinding(keyboard_Controller.M, typeof(float));
        InitBinding(keyboard_Controller.N, typeof(float));
        InitBinding(keyboard_Controller.O, typeof(float));
        InitBinding(keyboard_Controller.P, typeof(float));
        InitBinding(keyboard_Controller.Q, typeof(float));
        InitBinding(keyboard_Controller.R, typeof(float));
        InitBinding(keyboard_Controller.S, typeof(float));
        InitBinding(keyboard_Controller.T, typeof(float));
        InitBinding(keyboard_Controller.U, typeof(float));
        InitBinding(keyboard_Controller.V, typeof(float));
        InitBinding(keyboard_Controller.W, typeof(float));
        InitBinding(keyboard_Controller.X, typeof(float));
        InitBinding(keyboard_Controller.Y, typeof(float));
        InitBinding(keyboard_Controller.Z, typeof(float));

        InitBinding(keyboard_Controller.Backquote, typeof(float));
        InitBinding(keyboard_Controller.Backslash, typeof(float));
        InitBinding(keyboard_Controller.Backspace, typeof(float));
        InitBinding(keyboard_Controller.CapsLock, typeof(float));
        InitBinding(keyboard_Controller.Comma, typeof(float));
        InitBinding(keyboard_Controller.ContextMenu, typeof(float));
        InitBinding(keyboard_Controller.Delete, typeof(float));
        InitBinding(keyboard_Controller.DownArrow, typeof(float));
        InitBinding(keyboard_Controller.End, typeof(float));
        InitBinding(keyboard_Controller.Enter, typeof(float));
        InitBinding(keyboard_Controller.Equal, typeof(float));
        InitBinding(keyboard_Controller.Escape, typeof(float));

        InitBinding(keyboard_Controller.F1, typeof(float));
        InitBinding(keyboard_Controller.F2, typeof(float));
        InitBinding(keyboard_Controller.F3, typeof(float));
        InitBinding(keyboard_Controller.F4, typeof(float));
        InitBinding(keyboard_Controller.F5, typeof(float));
        InitBinding(keyboard_Controller.F6, typeof(float));
        InitBinding(keyboard_Controller.F7, typeof(float));
        InitBinding(keyboard_Controller.F8, typeof(float));
        InitBinding(keyboard_Controller.F9, typeof(float));
        InitBinding(keyboard_Controller.F10, typeof(float));
        InitBinding(keyboard_Controller.F11, typeof(float));
        InitBinding(keyboard_Controller.F12, typeof(float));

        InitBinding(keyboard_Controller.Home, typeof(float));
        InitBinding(keyboard_Controller.Insert, typeof(float));
        InitBinding(keyboard_Controller.LeftAlt, typeof(float));
        InitBinding(keyboard_Controller.LeftArrow, typeof(float));
        InitBinding(keyboard_Controller.LeftBracket, typeof(float));
        InitBinding(keyboard_Controller.LeftCtrl, typeof(float));
        InitBinding(keyboard_Controller.LeftMeta, typeof(float));
        InitBinding(keyboard_Controller.LeftShift, typeof(float));
        InitBinding(keyboard_Controller.Minus, typeof(float));

        InitBinding(keyboard_Controller.NumLock, typeof(float));
        InitBinding(keyboard_Controller.Numpad0, typeof(float));
        InitBinding(keyboard_Controller.Numpad1, typeof(float));
        InitBinding(keyboard_Controller.Numpad2, typeof(float));
        InitBinding(keyboard_Controller.Numpad3, typeof(float));
        InitBinding(keyboard_Controller.Numpad4, typeof(float));
        InitBinding(keyboard_Controller.Numpad5, typeof(float));
        InitBinding(keyboard_Controller.Numpad6, typeof(float));
        InitBinding(keyboard_Controller.Numpad7, typeof(float));
        InitBinding(keyboard_Controller.Numpad8, typeof(float));
        InitBinding(keyboard_Controller.Numpad9, typeof(float));
        InitBinding(keyboard_Controller.NumpadDivide, typeof(float));
        InitBinding(keyboard_Controller.NumpadEnter, typeof(float));
        InitBinding(keyboard_Controller.NumpadMinus, typeof(float));
        InitBinding(keyboard_Controller.NumpadMultiply, typeof(float));
        InitBinding(keyboard_Controller.NumpadPeriod, typeof(float));
        InitBinding(keyboard_Controller.NumpadPlus, typeof(float));

        InitBinding(keyboard_Controller.PageDown, typeof(float));
        InitBinding(keyboard_Controller.PageUp, typeof(float));
        InitBinding(keyboard_Controller.Pause, typeof(float));
        InitBinding(keyboard_Controller.Period, typeof(float));
        InitBinding(keyboard_Controller.PrintScreen, typeof(float));
        InitBinding(keyboard_Controller.Quote, typeof(float));
        InitBinding(keyboard_Controller.RightAlt, typeof(float));
        InitBinding(keyboard_Controller.RightArrow, typeof(float));
        InitBinding(keyboard_Controller.RightBracket, typeof(float));
        InitBinding(keyboard_Controller.RightCtrl, typeof(float));
        InitBinding(keyboard_Controller.RightMeta, typeof(float));
        InitBinding(keyboard_Controller.RightShift, typeof(float));
        InitBinding(keyboard_Controller.ScrollLock, typeof(float));
        InitBinding(keyboard_Controller.Semicolon, typeof(float));
        InitBinding(keyboard_Controller.Slash, typeof(float));
        InitBinding(keyboard_Controller.Space, typeof(float));
        InitBinding(keyboard_Controller.Tab, typeof(float));
        InitBinding(keyboard_Controller.UpArrow, typeof(float));
    }

    private void InitGamepad()
    {
        gamepad_Controller = inputControls.Gamepad;
        inputControls.Gamepad.Enable();

        InitBinding(gamepad_Controller.ButtonEast, typeof(float));
        InitBinding(gamepad_Controller.ButtonNorth, typeof(float));
        InitBinding(gamepad_Controller.ButtonSouth, typeof(float));
        InitBinding(gamepad_Controller.ButtonWest, typeof(float));
        InitBinding(gamepad_Controller.Dpad, typeof(Vector2));
        InitBinding(gamepad_Controller.LeftShoulder, typeof(float));
        InitBinding(gamepad_Controller.LeftStick, typeof(Vector2));
        InitBinding(gamepad_Controller.LeftStickPress, typeof(float));
        InitBinding(gamepad_Controller.LeftTrigger, typeof(float));
        InitBinding(gamepad_Controller.RightShoulder, typeof(float));
        InitBinding(gamepad_Controller.RightStick, typeof(Vector2));
        InitBinding(gamepad_Controller.RightStickPress, typeof(float));
        InitBinding(gamepad_Controller.RightTrigger, typeof(float));
        InitBinding(gamepad_Controller.Select, typeof(float));
        InitBinding(gamepad_Controller.Start, typeof(float));
    }

    private void InitMouse()
    {
        mouse_Controller = inputControls.Mouse;
        inputControls.Mouse.Enable();

        InitBinding(mouse_Controller.BackButton, typeof(float));
        InitBinding(mouse_Controller.ForwardButton, typeof(float));
        InitBinding(mouse_Controller.LeftClick, typeof(float));
        InitBinding(mouse_Controller.MiddleClick, typeof(float));
        InitBinding(mouse_Controller.RightClick, typeof(float));
        InitBinding(mouse_Controller.Delta, typeof(Vector2));
        InitBinding(mouse_Controller.Scroll, typeof(Vector2));
        InitBinding(mouse_Controller.Position, typeof(Vector2), false);
    }

    private void SortToMatch()
    {
        for (int i = 0; i < Binding.Count; i++)
        {
            if (Binding[i].keyboardKeys.Count > 1)
            {
                for (int o = 0; o < Binding[i].keyboardKeys.Count; o++)
                {
                    int currentIndex = Binding[i].keyboardInputs.FindIndex(item => item.Name == Binding[i].keyboardKeys[o].ToString());

                    if (currentIndex == -1)
                    {
                        Binding[i].keyboardKeys = new List<Input.KeyboardKeys>(0);
                        continue;
                    }

                    InputInfo cachedInfo = Binding[i].keyboardInputs[currentIndex];
                    Binding[i].keyboardInputs.RemoveAt(currentIndex);
                    Binding[i].keyboardInputs.Insert(o, cachedInfo);
                }
            }

            if (Binding[i].mouseKeys.Count > 1)
            {
                for (int o = 0; o < Binding[i].mouseKeys.Count; o++)
                {
                    int currentIndex = Binding[i].mouseInputs.FindIndex(item => item.Name == Binding[i].mouseKeys[o].ToString());

                    if (currentIndex == -1)
                    {
                        Binding[i].mouseKeys = new List<Input.MouseKeys>(0);
                        continue;
                    }

                    InputInfo cachedInfo = Binding[i].mouseInputs[currentIndex];
                    Binding[i].mouseInputs.RemoveAt(currentIndex);
                    Binding[i].mouseInputs.Insert(o, cachedInfo);
                }
            }

            if (Binding[i].gamepadKeys.Count > 1)
            {
                for (int o = 0; o < Binding[i].gamepadKeys.Count; o++)
                {
                    int currentIndex = Binding[i].gamepadInputs.FindIndex(item => item.Name == Binding[i].gamepadKeys[o].ToString());

                    if (currentIndex == -1)
                    {
                        Binding[i].gamepadKeys = new List<Input.GamepadKeys>(0);
                        continue;
                    }

                    InputInfo cachedInfo = Binding[i].gamepadInputs[currentIndex];
                    Binding[i].gamepadInputs.RemoveAt(currentIndex);
                    Binding[i].gamepadInputs.Insert(o, cachedInfo);
                }
            }
        }
    }

    private void InitBinding(InputAction inputAction, Type assignedType, bool hasCancel = true)
    {
        UpdateInputInfo.InitDefinedInput(inputAction, assignedType);
        EventInit(inputAction, hasCancel);
    }

    private void EventInit(InputAction inputAction, bool hasCancel)
    {
        inputAction.performed += ctx =>
        {
            for (int i = 0; i < Binding.Count; i++)
            {
                int indexKeyboard = Binding[i].keyboardInputs.FindIndex(item => item.Name.ToLower() == ctx.control.ToString().Split('/').Last().ToLower());
                int indexMouse = Binding[i].mouseInputs.FindIndex(item => item.Name.ToLower() == ctx.control.ToString().Split('/').Last().ToLower());
                int indexGamepad = Binding[i].gamepadInputs.FindIndex(item => item.Name.ToLower() == ctx.control.ToString().Split('/').Last().ToLower());

                if (indexKeyboard >= 0)
                {
                    InputInfo currentInputInfo = Binding[i].keyboardInputs[indexKeyboard];
                    UpdateInputInfo.UpdateInfo(i, ref currentInputInfo, ctx);
                    Binding.ElementAt(i).keyboardInputs[indexKeyboard] = currentInputInfo;
                }

                if (indexMouse >= 0)
                {
                    InputInfo currentInputInfo = Binding[i].mouseInputs[indexMouse];
                    UpdateInputInfo.UpdateInfo(i, ref currentInputInfo, ctx);
                    Binding.ElementAt(i).mouseInputs[indexMouse] = currentInputInfo;
                }

                if (indexGamepad >= 0)
                {
                    InputInfo currentInputInfo = Binding[i].gamepadInputs[indexGamepad];
                    UpdateInputInfo.UpdateInfo(i, ref currentInputInfo, ctx);
                    Binding.ElementAt(i).gamepadInputs[indexGamepad] = currentInputInfo;
                }
            }
        };

        if (hasCancel == false)
            return;

        inputAction.canceled += ctx =>
        {
            for (int i = 0; i < Binding.Count; i++)
            {
                int indexKeyboard = Binding[i].keyboardInputs.FindIndex(item => item.Name.ToLower() == ctx.control.ToString().Split('/').Last().ToLower());
                int indexMouse = Binding[i].mouseInputs.FindIndex(item => item.Name.ToLower() == ctx.control.ToString().Split('/').Last().ToLower());
                int indexGamepad = Binding[i].gamepadInputs.FindIndex(item => item.Name.ToLower() == ctx.control.ToString().Split('/').Last().ToLower());

                if (indexKeyboard >= 0)
                {
                    InputInfo currentInputInfo = Binding[i].keyboardInputs[indexKeyboard];
                    UpdateInputInfo.UpdateInfo(i, ref currentInputInfo, ctx);
                }

                if (indexMouse >= 0)
                {
                    InputInfo currentInputInfo = Binding[i].mouseInputs[indexMouse];
                    UpdateInputInfo.UpdateInfo(i, ref currentInputInfo, ctx);
                }

                if (indexGamepad >= 0)
                {
                    InputInfo currentInputInfo = Binding[i].gamepadInputs[indexGamepad];
                    UpdateInputInfo.UpdateInfo(i, ref currentInputInfo, ctx);
                }
            }
        };
    }
    #endregion

    #region Release Keys (LateUpdate)
    public void LateUpdate()
    {
        for (int i = 0; i < Binding.Count; i++)
        {
            for (int o = 0; o < Binding[i].keyboardInputs.Count; o++)
            {
                Binding[i].keyboardInputs[o].LateUpdate();
            }

            for (int o = 0; o < Binding[i].mouseInputs.Count; o++)
            {
                Binding[i].mouseInputs[o].LateUpdate();
            }

            for (int o = 0; o < Binding[i].gamepadInputs.Count; o++)
            {
                Binding[i].gamepadInputs[o].LateUpdate();
            }
        }
    }
    #endregion
}