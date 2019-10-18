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
    public List<Input.KeyboardKeys_Single> keyboardKeys = new List<Input.KeyboardKeys_Single>();
    public List<Input.MouseKeys_Single> mouseKeysSingle = new List<Input.MouseKeys_Single>();
    public List<Input.MouseKeys_Vector2> mouseKeysVector2 = new List<Input.MouseKeys_Vector2>();
    public List<Input.GamepadKeys_Single> gamepadKeysSingle = new List<Input.GamepadKeys_Single>();
    public List<Input.GamepadKeys_Vector2> gamepadKeysVector2 = new List<Input.GamepadKeys_Vector2>();

    public InputType inputReturnType = InputType.Single;
    [HideInInspector] public bool editing = false;
}
