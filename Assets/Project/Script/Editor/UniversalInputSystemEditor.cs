using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(UniversalInputSystem))]
public class UniversalInputSystemEditor : Editor
{
    #region Variables
    private ReorderableList reorderableList;

    private UniversalInputSystem inputSystem
    {
        get
        {
            return target as UniversalInputSystem;
        }
    }

    public enum MouseKeys_Single
    {
        None = 0,
        BackButton = 1, ForwardButton = 2, LeftButton = 3, MiddleButton = 4, RightButton = 5
    };

    public enum MouseKeys_Vector2
    {
        None = 0,
        Delta = 100, Scroll = 101, Position = 102
    };

    public enum GamepadKeys_Single
    {
        None = 0,
        ButtonEast = 1, ButtonNorth = 2, ButtonSouth = 3, ButtonWest = 4,
        DpadNorth = 5, DpadEast = 6, DpadSouth = 7, DpadWest = 8,
        LeftShoulder = 9, LeftTrigger = 10, LeftStickPress = 11,
        LeftStickNorth = 12, LeftStickEast = 13, LeftStickSouth = 14, LeftStickWest = 15,
        RightShoulder = 16, RightStickPress = 17, RightTrigger = 18,
        RightStickNorth = 19, RightStickEast = 20, RightStickSouth = 21, RightStickWest = 22,
        Select = 23, Start = 24
    }

    public enum GamepadKeys_Vector2
    {
        None = 0,
        Dpad = 100, LeftStick = 101, RightStick = 102
    }
    #endregion

    #region Endabled/Disabled
    private void OnEnable()
    {
        reorderableList = new ReorderableList(inputSystem.definedBindings, typeof(DefinedInputBindings), true, true, true, true);

        reorderableList.drawHeaderCallback += DrawHeader;
        reorderableList.drawElementCallback += DrawElement;
        reorderableList.onAddCallback += AddItem;
        reorderableList.onRemoveCallback += RemoveItem;
    }

    private void OnDisable()
    {
        reorderableList.drawHeaderCallback -= DrawHeader;
        reorderableList.drawElementCallback -= DrawElement;
        reorderableList.onAddCallback -= AddItem;
        reorderableList.onRemoveCallback -= RemoveItem;
    }
    #endregion

    #region Rendering Rules
    private void DrawHeader(Rect rect)
    {
        GUI.Label(rect, "Input Bindings");
    }

