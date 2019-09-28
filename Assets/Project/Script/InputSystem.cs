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
    public List<InputBindingCollection> Binding = new List<InputBindingCollection>();
    #endregion

    #region Init
    public void Awake()
    {
        inputControls = new InputControls();
        InitKeyboard();
        InitGamepad();
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

    private void InitBinding(InputAction inputAction, Type assignedType)
    {
        EventInit(inputAction);
        UpdateInputInfo.InitDefinedInput(inputAction, assignedType);
    }

    private void EventInit(InputAction inputAction)
    {
        inputAction.performed += ctx =>
        {
            for (int i = 0; i < Binding.Count; i++)
            {
                int indexKeyboard = Binding[i].keyboardInputs.FindIndex(item => item.Name.ToLower() == ctx.control.ToString().Split('/').Last().ToLower());
                int indexGamepad = Binding[i].gamepadInputs.FindIndex(item => item.Name.ToLower() == ctx.control.ToString().Split('/').Last().ToLower());

                if (indexKeyboard >= 0)
                {
                    InputInfo currentInputInfo = Binding[i].keyboardInputs[indexKeyboard];
                    UpdateInputInfo.UpdateInfo(ref currentInputInfo, ctx);
                    Binding.ElementAt(i).keyboardInputs[indexKeyboard] = currentInputInfo;
                }

                if (indexGamepad >= 0)
                {
                    InputInfo currentInputInfo = Binding[i].gamepadInputs[indexGamepad];
                    UpdateInputInfo.UpdateInfo(ref currentInputInfo, ctx);
                    Binding.ElementAt(i).gamepadInputs[indexGamepad] = currentInputInfo;
                }
            }
        };

        inputAction.canceled += ctx =>
        {
            for (int i = 0; i < Binding.Count; i++)
            {
                int indexKeyboard = Binding[i].keyboardInputs.FindIndex(item => item.Name.ToLower() == ctx.control.ToString().Split('/').Last().ToLower());
                int indexGamepad = Binding[i].gamepadInputs.FindIndex(item => item.Name.ToLower() == ctx.control.ToString().Split('/').Last().ToLower());

                if (indexKeyboard >= 0)
                {
                    InputInfo currentInputInfo = Binding[i].keyboardInputs[indexKeyboard];
                    UpdateInputInfo.UpdateInfo(ref currentInputInfo, ctx);
                }

                if (indexGamepad >= 0)
                {
                    InputInfo currentInputInfo = Binding[i].gamepadInputs[indexGamepad];
                    UpdateInputInfo.UpdateInfo(ref currentInputInfo, ctx);
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

            for (int o = 0; o < Binding[i].gamepadInputs.Count; o++)
            {
                Binding[i].gamepadInputs[o].LateUpdate();
            }
        }
    }
    #endregion
}

public class UpdateInputInfo
{
    private static List<InputBindingCollection> Binding => InputSystem.Instance.Binding;

    public static void InitDefinedInput(InputAction inputAction, Type assignedType)
    {
        //Init value
        string assignedTitle = inputAction.ToString().Split('/').Last();
        assignedTitle = char.ToUpper(assignedTitle[0]) + assignedTitle.Substring(1);
        assignedTitle = assignedTitle.Remove(assignedTitle.Length - 1);

        Enum.TryParse(assignedTitle, out Input.GamepadKeys assignedGamepadKeys);
        Enum.TryParse(assignedTitle, out Input.KeyboardKeys assignedKeyboardKeys);

        InputInfo createdInputInfo = new InputInfo()
        {
            Name = assignedTitle,
            isFloat = (assignedType.ToString() == "System.Single") ? true : false,
            IsVector2 = (assignedType.ToString() == "System.Single") ? false : true,
            fVal = 0,
            vVal = Vector2.zero,
            inputActionPhase = InputActionPhase.Disabled,
            HardwareDevice = (InputInfo.HardwareDeviceType)Enum.Parse(typeof(InputInfo.HardwareDeviceType), inputAction.ToString().Split('/').First()),
            gamepadKeys = assignedGamepadKeys,
            keyboardKeys = assignedKeyboardKeys
        };

        for (int i = 0; i < Binding.Count; i++)
        {
            for (int o = 0; o < Binding[i].keyboardKeys.Count; o++)
            {
                if (createdInputInfo.Name == Binding[i].keyboardKeys[o].ToString())
                {
                    Binding[i].keyboardInputs.Add(createdInputInfo);
                }
            }

            for (int o = 0; o < Binding[i].gamepadKeys.Count; o++)
            {
                if (createdInputInfo.Name == Binding[i].gamepadKeys[o].ToString())
                {
                    Binding[i].gamepadInputs.Add(createdInputInfo);
                }
            }
        }
    }

    public static void UpdateInfo(ref InputInfo currentInputInfo, InputAction.CallbackContext ctx)
    {
        currentInputInfo.inputActionPhase = ctx.phase;

        if (ctx.valueType.ToString() == "System.Single")
        {
            float value = ctx.ReadValue<float>();
            currentInputInfo.isFloat = true;
            currentInputInfo.fVal = value;

            for (int i = 0; i < Binding.Count; i++)
            {
                //Single data
                if (Binding[i].inputType == InputBindingCollection.InputType.Single)
                {
                    int keyboardIndex = Binding[i].keyboardInputs.FindIndex(item => item.Name == Binding[i].keyboardKeys[0].ToString());
                    int gamepadIndex = Binding[i].gamepadInputs.FindIndex(item => item.Name == Binding[i].gamepadKeys[0].ToString());

                    Binding[i].fVal = 0;

                    if (currentInputInfo.HardwareDevice == InputInfo.HardwareDeviceType.Keyboard)
                        Binding[i].fVal = value;
                    if (currentInputInfo.HardwareDevice == InputInfo.HardwareDeviceType.Gamepad)
                        Binding[i].fVal = value;
                }

                //Single data to vector2
                if (Binding[i].inputType == InputBindingCollection.InputType.Vector2)
                {
                    if (currentInputInfo.HardwareDevice == InputInfo.HardwareDeviceType.Keyboard)
                    {
                        int right = Binding[i].keyboardInputs.FindIndex(item => item.Name == Binding[i].keyboardKeys[0].ToString());
                        int left = Binding[i].keyboardInputs.FindIndex(item => item.Name == Binding[i].keyboardKeys[1].ToString());
                        int up = Binding[i].keyboardInputs.FindIndex(item => item.Name == Binding[i].keyboardKeys[2].ToString());
                        int down = Binding[i].keyboardInputs.FindIndex(item => item.Name == Binding[i].keyboardKeys[3].ToString());

                        //currentInputInfo
                        Binding[i].vVal = Vector2.zero;

                        if (right >= 0)
                            Binding[i].vVal.x += Binding[i].keyboardInputs[right].fVal;

                        if (left >= 0)
                            Binding[i].vVal.x -= Binding[i].keyboardInputs[left].fVal;

                        if (up >= 0)
                            Binding[i].vVal.y += Binding[i].keyboardInputs[up].fVal;

                        if (down >= 0)
                            Binding[i].vVal.y -= Binding[i].keyboardInputs[down].fVal;

                        if (Binding[i].vVal != Vector2.zero)
                            Binding[i].vVal.Normalize();
                    }
                }
            }
        }

        if (ctx.valueType.ToString() == "UnityEngine.Vector2")
        {
            Vector2 value = ctx.ReadValue<Vector2>();
            currentInputInfo.IsVector2 = true;
            currentInputInfo.vVal = value;

            for (int i = 0; i < Binding.Count; i++)
            {
                int keyboardIndex = Binding[i].keyboardInputs.FindIndex(item => item.Name == Binding[i].keyboardKeys[0].ToString());
                int gamepadIndex = Binding[i].gamepadInputs.FindIndex(item => item.Name == Binding[i].gamepadKeys[0].ToString());


                //int keyboardIndex = inputInfo.IndexOf(inputInfo.Where(item => item.Name == Binding[i].keyboardKeys[0].ToString()).FirstOrDefault());
                //int gamepadIndex = inputInfo.IndexOf(inputInfo.Where(item => item.Name == Binding[i].keyboardKeys[0].ToString()).FirstOrDefault());

                Binding[i].vVal = Vector2.zero;

                if (currentInputInfo.HardwareDevice == InputInfo.HardwareDeviceType.Keyboard)
                    Binding[i].vVal = value;
                if (currentInputInfo.HardwareDevice == InputInfo.HardwareDeviceType.Gamepad)
                    Binding[i].vVal = value;
            }
        }
    }
}