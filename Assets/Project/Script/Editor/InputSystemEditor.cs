using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(InputSystem))]
public class InputSystemEditor : Editor
{
    private ReorderableList reorderableList;
    private InputSystem inputSystem
    {
        get
        {
            return target as InputSystem;
        }
    }
    private InputBindingCollection currentBinding;

    private void OnEnable()
    {
        reorderableList = new ReorderableList(inputSystem.Binding, typeof(InputBindingCollection), true, true, true, true);

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

    private void DrawHeader(Rect rect)
    {
        GUI.Label(rect, "Input Bindings");
    }

    private void DrawElement(Rect rect, int index, bool active, bool focused)
    {
        InputBindingCollection item = inputSystem.Binding[index];

        EditorGUI.BeginChangeCheck();

        GUI.Label(new Rect(rect.x, rect.y, rect.width - 85, 18), item.name);

        if (item.editing == false)
        {
            if (GUI.Button(new Rect(rect.width - 70, rect.y, 100, 18), "Edit Binging"))
            {
                if (currentBinding != null)
                    currentBinding.editing = false;

                currentBinding = item;
                item.editing = true;
            }
        }
        else if (item.editing == true)
        {
            if (GUI.Button(new Rect(rect.width - 70, rect.y, 100, 18), "Close Binging"))
            {
                currentBinding = null;
                item.editing = false;
            }
        }

        if (item.editing == true)
        {
            item.name = EditorGUILayout.TextField("Name: ", item.name);
            item.selectedBindingDevice = (InputInfo.HardwareDeviceType)EditorGUILayout.EnumPopup("Bind Device: ", item.selectedBindingDevice);

            RenderKeyboardSelection(item);
            RenderMouseSelection(item);
            RenderGamepadSelection(item);
        }

        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(target);
        }
    }

