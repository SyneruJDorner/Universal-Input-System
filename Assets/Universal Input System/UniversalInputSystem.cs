using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class UniversalInputSystem : MonoBehaviour
{
    #region Singleton Access
    private static UniversalInputSystem instance;//Use of a singleton here, needs to be static in order for other scripts to access it.

    public static UniversalInputSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<UniversalInputSystem>();
            }

            return instance;
        }
    }
    #endregion

    #region variables
    [HideInInspector] private InputControls inputControls;
    [HideInInspector] private InputControls.KeyboardActions keyboard_Controller;
    [HideInInspector] private InputControls.GamepadActions gamepad_Controller;
    [HideInInspector] private InputControls.MouseActions mouse_Controller;

    [Serializable]
    public class BindingDictionary : SerializableDictionary<string, DefinedInputBindings> { }
    public BindingDictionary definedBindings;

    //editor related code
    [HideInInspector] public int tab = 0;
    [HideInInspector] public DefinedInputBindings currentBinding = null;
    [HideInInspector] public bool displayMouse = false;
    [HideInInspector] public UIS_Profiles uis_Profiles = new UIS_Profiles();

    public enum ControllerType
    {
        None,
        KeyboardMouse,
        Controller
    }
    public ControllerType controllerType = ControllerType.None;

    //public HardwareInfo hardwareInfo = new HardwareInfo();
    #endregion

    #region Init Universal Input System
    public void Awake()
    {
        inputControls = new InputControls();
        InitInputActionLists();
        InitKeyboard();
        InitMouse();
        InitGamepad();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus == false)
        {
            foreach (var element in definedBindings)
            {
                var definedInputBinding = element.Value;

                definedInputBinding.fVal = 0;
                definedInputBinding.vVal = Vector2.zero;

                var keyboardBindingInfo = definedInputBinding.bindingInfo.keyboardBindingInfo;
                keyboardBindingInfo.vVal = Vector2.zero;

                for (int j = 0; j < keyboardBindingInfo.fVal.Count; j++)
                    keyboardBindingInfo.fVal[j] = 0;

                var mouseBindingInfo = definedInputBinding.bindingInfo.mouseBindingInfo;
                mouseBindingInfo.vVal = Vector2.zero;

                for (int j = 0; j < mouseBindingInfo.fVal.Count; j++)
                    mouseBindingInfo.fVal[j] = 0;

                var gamepadBindingInfo = definedInputBinding.bindingInfo.gamepadBindingInfo;
                gamepadBindingInfo.vVal = Vector2.zero;

                for (int j = 0; j < gamepadBindingInfo.fVal.Count; j++)
                    gamepadBindingInfo.fVal[j] = 0;
            }
        }
    }

    private void InitInputActionLists()
    {
        foreach (var element in definedBindings)
        {
            var definedInputBinding = element.Value;

            var keyboardFlags = definedInputBinding.bindingInfo.keyboardBindingInfo.keyboardFlags;
            keyboardFlags.RemoveAll(item => item == KeyboardBindingInfo.KeyboardKeys.None);

            var mouseFlags = definedInputBinding.bindingInfo.mouseBindingInfo.mouseKeys;
            mouseFlags.RemoveAll(item => item == MouseBindingInfo.MouseKeys.None);

            var gampadFlags = definedInputBinding.bindingInfo.gamepadBindingInfo.gamepadKeys;
            gampadFlags.RemoveAll(item => item == GamepadBindingInfo.GamepadKeys.None);
        }

        foreach (var element in definedBindings)
        {
            var definedInputBinding = element.Value;

            var keyboardFlags = definedInputBinding.bindingInfo.keyboardBindingInfo.keyboardFlags;
            definedInputBinding.bindingInfo.keyboardBindingInfo.inputActions = CreateList<InputAction>(keyboardFlags.Count);
            definedInputBinding.bindingInfo.keyboardBindingInfo.ctx = CreateList<InputAction.CallbackContext>(keyboardFlags.Count);
            definedInputBinding.bindingInfo.keyboardBindingInfo.fVal = CreateList<float>(keyboardFlags.Count);

            var mouseFlags = definedInputBinding.bindingInfo.mouseBindingInfo.mouseKeys;
            definedInputBinding.bindingInfo.mouseBindingInfo.inputActions = CreateList<InputAction>(mouseFlags.Count);
            definedInputBinding.bindingInfo.mouseBindingInfo.ctx = CreateList<InputAction.CallbackContext>(mouseFlags.Count);
            definedInputBinding.bindingInfo.mouseBindingInfo.fVal = CreateList<float>(mouseFlags.Count);

            var gampadFlags = definedInputBinding.bindingInfo.gamepadBindingInfo.gamepadKeys;
            definedInputBinding.bindingInfo.gamepadBindingInfo.inputActions = CreateList<InputAction>(gampadFlags.Count);
            definedInputBinding.bindingInfo.gamepadBindingInfo.ctx = CreateList<InputAction.CallbackContext>(gampadFlags.Count);
            definedInputBinding.bindingInfo.gamepadBindingInfo.fVal = CreateList<float>(gampadFlags.Count);
        }
    }

    private static List<T> CreateList<T>(int capacity)
    {
        return Enumerable.Repeat(default(T), capacity).ToList();
    }

    private void InitKeyboard()
    {
        keyboard_Controller = inputControls.Keyboard;
        inputControls.Keyboard.Enable();

        InitBinding(keyboard_Controller.A);
        InitBinding(keyboard_Controller.B);
        InitBinding(keyboard_Controller.C);
        InitBinding(keyboard_Controller.D);
        InitBinding(keyboard_Controller.E);
        InitBinding(keyboard_Controller.F);
        InitBinding(keyboard_Controller.G);
        InitBinding(keyboard_Controller.H);
        InitBinding(keyboard_Controller.I);
        InitBinding(keyboard_Controller.J);
        InitBinding(keyboard_Controller.K);
        InitBinding(keyboard_Controller.L);
        InitBinding(keyboard_Controller.M);
        InitBinding(keyboard_Controller.N);
        InitBinding(keyboard_Controller.O);
        InitBinding(keyboard_Controller.P);
        InitBinding(keyboard_Controller.Q);
        InitBinding(keyboard_Controller.R);
        InitBinding(keyboard_Controller.S);
        InitBinding(keyboard_Controller.T);
        InitBinding(keyboard_Controller.U);
        InitBinding(keyboard_Controller.V);
        InitBinding(keyboard_Controller.W);
        InitBinding(keyboard_Controller.X);
        InitBinding(keyboard_Controller.Y);
        InitBinding(keyboard_Controller.Z);

        InitBinding(keyboard_Controller.Backquote);
        InitBinding(keyboard_Controller.Backslash);
        InitBinding(keyboard_Controller.Backspace);
        InitBinding(keyboard_Controller.CapsLock);
        InitBinding(keyboard_Controller.Comma);
        InitBinding(keyboard_Controller.ContextMenu);
        InitBinding(keyboard_Controller.Delete);
        InitBinding(keyboard_Controller.DownArrow);
        InitBinding(keyboard_Controller.End);
        InitBinding(keyboard_Controller.Enter);
        InitBinding(keyboard_Controller.Equal);
        InitBinding(keyboard_Controller.Escape);

        InitBinding(keyboard_Controller.F1);
        InitBinding(keyboard_Controller.F2);
        InitBinding(keyboard_Controller.F3);
        InitBinding(keyboard_Controller.F4);
        InitBinding(keyboard_Controller.F5);
        InitBinding(keyboard_Controller.F6);
        InitBinding(keyboard_Controller.F7);
        InitBinding(keyboard_Controller.F8);
        InitBinding(keyboard_Controller.F9);
        InitBinding(keyboard_Controller.F10);
        InitBinding(keyboard_Controller.F11);
        InitBinding(keyboard_Controller.F12);

        InitBinding(keyboard_Controller.Home);
        InitBinding(keyboard_Controller.Insert);
        InitBinding(keyboard_Controller.LeftAlt);
        InitBinding(keyboard_Controller.LeftArrow);
        InitBinding(keyboard_Controller.LeftBracket);
        InitBinding(keyboard_Controller.LeftCtrl);
        InitBinding(keyboard_Controller.LeftMeta);
        InitBinding(keyboard_Controller.LeftShift);
        InitBinding(keyboard_Controller.Minus);

        InitBinding(keyboard_Controller.NumLock);
        InitBinding(keyboard_Controller.Numpad0);
        InitBinding(keyboard_Controller.Numpad1);
        InitBinding(keyboard_Controller.Numpad2);
        InitBinding(keyboard_Controller.Numpad3);
        InitBinding(keyboard_Controller.Numpad4);
        InitBinding(keyboard_Controller.Numpad5);
        InitBinding(keyboard_Controller.Numpad6);
        InitBinding(keyboard_Controller.Numpad7);
        InitBinding(keyboard_Controller.Numpad8);
        InitBinding(keyboard_Controller.Numpad9);
        InitBinding(keyboard_Controller.NumpadDivide);
        InitBinding(keyboard_Controller.NumpadEnter);
        InitBinding(keyboard_Controller.NumpadMinus);
        InitBinding(keyboard_Controller.NumpadMultiply);
        InitBinding(keyboard_Controller.NumpadPeriod);
        InitBinding(keyboard_Controller.NumpadPlus);

        InitBinding(keyboard_Controller.PageDown);
        InitBinding(keyboard_Controller.PageUp);
        InitBinding(keyboard_Controller.Pause);
        InitBinding(keyboard_Controller.Period);
        InitBinding(keyboard_Controller.PrintScreen);
        InitBinding(keyboard_Controller.Quote);
        InitBinding(keyboard_Controller.RightAlt);
        InitBinding(keyboard_Controller.RightArrow);
        InitBinding(keyboard_Controller.RightBracket);
        InitBinding(keyboard_Controller.RightCtrl);
        InitBinding(keyboard_Controller.RightMeta);
        InitBinding(keyboard_Controller.RightShift);
        InitBinding(keyboard_Controller.ScrollLock);
        InitBinding(keyboard_Controller.Semicolon);
        InitBinding(keyboard_Controller.Slash);
        InitBinding(keyboard_Controller.Space);
        InitBinding(keyboard_Controller.Tab);
        InitBinding(keyboard_Controller.UpArrow);
    }

    private void InitMouse()
    {
        mouse_Controller = inputControls.Mouse;
        inputControls.Mouse.Enable();

        InitBinding(mouse_Controller.BackButton);
        InitBinding(mouse_Controller.ForwardButton);
        InitBinding(mouse_Controller.LeftClick);
        InitBinding(mouse_Controller.MiddleClick);
        InitBinding(mouse_Controller.RightClick);
        InitBinding(mouse_Controller.Delta);
        InitBinding(mouse_Controller.Scroll);
        InitBinding(mouse_Controller.Position, false);
    }

    private void InitGamepad()
    {
        gamepad_Controller = inputControls.Gamepad;
        inputControls.Gamepad.Enable();

        InitBinding(gamepad_Controller.ButtonEast);
        InitBinding(gamepad_Controller.ButtonNorth);
        InitBinding(gamepad_Controller.ButtonSouth);
        InitBinding(gamepad_Controller.ButtonWest);
        InitBinding(gamepad_Controller.Dpad);
        InitBinding(gamepad_Controller.LeftShoulder);
        InitBinding(gamepad_Controller.LeftStick);
        InitBinding(gamepad_Controller.LeftStickPress);
        InitBinding(gamepad_Controller.LeftTrigger);
        InitBinding(gamepad_Controller.RightShoulder);
        InitBinding(gamepad_Controller.RightStick);
        InitBinding(gamepad_Controller.RightStickPress);
        InitBinding(gamepad_Controller.RightTrigger);
        InitBinding(gamepad_Controller.Select);
        InitBinding(gamepad_Controller.Start);
    }

    private void InitBinding(InputAction inputAction, bool hasCancel = true)
    {
        InitDefinedInput(inputAction);
        EventInit(inputAction, hasCancel);
    }

    public void InitDefinedInput(InputAction inputAction)
    {
        #region Setup Input Action Lists in bindings
        string inputActionName = inputAction.name.Replace(" ", "");

        foreach (var element in definedBindings)
        {
            var definedInputBinding = element.Value;

            #region init Keyboard inputs
            var keyboardFlags = definedInputBinding.bindingInfo.keyboardBindingInfo.keyboardFlags;
            for (int j = 0; j < keyboardFlags.Count; j++)
            {
                //Remove all elements that do not have eum keys set up
                if (keyboardFlags[j] == KeyboardBindingInfo.KeyboardKeys.None)
                {
                    definedInputBinding.bindingInfo.keyboardBindingInfo.inputActions.RemoveAt(0);
                    definedInputBinding.bindingInfo.keyboardBindingInfo.ctx.RemoveAt(0);
                    continue;
                }

                int diff = String.Compare(inputActionName, keyboardFlags[j].ToString().Replace(" ", ""), StringComparison.OrdinalIgnoreCase);
                if (diff == 0)
                {
                    definedInputBinding.bindingInfo.keyboardBindingInfo.inputActions[j] = inputAction;
                    definedInputBinding.lookupBindings.Add(inputActionName);
                }
            }
            #endregion

            #region init Mouse inputs
            var mouseFlags = definedInputBinding.bindingInfo.mouseBindingInfo.mouseKeys;
            for (int j = 0; j < mouseFlags.Count; j++)
            {
                //Remove all elements that do not have eum keys set up
                if (mouseFlags[j] == MouseBindingInfo.MouseKeys.None &&
                    definedInputBinding.bindingInfo.mouseBindingInfo.inputActions.Count == 0)
                {
                    definedInputBinding.bindingInfo.mouseBindingInfo.inputActions.RemoveAt(0);
                    definedInputBinding.bindingInfo.mouseBindingInfo.ctx.RemoveAt(0);
                    continue;
                }

                int diff = String.Compare(inputActionName, mouseFlags[j].ToString().Replace(" ", ""), StringComparison.OrdinalIgnoreCase);
                if (diff == 0)
                {
                    definedInputBinding.bindingInfo.mouseBindingInfo.inputActions[j] = inputAction;
                    definedInputBinding.lookupBindings.Add(inputActionName);
                }
            }
            #endregion

            #region init Gamepad inputs
            var gampadFlags = definedInputBinding.bindingInfo.gamepadBindingInfo.gamepadKeys;
            for (int j = 0; j < gampadFlags.Count; j++)
            {
                //Remove all elements that do not have eum keys set up
                if (gampadFlags[j] == GamepadBindingInfo.GamepadKeys.None &&
                    definedInputBinding.bindingInfo.gamepadBindingInfo.inputActions.Count == 0)
                {
                    definedInputBinding.bindingInfo.gamepadBindingInfo.inputActions.RemoveAt(0);
                    definedInputBinding.bindingInfo.gamepadBindingInfo.ctx.RemoveAt(0);
                    continue;
                }

                int diff = String.Compare(inputActionName, gampadFlags[j].ToString().Replace(" ", ""), StringComparison.OrdinalIgnoreCase);
                if (diff == 0)
                {
                    definedInputBinding.bindingInfo.gamepadBindingInfo.inputActions[j] = inputAction;
                    definedInputBinding.lookupBindings.Add(inputActionName);
                }
            }
            #endregion
        }
        #endregion
    }
    #endregion

    #region Event Handling (Update)
    public void DetermineHardwareControllers()
    {
        if (Keyboard.current != null && Mouse.current != null)
            if ((Keyboard.current.CheckStateIsAtDefault() == false || Mouse.current.wasUpdatedThisFrame == true) && controllerType != ControllerType.KeyboardMouse)
                controllerType = ControllerType.KeyboardMouse;

        if (Gamepad.current != null)
            if (Gamepad.current.CheckStateIsAtDefault() == false && controllerType != ControllerType.Controller)
                controllerType = ControllerType.Controller;

        Cursor.lockState = (CursorLockMode)((Convert.ToInt32(Cursor.visible = displayMouse) == 1) ? 0 : 1);
    }

    private void EventInit(InputAction inputAction, bool hasCancel)
    {
        inputAction.started += ctx =>   { UpdateInputInfo(inputAction, ctx); };
        inputAction.performed += ctx => { UpdateInputInfo(inputAction, ctx); };
        if (hasCancel == false)         return;
        inputAction.canceled += ctx =>  { UpdateInputInfo(inputAction, ctx); };
    }

    public void UpdateInputInfo(InputAction inputAction, InputAction.CallbackContext ctx)
    {
        string inputActionName = inputAction.name.Replace(" ", "");

        DetermineHardwareControllers();

        foreach (var element in definedBindings)
        {
            var definedInputBinding = element.Value;

            KeyboardBindingInfo keyboardBindingInfo = definedInputBinding.bindingInfo.keyboardBindingInfo;
            MouseBindingInfo mouseBindingInfo = definedInputBinding.bindingInfo.mouseBindingInfo;
            GamepadBindingInfo gamepadBindingInfo = definedInputBinding.bindingInfo.gamepadBindingInfo;

            if (definedInputBinding.lookupBindings.Contains(inputActionName) == true)
            {
                int inputIndex = -1;
                UniversalBindingInfo universalBindingInfo = null;

                if (controllerType == ControllerType.KeyboardMouse && keyboardBindingInfo.inputActions.Count > 0)
                {
                    inputIndex = keyboardBindingInfo.inputActions.FindIndex(item => item.name.Replace(" ", "") == inputActionName);

                    if (inputIndex >= 0)
                        universalBindingInfo = definedInputBinding.bindingInfo.keyboardBindingInfo;
                }
                else if (controllerType == ControllerType.KeyboardMouse && mouseBindingInfo.inputActions.Count > 0)
                {
                    inputIndex = mouseBindingInfo.inputActions.FindIndex(item => item.name.Replace(" ", "") == inputActionName);

                    if (inputIndex >= 0)
                        universalBindingInfo = definedInputBinding.bindingInfo.mouseBindingInfo;
                }
                else if (controllerType == ControllerType.Controller && gamepadBindingInfo.inputActions.Count > 0)
                {
                    inputIndex = gamepadBindingInfo.inputActions.FindIndex(item => item.name.Replace(" ", "") == inputActionName);

                    if (inputIndex >= 0)
                        universalBindingInfo = definedInputBinding.bindingInfo.gamepadBindingInfo;
                }

                if (inputIndex >= 0 && universalBindingInfo != null)
                    UpdateBindingValues(element.Key, inputIndex, ref universalBindingInfo, ctx);
            }
        }
    }

    public void UpdateBindingValues(string key, int inputIndex, ref UniversalBindingInfo currentInputInfo, InputAction.CallbackContext ctx)
    {
        currentInputInfo.ctx[inputIndex] = ctx;

        if (ctx.valueType.ToString() == "System.Single")
        {
            float value = ctx.ReadValue<float>();
            currentInputInfo.fVal[inputIndex] = value;
            definedBindings[key].fVal = value;

            if (definedBindings[key].inputReturnType == InputType.Vector2 &&
                currentInputInfo.ctx.Count == 4)
            {

                definedBindings[key].vVal = Vector2.zero;

                definedBindings[key].vVal.y += currentInputInfo.fVal[0]; //Up
                definedBindings[key].vVal.x -= currentInputInfo.fVal[1]; //Left
                definedBindings[key].vVal.x += currentInputInfo.fVal[2]; //Right
                definedBindings[key].vVal.y -= currentInputInfo.fVal[3]; //Down

                if (definedBindings[key].vVal != Vector2.zero)
                    definedBindings[key].vVal.Normalize();
            }
        }

        if (ctx.valueType.ToString() == "UnityEngine.Vector2")
        {
            Vector2 value = ctx.ReadValue<Vector2>();
            ApplySensitivities(inputIndex, ref value, ref currentInputInfo);
            currentInputInfo.vVal = value;
            definedBindings[key].vVal = value;
        }
    }

    private void ApplySensitivities(int inputIndex, ref Vector2 value, ref UniversalBindingInfo currentInputInfo)
    {
        string inputActionName = currentInputInfo.inputActions[inputIndex].name.Replace(" ", "");

        if (currentInputInfo is MouseBindingInfo mouseBindingInfo)
        {
            Enum.TryParse(inputActionName, out MouseBindingInfo.MouseKeys mouseKey);

            if (mouseKey == MouseBindingInfo.MouseKeys.Delta)
                value *= mouseBindingInfo.mouseSensitivity;
        }
        else if (currentInputInfo is GamepadBindingInfo gamepadBindingInfo)
        {
            Enum.TryParse(inputActionName, out GamepadBindingInfo.GamepadKeys gamepadKey);

            if (gamepadKey == GamepadBindingInfo.GamepadKeys.RightStick)
                value *= gamepadBindingInfo.rightJoystickSensitivity;
            if (gamepadKey == GamepadBindingInfo.GamepadKeys.LeftStick)
                value *= gamepadBindingInfo.leftJoystickSensitivity;
        }
    }
    #endregion
}
