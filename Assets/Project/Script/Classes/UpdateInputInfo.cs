using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public static class UpdateInputInfo
{
    private static List<InputBindingCollection> Binding => InputSystem.Instance.Binding;

    public static void InitDefinedInput(InputAction inputAction, Type assignedType)
    {
        //Init value
        string assignedTitle = inputAction.ToString().Split('/').Last();
        assignedTitle = char.ToUpper(assignedTitle[0]) + assignedTitle.Substring(1);
        assignedTitle = assignedTitle.Remove(assignedTitle.Length - 1);

        Enum.TryParse(assignedTitle, out Input.KeyboardKeys assignedKeyboardKeys);
        Enum.TryParse(assignedTitle, out Input.MouseKeys assignedMouseKeys);
        Enum.TryParse(assignedTitle, out Input.GamepadKeys assignedGamepadKeys);

        InputInfo createdInputInfo = new InputInfo()
        {
            Name = assignedTitle,
            isFloat = (assignedType.ToString() == "System.Single") ? true : false,
            IsVector2 = (assignedType.ToString() == "System.Single") ? false : true,
            fVal = 0,
            vVal = Vector2.zero,
            inputActionPhase = InputActionPhase.Disabled,
            HardwareDevice = (InputInfo.HardwareDeviceType)Enum.Parse(typeof(InputInfo.HardwareDeviceType), inputAction.ToString().Split('/').First()),
            keyboardKeys = assignedKeyboardKeys,
            mouseKeys = assignedMouseKeys,
            gamepadKeys = assignedGamepadKeys
        };

        for (int i = 0; i < Binding.Count; i++)
        {
            for (int o = 0; o < Binding[i].keyboardKeys.Count; o++)
            {
                if (createdInputInfo.Name == Binding[i].keyboardKeys[o].ToString())
                    Binding[i].keyboardInputs.Add(createdInputInfo);
            }

            for (int o = 0; o < Binding[i].mouseKeys.Count; o++)
            {
                if (createdInputInfo.Name == Binding[i].mouseKeys[o].ToString())
                    Binding[i].mouseInputs.Add(createdInputInfo);
            }

            for (int o = 0; o < Binding[i].gamepadKeys.Count; o++)
            {
                if (createdInputInfo.Name == Binding[i].gamepadKeys[o].ToString())
                    Binding[i].gamepadInputs.Add(createdInputInfo);
            }
        }
    }

    public static void UpdateInfo(int bindLocation, ref InputInfo currentInputInfo, InputAction.CallbackContext ctx)
    {
        currentInputInfo.inputActionPhase = ctx.phase;

        if (ctx.valueType.ToString() == "System.Single")
        {
            float value = ctx.ReadValue<float>();
            Binding[bindLocation].fVal = value;
            currentInputInfo.fVal = value;

            if (Binding[bindLocation].inputKeyboardType == InputBindingCollection.InputType.Single)
            {
                if (Binding[bindLocation].fVal == 0 && currentInputInfo.fVal == 0 && Binding[bindLocation].isKeyPressed == true)
                    Binding[bindLocation].isKeyPressed = false;
            }

            if (Binding[bindLocation].selectedBindingDevice == InputInfo.HardwareDeviceType.Keyboard)
            {
                if (Binding[bindLocation].inputKeyboardType == InputBindingCollection.InputType.Vector2)
                {
                    Binding[bindLocation].vVal = Vector2.zero;

                    Binding[bindLocation].vVal.y += Binding[bindLocation].keyboardInputs[0].fVal; //Up
                    Binding[bindLocation].vVal.x -= Binding[bindLocation].keyboardInputs[1].fVal; //Left
                    Binding[bindLocation].vVal.x += Binding[bindLocation].keyboardInputs[2].fVal; //Right
                    Binding[bindLocation].vVal.y -= Binding[bindLocation].keyboardInputs[3].fVal; //Down

                    if (Binding[bindLocation].vVal != Vector2.zero)
                        Binding[bindLocation].vVal.Normalize();
                }
            }
        }

        if (ctx.valueType.ToString() == "UnityEngine.Vector2")
        {
            Vector2 value = ctx.ReadValue<Vector2>();
            currentInputInfo.vVal = value;
            Binding[bindLocation].vVal = value;
        }
    }
}