    private void RenderKeyboardSelection(InputBindingCollection item)
    {
        if (item.selectedBindingDevice != InputInfo.HardwareDeviceType.Keyboard)
            return;

        item.inputKeyboardType = (InputBindingCollection.InputType)EditorGUILayout.EnumPopup("Input Type: ", item.inputKeyboardType);

        if (item.inputKeyboardType == InputBindingCollection.InputType.Single)
        {
            if (item.keyboardKeys.Count != 1)
                item.keyboardKeys = new List<Input.KeyboardKeys>(1) { new Input.KeyboardKeys() };

            GUILayout.Space(EditorGUIUtility.singleLineHeight);
            item.keyboardKeys[0] = (Input.KeyboardKeys)EditorGUILayout.EnumPopup("Keyboard Binding: ", item.keyboardKeys[0]);
        }

        if (item.inputKeyboardType == InputBindingCollection.InputType.Vector2)
        {
            if (item.keyboardKeys.Count != 4 || item.keyboardKeys == null)
                item.keyboardKeys = new List<Input.KeyboardKeys>(4)
                {
                    new Input.KeyboardKeys(),
                    new Input.KeyboardKeys(),
                    new Input.KeyboardKeys(),
                    new Input.KeyboardKeys()
                };

            Texture texture = Resources.Load<Texture>("Input System/Vector2");

            GUILayout.Space(EditorGUIUtility.singleLineHeight);

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            item.keyboardKeys[0] = (Input.KeyboardKeys)EditorGUILayout.EnumPopup(item.keyboardKeys[0], GUILayout.Width(50));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical();
                GUILayout.Space(64 - (EditorGUIUtility.singleLineHeight / 2));
                item.keyboardKeys[1] = (Input.KeyboardKeys)EditorGUILayout.EnumPopup(item.keyboardKeys[1], GUILayout.Width(50), GUILayout.ExpandHeight(true));
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Box(texture, GUIStyle.none, GUILayout.Width(128), GUILayout.Height(128));
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.BeginVertical();
                GUILayout.Space(64 - (EditorGUIUtility.singleLineHeight / 2));
                item.keyboardKeys[2] = (Input.KeyboardKeys)EditorGUILayout.EnumPopup(item.keyboardKeys[2], GUILayout.Width(50));
                GUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            item.keyboardKeys[3] = (Input.KeyboardKeys)EditorGUILayout.EnumPopup(item.keyboardKeys[3], GUILayout.Width(50));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
    }

    private void RenderMouseSelection(InputBindingCollection item)
    {
        if (item.selectedBindingDevice != InputInfo.HardwareDeviceType.Mouse)
            return;

        item.inputMouseType = (InputBindingCollection.InputType)EditorGUILayout.EnumPopup("Input Type: ", item.inputMouseType);

        if (item.inputMouseType == InputBindingCollection.InputType.Single)
        {
            if (item.mouseKeys.Count != 1)
                item.mouseKeys = new List<Input.MouseKeys>(1) { new Input.MouseKeys() };

            GUILayout.Space(EditorGUIUtility.singleLineHeight);
            item.mouseKeys[0] = (Input.MouseKeys)EditorGUILayout.EnumPopup("Mouse Binding: ", item.mouseKeys[0]);
        }

        if (item.inputMouseType == InputBindingCollection.InputType.Vector2)
        {
            if (item.mouseKeys.Count != 4 || item.mouseKeys == null)
                item.mouseKeys = new List<Input.MouseKeys>(4)
                {
                    new Input.MouseKeys(),
                    new Input.MouseKeys(),
                    new Input.MouseKeys(),
                    new Input.MouseKeys()
                };

            Texture texture = Resources.Load<Texture>("Input System/Vector2");

            GUILayout.Space(EditorGUIUtility.singleLineHeight);

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            item.mouseKeys[0] = (Input.MouseKeys)EditorGUILayout.EnumPopup(item.mouseKeys[0], GUILayout.Width(50));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical();
                GUILayout.Space(64 - (EditorGUIUtility.singleLineHeight / 2));
                item.mouseKeys[1] = (Input.MouseKeys)EditorGUILayout.EnumPopup(item.mouseKeys[1], GUILayout.Width(50), GUILayout.ExpandHeight(true));
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Box(texture, GUIStyle.none, GUILayout.Width(128), GUILayout.Height(128));
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.BeginVertical();
                GUILayout.Space(64 - (EditorGUIUtility.singleLineHeight / 2));
                item.mouseKeys[2] = (Input.MouseKeys)EditorGUILayout.EnumPopup(item.mouseKeys[2], GUILayout.Width(50));
                GUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            item.mouseKeys[3] = (Input.MouseKeys)EditorGUILayout.EnumPopup(item.mouseKeys[3], GUILayout.Width(50));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
    }

    private void RenderGamepadSelection(InputBindingCollection item)
    {
        if (item.selectedBindingDevice != InputInfo.HardwareDeviceType.Gamepad)
            return;

        item.inputGamepadType = (InputBindingCollection.InputType)EditorGUILayout.EnumPopup("Input Type: ", item.inputGamepadType);

        if (item.inputGamepadType == InputBindingCollection.InputType.Single)
        {
            if (item.gamepadKeys.Count != 1)
                item.gamepadKeys = new List<Input.GamepadKeys>(1) { new Input.GamepadKeys() };

            GUILayout.Space(EditorGUIUtility.singleLineHeight);
            item.gamepadKeys[0] = (Input.GamepadKeys)EditorGUILayout.EnumPopup("Gamepad Binding: ", item.gamepadKeys[0]);
        }

        if (item.inputGamepadType == InputBindingCollection.InputType.Vector2)
        {
            if (item.gamepadKeys.Count != 4 || item.gamepadKeys == null)
                item.gamepadKeys = new List<Input.GamepadKeys>(4)
                {
                    new Input.GamepadKeys(),
                    new Input.GamepadKeys(),
                    new Input.GamepadKeys(),
                    new Input.GamepadKeys()
                };

            Texture texture = Resources.Load<Texture>("Input System/Vector2");

            GUILayout.Space(EditorGUIUtility.singleLineHeight);

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            item.gamepadKeys[0] = (Input.GamepadKeys)EditorGUILayout.EnumPopup(item.gamepadKeys[0], GUILayout.Width(50));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical();
                GUILayout.Space(64 - (EditorGUIUtility.singleLineHeight / 2));
                item.gamepadKeys[1] = (Input.GamepadKeys)EditorGUILayout.EnumPopup(item.gamepadKeys[1], GUILayout.Width(50), GUILayout.ExpandHeight(true));
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Box(texture, GUIStyle.none, GUILayout.Width(128), GUILayout.Height(128));
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.BeginVertical();
                GUILayout.Space(64 - (EditorGUIUtility.singleLineHeight / 2));
                item.gamepadKeys[2] = (Input.GamepadKeys)EditorGUILayout.EnumPopup(item.gamepadKeys[2], GUILayout.Width(50));
                GUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            item.gamepadKeys[3] = (Input.GamepadKeys)EditorGUILayout.EnumPopup(item.gamepadKeys[3], GUILayout.Width(50));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
    }

    private void AddItem(ReorderableList list)
    {
        inputSystem.Binding.Add(new InputBindingCollection());
        EditorUtility.SetDirty(target);
    }

    private void RemoveItem(ReorderableList list)
    {
        inputSystem.Binding.RemoveAt(list.index);
        EditorUtility.SetDirty(target);
    }

    public override void OnInspectorGUI()
    {
        reorderableList.DoLayoutList();
    }
}