    private void DrawElement(Rect rect, int index, bool active, bool focused)
    {
        DefinedInputBindings item = inputSystem.definedBindings[index];

        EditorGUI.BeginChangeCheck();

        GUI.Label(new Rect(rect.x, rect.y, rect.width - 85, 18), item.bindingName);

        if (item.editing == false)
        {
            if (GUI.Button(new Rect(rect.width - 70, rect.y, 100, 18), "Edit Binging"))
            {
                if (inputSystem.currentBinding != null)
                    inputSystem.currentBinding.editing = false;

                inputSystem.currentBinding = item;
                item.editing = true;
            }
        }
        else if (item.editing == true)
        {
            if (GUI.Button(new Rect(rect.width - 70, rect.y, 100, 18), "Close Binging"))
            {
                inputSystem.currentBinding = null;
                item.editing = false;
            }
        }

        if (item.editing == true)
        {
            item.bindingName = EditorGUILayout.TextField("Name: ", item.bindingName);
            item.inputReturnType = (InputType)EditorGUILayout.EnumPopup("Return Type: ", item.inputReturnType);
            GUILayout.Space(EditorGUIUtility.singleLineHeight);

            item.selectedBindingDevice = (DefinedInputBindings.HardwareDeviceType)GUILayout.Toolbar((int)item.selectedBindingDevice, new string[] { "Mouse", "Keyboard", "Gamepad" });

            switch (item.selectedBindingDevice)
            {
                case DefinedInputBindings.HardwareDeviceType.Mouse:
                    RenderMouseSelection(item);
                    break;
                case DefinedInputBindings.HardwareDeviceType.Keyboard:
                    RenderKeyboardSelection(item);
                    break;
                case DefinedInputBindings.HardwareDeviceType.Gamepad:
                    RenderGamepadSelection(item);
                    break;
                default:
                    break;
            }
        }

        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(target);
        }
    }

    private void RenderKeyboardSelection(DefinedInputBindings item)
    {
        if (item.selectedBindingDevice != DefinedInputBindings.HardwareDeviceType.Keyboard)
            return;

        if (item.inputReturnType == InputType.Single)
        {
            if (item.bindingInfo.keyboardBindingInfo.keyboardFlags.Count != 1)
                item.bindingInfo.keyboardBindingInfo.keyboardFlags = new List<KeyboardBindingInfo.KeyboardKeys>(1)
                {
                    new KeyboardBindingInfo.KeyboardKeys()
                };

            ref List<KeyboardBindingInfo.KeyboardKeys> keyboardFlags = ref item.bindingInfo.keyboardBindingInfo.keyboardFlags;
            GUILayout.Space(EditorGUIUtility.singleLineHeight);
            keyboardFlags[0] = (KeyboardBindingInfo.KeyboardKeys)EditorGUILayout.EnumPopup("Keyboard Binding: ", keyboardFlags[0]);
        }

        if (item.inputReturnType == InputType.Vector2)
        {
            if (item.bindingInfo.keyboardBindingInfo.keyboardFlags.Count != 4)
                item.bindingInfo.keyboardBindingInfo.keyboardFlags = new List<KeyboardBindingInfo.KeyboardKeys>(4)
                {
                    new KeyboardBindingInfo.KeyboardKeys(),
                    new KeyboardBindingInfo.KeyboardKeys(),
                    new KeyboardBindingInfo.KeyboardKeys(),
                    new KeyboardBindingInfo.KeyboardKeys()
                };

            ref List<KeyboardBindingInfo.KeyboardKeys> keyboardFlags = ref item.bindingInfo.keyboardBindingInfo.keyboardFlags;
            Texture texture = Resources.Load<Texture>("Input System/Vector2");
            GUILayout.Space(EditorGUIUtility.singleLineHeight);

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            keyboardFlags[0] = (KeyboardBindingInfo.KeyboardKeys)EditorGUILayout.EnumPopup(keyboardFlags[0], GUILayout.Width(50));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical();
                GUILayout.Space(64 - (EditorGUIUtility.singleLineHeight / 2));
                keyboardFlags[1] = (KeyboardBindingInfo.KeyboardKeys)EditorGUILayout.EnumPopup(keyboardFlags[1], GUILayout.Width(50), GUILayout.ExpandHeight(true));
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Box(texture, GUIStyle.none, GUILayout.Width(128), GUILayout.Height(128));
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.BeginVertical();
                GUILayout.Space(64 - (EditorGUIUtility.singleLineHeight / 2));
                keyboardFlags[2] = (KeyboardBindingInfo.KeyboardKeys)EditorGUILayout.EnumPopup(keyboardFlags[2], GUILayout.Width(50));
                GUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            keyboardFlags[3] = (KeyboardBindingInfo.KeyboardKeys)EditorGUILayout.EnumPopup(keyboardFlags[3], GUILayout.Width(50));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
    }

    private void RenderMouseSelection(DefinedInputBindings item)
    {
        if (item.selectedBindingDevice != DefinedInputBindings.HardwareDeviceType.Mouse)
            return;

        if (item.bindingInfo.mouseBindingInfo.mouseKeys.Count != 1)
            item.bindingInfo.mouseBindingInfo.mouseKeys = new List<MouseBindingInfo.MouseKeys>(1)
                {
                    new MouseBindingInfo.MouseKeys()
                };
        ref List<MouseBindingInfo.MouseKeys> mouseFlags = ref item.bindingInfo.mouseBindingInfo.mouseKeys;
        GUILayout.Space(EditorGUIUtility.singleLineHeight);


        if (item.inputReturnType == InputType.Single)
            mouseFlags[0] = (MouseBindingInfo.MouseKeys)EditorGUILayout.EnumPopup("Mouse Binding: ", (MouseKeys_Single)mouseFlags[0]);

        if (item.inputReturnType == InputType.Vector2)
            mouseFlags[0] = (MouseBindingInfo.MouseKeys)EditorGUILayout.EnumPopup("Mouse Binding: ", (MouseKeys_Vector2)mouseFlags[0]);

        /*
        //inputSystem.mouseSensitivity = EditorGUILayout.FloatField("Mouse Sensitivity: ", inputSystem.mouseSensitivity);
        //inputSystem.joystickSensitivity = EditorGUILayout.FloatField("Joystick Sensitivity: ", inputSystem.joystickSensitivity);
        */
    }

    private void RenderGamepadSelection(DefinedInputBindings item)
    {
        if (item.selectedBindingDevice != DefinedInputBindings.HardwareDeviceType.Gamepad)
            return;

        if (item.bindingInfo.gamepadBindingInfo.gamepadKeys.Count != 1)
            item.bindingInfo.gamepadBindingInfo.gamepadKeys = new List<GamepadBindingInfo.GamepadKeys>(1)
                {
                    new GamepadBindingInfo.GamepadKeys()
                };
        ref List<GamepadBindingInfo.GamepadKeys> gampadFlags = ref item.bindingInfo.gamepadBindingInfo.gamepadKeys;
        GUILayout.Space(EditorGUIUtility.singleLineHeight);


        if (item.inputReturnType == InputType.Single)
            gampadFlags[0] = (GamepadBindingInfo.GamepadKeys)EditorGUILayout.EnumPopup("Gamepad Binding: ", (GamepadKeys_Single)gampadFlags[0]);

        if (item.inputReturnType == InputType.Vector2)
            gampadFlags[0] = (GamepadBindingInfo.GamepadKeys)EditorGUILayout.EnumPopup("Gamepad Binding: ", (GamepadKeys_Vector2)gampadFlags[0]);
    }

    private void AddItem(ReorderableList list)
    {
        DefinedInputBindings definedInputBindings = new DefinedInputBindings()
        {
            bindingName = "Unamed Binding"
        };
        inputSystem.definedBindings.Add(definedInputBindings);
        EditorUtility.SetDirty(target);
    }

    private void RemoveItem(ReorderableList list)
    {
        inputSystem.definedBindings.RemoveAt(list.index);
        EditorUtility.SetDirty(target);
    }
    #endregion

    #region Main
    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("General:", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Active Device: " + inputSystem.controllerType.ToString());
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Binding Setup:", EditorStyles.boldLabel);
        reorderableList.DoLayoutList();
    }
    #endregion
}
