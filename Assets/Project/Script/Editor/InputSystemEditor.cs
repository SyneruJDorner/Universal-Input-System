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
            item.inputReturnType = (InputBindingCollection.InputType)EditorGUILayout.EnumPopup("Return Type: ", item.inputReturnType);

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

        if (item.inputReturnType == InputBindingCollection.InputType.Single)
        {
            if (item.keyboardKeys.Count != 1)
                item.keyboardKeys = new List<Input.KeyboardKeys_Single>(1) { new Input.KeyboardKeys_Single() };

            GUILayout.Space(EditorGUIUtility.singleLineHeight);
            item.keyboardKeys[0] = (Input.KeyboardKeys_Single)EditorGUILayout.EnumPopup("Keyboard Binding: ", item.keyboardKeys[0]);
        }

        if (item.inputReturnType == InputBindingCollection.InputType.Vector2)
        {
            if (item.keyboardKeys.Count != 4 || item.keyboardKeys == null)
                item.keyboardKeys = new List<Input.KeyboardKeys_Single>(4)
                {
                    new Input.KeyboardKeys_Single(),
                    new Input.KeyboardKeys_Single(),
                    new Input.KeyboardKeys_Single(),
                    new Input.KeyboardKeys_Single()
                };

            Texture texture = Resources.Load<Texture>("Input System/Vector2");

            GUILayout.Space(EditorGUIUtility.singleLineHeight);

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            item.keyboardKeys[0] = (Input.KeyboardKeys_Single)EditorGUILayout.EnumPopup(item.keyboardKeys[0], GUILayout.Width(50));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical();
                GUILayout.Space(64 - (EditorGUIUtility.singleLineHeight / 2));
                item.keyboardKeys[1] = (Input.KeyboardKeys_Single)EditorGUILayout.EnumPopup(item.keyboardKeys[1], GUILayout.Width(50), GUILayout.ExpandHeight(true));
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Box(texture, GUIStyle.none, GUILayout.Width(128), GUILayout.Height(128));
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.BeginVertical();
                GUILayout.Space(64 - (EditorGUIUtility.singleLineHeight / 2));
                item.keyboardKeys[2] = (Input.KeyboardKeys_Single)EditorGUILayout.EnumPopup(item.keyboardKeys[2], GUILayout.Width(50));
                GUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            item.keyboardKeys[3] = (Input.KeyboardKeys_Single)EditorGUILayout.EnumPopup(item.keyboardKeys[3], GUILayout.Width(50));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
    }

    private void RenderMouseSelection(InputBindingCollection item)
    {
        if (item.selectedBindingDevice != InputInfo.HardwareDeviceType.Mouse)
            return;

        if (item.mouseKeysSingle.Count != 1)
            item.mouseKeysSingle = new List<Input.MouseKeys_Single>(1) { new Input.MouseKeys_Single() };

        if (item.mouseKeysVector2.Count != 1)
            item.mouseKeysVector2 = new List<Input.MouseKeys_Vector2>(1) { new Input.MouseKeys_Vector2() };

        GUILayout.Space(EditorGUIUtility.singleLineHeight);

        if (item.inputReturnType == InputBindingCollection.InputType.Single)
            item.mouseKeysSingle[0] = (Input.MouseKeys_Single)EditorGUILayout.EnumPopup("Mouse Binding (Single): ", item.mouseKeysSingle[0]);

        if (item.inputReturnType == InputBindingCollection.InputType.Vector2)
            item.mouseKeysVector2[0] = (Input.MouseKeys_Vector2)EditorGUILayout.EnumPopup("Mouse Binding (Vector2): ", item.mouseKeysVector2[0]);
    }

    private void RenderGamepadSelection(InputBindingCollection item)
    {
        if (item.selectedBindingDevice != InputInfo.HardwareDeviceType.Gamepad)
            return;

        if (item.gamepadKeysSingle.Count != 1)
            item.gamepadKeysSingle = new List<Input.GamepadKeys_Single>(1) { new Input.GamepadKeys_Single() };

        if (item.gamepadKeysVector2.Count != 1)
            item.gamepadKeysVector2 = new List<Input.GamepadKeys_Vector2>(1) { new Input.GamepadKeys_Vector2() };

        GUILayout.Space(EditorGUIUtility.singleLineHeight);

        if (item.inputReturnType == InputBindingCollection.InputType.Single)
            item.gamepadKeysSingle[0] = (Input.GamepadKeys_Single)EditorGUILayout.EnumPopup("Gamepad Binding (Single): ", item.gamepadKeysSingle[0]);

        if (item.inputReturnType == InputBindingCollection.InputType.Vector2)
            item.gamepadKeysVector2[0] = (Input.GamepadKeys_Vector2)EditorGUILayout.EnumPopup("Gamepad Binding (Vector2): ", item.gamepadKeysVector2[0]);
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
        EditorGUILayout.LabelField("Active Device: " + inputSystem.controllerType.ToString());

        reorderableList.DoLayoutList();
    }
}
