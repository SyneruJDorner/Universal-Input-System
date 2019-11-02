using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Numerics;

class EnumFlagsFieldExample : EditorWindow
{
    /*
    [System.Flags]
    public enum KeyboardKeys : long
    {
        None = 0,
        A = 1 << 0, B = 1 << 1, C = 1 << 2, D = 1 << 3, E = 1 << 4, F = 1 << 5, G = 1 << 6,
        H = 1 << 7, I = 1 << 8, J = 1 << 9, K = 1 << 10, L = 1 << 11, M = 1 << 12, N = 1 << 13,
        O = 1 << 14, P = 1 << 15, Q = 1 << 16, R = 1 << 17, S = 1 << 18, T = 1 << 19, U = 1 << 20,
        V = 1 << 21, W = 1 << 22, X = 1 << 23, Y = 1 << 24, Z = 1 << 25,

        Backquote = 1 << 26, Backslash = 1 << 27, Backspace = 1 << 28, CapsLock = 1 << 29, Comma = 1 << 30, ContextMenu = 1 << 31,
        Delete = 1 << 32, DownArrow = 1 << 33, End = 1 << 34, Enter = 1 << 35, Equal = 1 << 36, Escape = 1 << 37,

        F1 = 1 << 38, F2 = 1 << 39, F3 = 1 << 40, F4 = 1 << 41, F5 = 1 << 42, F6 = 1 << 43,
        F7 = 1 << 44, F8 = 1 << 45, F9 = 1 << 46, F10 = 1 << 47, F11 = 1 << 48, F12 = 1 << 49,

        Home = 1 << 50, Insert = 1 << 51, LeftAlt = 1 << 52, LeftArrow = 1 << 53, LeftBracket = 1 << 54,
        LeftCtrl = 1 << 55, LeftMeta = 1 << 56, LeftShift = 1 << 57, Minus = 1 << 58,

        NumLock = 1 << 59, Numpad0 = 1 << 60, Numpad1 = 1 << 61, Numpad2 = 1 << 62, Numpad3 = 1 << 63, Numpad4 = 1 << 64, Numpad5 = 1 << 65,
        Numpad6 = 1 << 66, Numpad7 = 1 << 67, Numpad8 = 1 << 68, Numpad9 = 1 << 69, NumpadDivide = 1 << 70, NumpadEnter = 1 << 71, NumpadMinus = 1 << 72,
        NumpadMultiply = 1 << 73, NumpadPeriod = 1 << 74, NumpadPlus = 1 << 75,

        PageDown = 1 << 76, PageUp = 1 << 77, Pause = 1 << 78, Period = 1 << 79, PrintScreen = 1 << 80, Quote = 1 << 81, RightAlt = 1 << 82,
        RightArrow = 1 << 83, RightBracket = 1 << 84, RightCtrl = 1 << 85, RightMeta = 1 << 86, RightShift = 1 << 87,
        ScrollLock = 1 << 88, Semicolon = 1 << 89, Slash = 1 << 90, Space = 1 << 91, Tab = 1 << 92, UpArrow = 1 << 93
    };

    //[NonSerialized] public KeyboardKeys KeyboardKey = KeyboardKeys.None;
    */

    int tagFlagMask;
    string[] displayTags = new string[]
    {
        "None", "A", "B", "C", "D", "E", "F", "G", "H", "I",
        "J", "K", "L", "M", "N", "O",  "P", "Q", "R", "S",
        "T", "U", "V", "W", "X", "Y", "Z",


        "Backquote", "Backslash", "Backspace", "CapsLock", "Comma", "ContextMenu", "Delete",
        /*
        Backquote = 1 << 26,
        Backslash = 1 << 27,
        Backspace = 1 << 28,
        CapsLock = 1 << 29,
        Comma = 1 << 30,
        ContextMenu = 1 << 31,
        Delete = 1 << 32,
        DownArrow = 1 << 33,
        End = 1 << 34,
        Enter = 1 << 35,
        Equal = 1 << 36,
        Escape = 1 << 37,

        F1 = 1 << 38,
        F2 = 1 << 39,
        F3 = 1 << 40,
        F4 = 1 << 41,
        F5 = 1 << 42,
        F6 = 1 << 43,
        F7 = 1 << 44,
        F8 = 1 << 45,
        F9 = 1 << 46,
        F10 = 1 << 47,
        F11 = 1 << 48,
        F12 = 1 << 49,

        Home = 1 << 50,
        Insert = 1 << 51,
        LeftAlt = 1 << 52,
        LeftArrow = 1 << 53,
        LeftBracket = 1 << 54,
        LeftCtrl = 1 << 55,
        LeftMeta = 1 << 56,
        LeftShift = 1 << 57,
        Minus = 1 << 58,

        NumLock = 1 << 59,
        Numpad0 = 1 << 60,
        Numpad1 = 1 << 61,
        Numpad2 = 1 << 62,
        Numpad3 = 1 << 63,
        Numpad4 = 1 << 64,
        Numpad5 = 1 << 65,
        Numpad6 = 1 << 66,
        Numpad7 = 1 << 67,
        Numpad8 = 1 << 68,
        Numpad9 = 1 << 69,
        NumpadDivide = 1 << 70,
        NumpadEnter = 1 << 71,
        NumpadMinus = 1 << 72,
        NumpadMultiply = 1 << 73,
        NumpadPeriod = 1 << 74,
        NumpadPlus = 1 << 75,

        PageDown = 1 << 76,
        PageUp = 1 << 77,
        Pause = 1 << 78,
        Period = 1 << 79,
        PrintScreen = 1 << 80,
        Quote = 1 << 81,
        RightAlt = 1 << 82,
        RightArrow = 1 << 83,
        RightBracket = 1 << 84,
        RightCtrl = 1 << 85,
        RightMeta = 1 << 86,
        RightShift = 1 << 87,
        ScrollLock = 1 << 88,
        Semicolon = 1 << 89,
        Slash = 1 << 90,
        Space = 1 << 91,
        Tab = 1 << 92,
        UpArrow = 1 << 93
        */
    };

    [MenuItem("Examples/EnumFlagsField Example")]
    static void OpenWindow()
    {
        GetWindow<EnumFlagsFieldExample>().Show();
    }

    void OnGUI()
    {
        tagFlagMask = EditorGUILayout.MaskField("MyLabel", tagFlagMask, displayTags);
        //KeyboardKey = (KeyboardKeys)EditorGUILayout.EnumFlagsField(KeyboardKey);
    }




    /*
    enum ExampleFlagsEnum
    {
        None = 0, // Custom name for "Nothing" option
        A = 1 << 0,
        B = 1 << 1,
        AB = A | B, // Combination of two flags
        C = 1 << 2,
        All = ~0, // Custom name for "Everything" option
    }

    ExampleFlagsEnum m_Flags;

    [MenuItem("Examples/EnumFlagsField Example")]
    static void OpenWindow()
    {
        GetWindow<EnumFlagsFieldExample>().Show();
    }

    void OnGUI()
    {
        m_Flags = (ExampleFlagsEnum)EditorGUILayout.EnumFlagsField(m_Flags);
    }
    */
}
