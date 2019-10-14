using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputBindingCollection
{
    public string name;
    public enum InputType
    {
        Single,
        Vector2,
    }

    public InputInfo.HardwareDeviceType selectedBindingDevice = InputInfo.HardwareDeviceType.None;
    public List<Input.KeyboardKeys> keyboardKeys = new List<Input.KeyboardKeys>();
    public List<Input.MouseKeys> mouseKeys = new List<Input.MouseKeys>();
    public List<Input.GamepadKeys> gamepadKeys = new List<Input.GamepadKeys>();

    public InputType inputKeyboardType = InputType.Single;
    public InputType inputMouseType = InputType.Single;
    public InputType inputGamepadType = InputType.Single;

    public List<InputInfo> keyboardInputs = new List<InputInfo>();
    public List<InputInfo> mouseInputs = new List<InputInfo>();
    public List<InputInfo> gamepadInputs = new List<InputInfo>();
    public bool isKeyPressed = false;
    public float fVal = 0;
    public Vector2 vVal = new Vector2(0, 0);
    [HideInInspector] public bool editing = false;
}
