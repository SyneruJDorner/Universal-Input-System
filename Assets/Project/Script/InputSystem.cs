using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(1)]
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
    public List<KeyValuePair> dictionaryBinding = new List<KeyValuePair>();

    [System.Serializable]
    public class KeyValuePair
    {
        public string Key;
        public List<InputInfo> Value = new List<InputInfo>();
        public InputAction.CallbackContext ctx;
        public float fVal = 0;
        public Vector2 vVal = new Vector2(0, 0);
        public InputActionPhase phase;
        [HideInInspector] public int lastRecalculation = -1;
        public float duration = 0;
        [HideInInspector] public float currentEndTime = 0, cachedEndTime = 0;

        //Change
        public InputBindingCollection.InputType inputReturnType = InputBindingCollection.InputType.Single;
    }
    #endregion

    #region Init
    public void Awake()
    {
        inputControls = new InputControls();
        InitKeyboard();
        InitMouse();
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

    private void InitBinding(InputAction inputAction, Type assignedType, bool hasCancel = true)
    {
        InitDefinedInput(inputAction, assignedType);
        EventInit(inputAction, hasCancel);
    }

    public void InitDefinedInput(InputAction inputAction, Type assignedType)
    {
        string assignedTitle = inputAction.ToString().Split('/').Last();
        assignedTitle = char.ToUpper(assignedTitle[0]) + assignedTitle.Substring(1);
        assignedTitle = assignedTitle.Remove(assignedTitle.Length - 1);

        Enum.TryParse(assignedTitle, out Input.KeyboardKeys_Single assignedKeyboardKeys);
        Enum.TryParse(assignedTitle, out Input.MouseKeys_Single assignedMouseKeysSingle);
        Enum.TryParse(assignedTitle, out Input.MouseKeys_Vector2 assignedMouseKeysVector2);
        Enum.TryParse(assignedTitle, out Input.GamepadKeys_Single assignedGamepadKeysSingle);
        Enum.TryParse(assignedTitle, out Input.GamepadKeys_Vector2 assignedGamepadKeysVector2);

        InputInfo createdInputInfo = new InputInfo()
        {
            Name = assignedTitle,
            isFloat = (assignedType.ToString() == "System.Single") ? true : false,
            IsVector2 = (assignedType.ToString() == "System.Single") ? false : true,
            fVal = 0,
            vVal = Vector2.zero,
            HardwareDevice = (InputInfo.HardwareDeviceType)Enum.Parse(typeof(InputInfo.HardwareDeviceType), inputAction.ToString().Split('/').First()),
            keyboardKeys = assignedKeyboardKeys,
            mouseKeysSingle = assignedMouseKeysSingle,
            mouseKeysVector2 = assignedMouseKeysVector2,
            gamepadKeysSingle = assignedGamepadKeysSingle,
            gamepadKeysVector2 = assignedGamepadKeysVector2,
            duration = 0
        };

        int keyboardSingleCount = 0, MouseSingleCount = 0, MouseVector2Count = 0, gamepadSingleCount = 0, gamepadVector2Count = 0;
        for (int i = 0; i < Binding.Count; i++)
        {
            KeyValuePair result = dictionaryBinding.FirstOrDefault(x => x.Key == Binding[i].name);

            if (result == null)
            {
                keyboardSingleCount = Binding[i].keyboardKeys.Where(item => item != Input.KeyboardKeys_Single.None).Count();
                MouseSingleCount = Binding[i].mouseKeysSingle.Where(item => item != Input.MouseKeys_Single.None).Count();
                MouseVector2Count = Binding[i].mouseKeysVector2.Where(item => item != Input.MouseKeys_Vector2.None).Count();
                gamepadSingleCount = Binding[i].gamepadKeysSingle.Where(item => item != Input.GamepadKeys_Single.None).Count();
                gamepadVector2Count = Binding[i].gamepadKeysVector2.Where(item => item != Input.GamepadKeys_Vector2.None).Count();
                int totalCount = keyboardSingleCount + MouseSingleCount + MouseVector2Count + gamepadSingleCount + gamepadVector2Count;

                result = new KeyValuePair() { Key = Binding[i].name };
                result.Value = Enumerable.Range(1, totalCount).Select(x => new InputInfo()).ToList();
                dictionaryBinding.Add(result);
            }

            #region Init Keyboard Info
            for (int o = 0; o < Binding[i].keyboardKeys.Count; o++)
            {
                if (createdInputInfo.Name == Binding[i].keyboardKeys[o].ToString())
                {
                    result.inputReturnType = Binding[i].inputReturnType;

                    if (result.Value[o].Name == "")
                        result.Value[o] = createdInputInfo;
                    else
                        result.Value[result.Value.Count - 1] = createdInputInfo;
                }
            }
            #endregion

            #region Init Mouse Info
            for (int o = 0; o < Binding[i].mouseKeysSingle.Count; o++)
            {
                if (createdInputInfo.Name == Binding[i].mouseKeysSingle[o].ToString())
                {
                    result.inputReturnType = Binding[i].inputReturnType;

                    if (result.Value[keyboardSingleCount + o].Name == "")
                        result.Value[keyboardSingleCount + o] = createdInputInfo;
                    else
                        result.Value[result.Value.Count - 1] = createdInputInfo;
                }
            }

            for (int o = 0; o < Binding[i].mouseKeysVector2.Count; o++)
            {
                if (createdInputInfo.Name == Binding[i].mouseKeysVector2[o].ToString())
                {
                    result.inputReturnType = Binding[i].inputReturnType;

                    if (result.Value[keyboardSingleCount + MouseSingleCount + o].Name == "")
                        result.Value[keyboardSingleCount + MouseSingleCount + o] = createdInputInfo;
                    else
                        result.Value[result.Value.Count - 1] = createdInputInfo;
                }
            }
            #endregion

            #region Init Gampad Info
            for (int o = 0; o < Binding[i].gamepadKeysSingle.Count; o++)
            {
                if (createdInputInfo.Name == Binding[i].gamepadKeysSingle[o].ToString())
                {
                    result.inputReturnType = Binding[i].inputReturnType;

                    if (result.Value[keyboardSingleCount + MouseSingleCount + MouseVector2Count + o].Name == "")
                        result.Value[keyboardSingleCount + MouseSingleCount + MouseVector2Count + o] = createdInputInfo;
                    else
                        result.Value[result.Value.Count - 1] = createdInputInfo;
                }
            }

            for (int o = 0; o < Binding[i].gamepadKeysVector2.Count; o++)
            {
                if (createdInputInfo.Name == Binding[i].gamepadKeysVector2[o].ToString())
                {
                    result.inputReturnType = Binding[i].inputReturnType;

                    if (result.Value[keyboardSingleCount + MouseSingleCount + MouseVector2Count + gamepadSingleCount + o].Name == "")
                        result.Value[keyboardSingleCount + MouseSingleCount + MouseVector2Count + gamepadSingleCount + o] = createdInputInfo;
                    else
                        result.Value[result.Value.Count - 1] = createdInputInfo;
                }
            }
            #endregion
        }
    }

    private void EventInit(InputAction inputAction, bool hasCancel)
    {
        inputAction.started += ctx =>
        {
            for (int i = 0; i < dictionaryBinding.Count; i++)
            {
                int inputIndex = dictionaryBinding[i].Value.FindIndex(item => item.Name.ToLower() == ctx.control.ToString().Split('/').Last().ToLower());

                if (inputIndex >= 0)
                {
                    InputInfo currentInputInfo = dictionaryBinding[i].Value[inputIndex];
                    dictionaryBinding[i].phase = InputActionPhase.Started;
                    UpdateInfo(i, ref currentInputInfo, ctx);
                    dictionaryBinding[i].Value[inputIndex] = currentInputInfo;
                    dictionaryBinding[i].Value[inputIndex].ctx = ctx;
                }
            }
        };

        inputAction.performed += ctx =>
        {
            for (int i = 0; i < dictionaryBinding.Count; i++)
            {
                int inputIndex = dictionaryBinding[i].Value.FindIndex(item => item.Name.ToLower() == ctx.control.ToString().Split('/').Last().ToLower());

                if (inputIndex >= 0)
                {
                    InputInfo currentInputInfo = dictionaryBinding[i].Value[inputIndex];
                    dictionaryBinding[i].phase = InputActionPhase.Performed;
                    UpdateInfo(i, ref currentInputInfo, ctx);
                    dictionaryBinding[i].Value[inputIndex] = currentInputInfo;
                    dictionaryBinding[i].Value[inputIndex].ctx = ctx;
                }
            }
        };

        if (hasCancel == false)
            return;

        inputAction.canceled += ctx =>
        {
            for (int i = 0; i < dictionaryBinding.Count; i++)
            {
                int inputIndex = dictionaryBinding[i].Value.FindIndex(item => item.Name.ToLower() == ctx.control.ToString().Split('/').Last().ToLower());

                if (inputIndex >= 0)
                {
                    InputInfo currentInputInfo = dictionaryBinding[i].Value[inputIndex];
                    dictionaryBinding[i].phase = InputActionPhase.Canceled;
                    UpdateInfo(i, ref currentInputInfo, ctx);
                    dictionaryBinding[i].Value[inputIndex] = currentInputInfo;
                    dictionaryBinding[i].Value[inputIndex].ctx = ctx;
                }
            }
        };
    }

    public void UpdateInfo(int bindLocation, ref InputInfo currentInputInfo, InputAction.CallbackContext ctx)
    {
        currentInputInfo.ctx = ctx;

        if (ctx.valueType.ToString() == "System.Single")
        {
            float value = ctx.ReadValue<float>();
            dictionaryBinding[bindLocation].fVal = value;
            currentInputInfo.fVal = value;

            if (dictionaryBinding[bindLocation].inputReturnType == InputBindingCollection.InputType.Vector2)
            {
                dictionaryBinding[bindLocation].vVal = Vector2.zero;

                dictionaryBinding[bindLocation].vVal.y += dictionaryBinding[bindLocation].Value[0].fVal; //Up
                dictionaryBinding[bindLocation].vVal.x -= dictionaryBinding[bindLocation].Value[1].fVal; //Left
                dictionaryBinding[bindLocation].vVal.x += dictionaryBinding[bindLocation].Value[2].fVal; //Right
                dictionaryBinding[bindLocation].vVal.y -= dictionaryBinding[bindLocation].Value[3].fVal; //Down

                if (dictionaryBinding[bindLocation].vVal != Vector2.zero)
                    dictionaryBinding[bindLocation].vVal.Normalize();
            }
        }

        if (ctx.valueType.ToString() == "UnityEngine.Vector2")
        {
            Vector2 value = ctx.ReadValue<Vector2>();
            currentInputInfo.vVal = value;
            dictionaryBinding[bindLocation].vVal = value;
        }
    }
    #endregion
}