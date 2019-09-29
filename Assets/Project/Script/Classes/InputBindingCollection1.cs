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
    public InputType inputType = InputType.Single;
    public List<Input.KeyboardKeys> keyboardKeys = new List<Input.KeyboardKeys>();
    public List<Input.MouseKeys> mouseKeys = new List<Input.MouseKeys>();
    public List<Input.GamepadKeys> gamepadKeys = new List<Input.GamepadKeys>();

    public List<InputInfo> keyboardInputs = new List<InputInfo>();
    public List<InputInfo> mouseInputs = new List<InputInfo>();
    public List<InputInfo> gamepadInputs = new List<InputInfo>();
    public float fVal = 0;
    public Vector2 vVal = new Vector2(0, 0);
}
