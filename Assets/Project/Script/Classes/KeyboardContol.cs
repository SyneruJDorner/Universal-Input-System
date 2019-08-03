using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyboardContol
{
    private KeyboardMouseController keyboardController;
    private KeyboardMouseController.KeyboardActions Keyboard_Controller;

    public bool A, B, C, D, E, F, G, H, I,
                J, K, L, M, N, O, P, Q, R,
                S, T, U, V, W, X, Y, Z,
                Backquote, Backslash, Backspace, CapsLock, Comma, ContextMenu, Delete, DownArrow, End, Enter,
                Equal, Escape, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12, Home, Insert, LeftAlt,
                LeftArrow, LeftBracket, LeftCtrl, LeftMeta, LeftShift, Minus, NumLock, Numpad0, Numpad1,
                Numpad2, Numpad3, Numpad4, Numpad5, Numpad6, Numpad7, Numpad8, Numpad9, NumpadDivide,
                NumpadEnter, NumpadMinus, NumpadMultiply, NumpadPeriod, NumpadPlus, PageDown, PageUp,
                Pause, Period, PrintScreen, Quote, RightAlt, RightArrow, RightBracket, RightCtrl, RightMeta,
                RightShift, ScrollLock, Semicolon, Slash, Space, Tab, UpArrow;


    public void Init()
    {
        keyboardController = new KeyboardMouseController();
        Keyboard_Controller = keyboardController.Keyboard;

        Keyboard_Controller.A.performed += ctx => A = true;
        Keyboard_Controller.A.canceled += ctx => A = false;

        Keyboard_Controller.B.performed += ctx => B = true;
        Keyboard_Controller.B.canceled += ctx => B = false;

        Keyboard_Controller.C.performed += ctx => C = true;
        Keyboard_Controller.C.canceled += ctx => C = false;

        Keyboard_Controller.D.performed += ctx => D = true;
        Keyboard_Controller.D.canceled += ctx => D = false;

        Keyboard_Controller.E.performed += ctx => E = true;
        Keyboard_Controller.E.canceled += ctx => E = false;

        Keyboard_Controller.F.performed += ctx => F = true;
        Keyboard_Controller.F.canceled += ctx => F = false;

        Keyboard_Controller.G.performed += ctx => G = true;
        Keyboard_Controller.G.canceled += ctx => G = false;
        Keyboard_Controller.H.performed += ctx => H = true;
        Keyboard_Controller.H.canceled += ctx => H = false;

        Keyboard_Controller.I.performed += ctx => I = true;
        Keyboard_Controller.I.canceled += ctx => I = false;

        Keyboard_Controller.J.performed += ctx => J = true;
        Keyboard_Controller.J.canceled += ctx => J = false;

        Keyboard_Controller.K.performed += ctx => K = true;
        Keyboard_Controller.K.canceled += ctx => K = false;

        Keyboard_Controller.L.performed += ctx => L = true;
        Keyboard_Controller.L.canceled += ctx => L = false;

        Keyboard_Controller.M.performed += ctx => M = true;
        Keyboard_Controller.M.canceled += ctx => M = false;

        Keyboard_Controller.N.performed += ctx => N = true;
        Keyboard_Controller.N.canceled += ctx => N = false;

        Keyboard_Controller.O.performed += ctx => O = true;
        Keyboard_Controller.O.canceled += ctx => O = false;

        Keyboard_Controller.P.performed += ctx => P = true;
        Keyboard_Controller.P.canceled += ctx => P = false;

        Keyboard_Controller.Q.performed += ctx => Q = true;
        Keyboard_Controller.Q.canceled += ctx => Q = false;

        Keyboard_Controller.R.performed += ctx => R = true;
        Keyboard_Controller.R.canceled += ctx => R = false;

        Keyboard_Controller.S.performed += ctx => S = true;
        Keyboard_Controller.S.canceled += ctx => S = false;

        Keyboard_Controller.T.performed += ctx => T = true;
        Keyboard_Controller.T.canceled += ctx => T = false;

        Keyboard_Controller.U.performed += ctx => U = true;
        Keyboard_Controller.U.canceled += ctx => U = false;

        Keyboard_Controller.V.performed += ctx => V = true;
        Keyboard_Controller.V.canceled += ctx => V = false;

        Keyboard_Controller.W.performed += ctx => W = true;
        Keyboard_Controller.W.canceled += ctx => W = false;

        Keyboard_Controller.X.performed += ctx => X = true;
        Keyboard_Controller.X.canceled += ctx => X = false;

        Keyboard_Controller.Y.performed += ctx => Y = true;
        Keyboard_Controller.Y.canceled += ctx => Y = false;

        Keyboard_Controller.Z.performed += ctx => Z = true;
        Keyboard_Controller.Z.canceled += ctx => Z = false;

        Keyboard_Controller.Backquote.performed += ctx => Backquote = true;
        Keyboard_Controller.Backquote.canceled += ctx => Backquote = false;

        Keyboard_Controller.Backslash.performed += ctx => Backslash = true;
        Keyboard_Controller.Backslash.canceled += ctx => Backslash = false;

        Keyboard_Controller.Backspace.performed += ctx => Backspace = true;
        Keyboard_Controller.Backspace.canceled += ctx => Backspace = false;

        Keyboard_Controller.CapsLock.performed += ctx => CapsLock = true;
        Keyboard_Controller.CapsLock.canceled += ctx => CapsLock = false;

        Keyboard_Controller.Comma.performed += ctx => Comma = true;
        Keyboard_Controller.Comma.canceled += ctx => Comma = false;

        Keyboard_Controller.ContextMenu.performed += ctx => ContextMenu = true;
        Keyboard_Controller.ContextMenu.canceled += ctx => ContextMenu = false;

        Keyboard_Controller.Delete.performed += ctx => Delete = true;
        Keyboard_Controller.Delete.canceled += ctx => Delete = false;

        Keyboard_Controller.DownArrow.performed += ctx => DownArrow = true;
        Keyboard_Controller.DownArrow.canceled += ctx => DownArrow = false;

        Keyboard_Controller.End.performed += ctx => End = true;
        Keyboard_Controller.End.canceled += ctx => End = false;

        Keyboard_Controller.Enter.performed += ctx => Enter = true;
        Keyboard_Controller.Enter.canceled += ctx => Enter = false;

        Keyboard_Controller.Equals.performed += ctx => Equal = true;
        Keyboard_Controller.Equals.canceled += ctx => Equal = false;

        Keyboard_Controller.Escape.performed += ctx => Escape = true;
        Keyboard_Controller.Escape.canceled += ctx => Escape = false;

        Keyboard_Controller.F1.performed += ctx => F1 = true;
        Keyboard_Controller.F1.canceled += ctx => F1 = false;

        Keyboard_Controller.F2.performed += ctx => F2 = true;
        Keyboard_Controller.F2.canceled += ctx => F2 = false;

        Keyboard_Controller.F3.performed += ctx => F3 = true;
        Keyboard_Controller.F3.canceled += ctx => F3 = false;

        Keyboard_Controller.F4.performed += ctx => F4 = true;
        Keyboard_Controller.F4.canceled += ctx => F4 = false;

        Keyboard_Controller.F5.performed += ctx => F5 = true;
        Keyboard_Controller.F5.canceled += ctx => F5 = false;

        Keyboard_Controller.F6.performed += ctx => F6 = true;
        Keyboard_Controller.F6.canceled += ctx => F6 = false;

        Keyboard_Controller.F7.performed += ctx => F7 = true;
        Keyboard_Controller.F7.canceled += ctx => F7 = false;

        Keyboard_Controller.F8.performed += ctx => F8 = true;
        Keyboard_Controller.F8.canceled += ctx => F8 = false;

        Keyboard_Controller.F9.performed += ctx => F9 = true;
        Keyboard_Controller.F9.canceled += ctx => F9 = false;

        Keyboard_Controller.F10.performed += ctx => F10 = true;
        Keyboard_Controller.F10.canceled += ctx => F10 = false;

        Keyboard_Controller.F11.performed += ctx => F11 = true;
        Keyboard_Controller.F11.canceled += ctx => F11 = false;

        Keyboard_Controller.F12.performed += ctx => F12 = true;
        Keyboard_Controller.F12.canceled += ctx => F12 = false;

        Keyboard_Controller.Home.performed += ctx => Home = true;
        Keyboard_Controller.Home.canceled += ctx => Home = false;

        Keyboard_Controller.Insert.performed += ctx => Insert = true;
        Keyboard_Controller.Insert.canceled += ctx => Insert = false;

        Keyboard_Controller.LeftAlt.performed += ctx => LeftAlt = true;
        Keyboard_Controller.LeftAlt.canceled += ctx => LeftAlt = false;

        Keyboard_Controller.LeftArrow.performed += ctx => LeftArrow = true;
        Keyboard_Controller.LeftArrow.canceled += ctx => LeftArrow = false;

        Keyboard_Controller.LeftBracket.performed += ctx => LeftBracket = true;
        Keyboard_Controller.LeftBracket.canceled += ctx => LeftBracket = false;

        Keyboard_Controller.LeftCtrl.performed += ctx => LeftCtrl = true;
        Keyboard_Controller.LeftCtrl.canceled += ctx => LeftCtrl = false;

        Keyboard_Controller.LeftMeta.performed += ctx => LeftMeta = true;
        Keyboard_Controller.LeftMeta.canceled += ctx => LeftMeta = false;

        Keyboard_Controller.LeftShift.performed += ctx => LeftShift = true;
        Keyboard_Controller.LeftShift.canceled += ctx => LeftShift = false;

        Keyboard_Controller.Minus.performed += ctx => Minus = true;
        Keyboard_Controller.Minus.canceled += ctx => Minus = false;

        Keyboard_Controller.NumLock.performed += ctx => NumLock = true;
        Keyboard_Controller.NumLock.canceled += ctx => NumLock = false;

        Keyboard_Controller.Numpad0.performed += ctx => Numpad0 = true;
        Keyboard_Controller.Numpad0.canceled += ctx => Numpad0 = false;

        Keyboard_Controller.Numpad1.performed += ctx => Numpad1 = true;
        Keyboard_Controller.Numpad1.canceled += ctx => Numpad1 = false;

        Keyboard_Controller.Numpad2.performed += ctx => Numpad2 = true;
        Keyboard_Controller.Numpad2.canceled += ctx => Numpad2 = false;

        Keyboard_Controller.Numpad3.performed += ctx => Numpad3 = true;
        Keyboard_Controller.Numpad3.canceled += ctx => Numpad3 = false;

        Keyboard_Controller.Numpad4.performed += ctx => Numpad4 = true;
        Keyboard_Controller.Numpad4.canceled += ctx => Numpad4 = false;

        Keyboard_Controller.Numpad5.performed += ctx => Numpad5 = true;
        Keyboard_Controller.Numpad5.canceled += ctx => Numpad5 = false;

        Keyboard_Controller.Numpad6.performed += ctx => Numpad6 = true;
        Keyboard_Controller.Numpad6.canceled += ctx => Numpad6 = false;

        Keyboard_Controller.Numpad7.performed += ctx => Numpad7 = true;
        Keyboard_Controller.Numpad7.canceled += ctx => Numpad7 = false;

        Keyboard_Controller.Numpad8.performed += ctx => Numpad8 = true;
        Keyboard_Controller.Numpad8.canceled += ctx => Numpad8 = false;

        Keyboard_Controller.Numpad9.performed += ctx => Numpad9 = true;
        Keyboard_Controller.Numpad9.canceled += ctx => Numpad9 = false;

        Keyboard_Controller.NumpadDivide.performed += ctx => NumpadDivide = true;
        Keyboard_Controller.NumpadDivide.canceled += ctx => NumpadDivide = false;

        Keyboard_Controller.NumpadEnter.performed += ctx => NumpadEnter = true;
        Keyboard_Controller.NumpadEnter.canceled += ctx => NumpadEnter = false;

        Keyboard_Controller.NumpadMinus.performed += ctx => NumpadMinus = true;
        Keyboard_Controller.NumpadMinus.canceled += ctx => NumpadMinus = false;

        Keyboard_Controller.NumpadMultiply.performed += ctx => NumpadMultiply = true;
        Keyboard_Controller.NumpadMultiply.canceled += ctx => NumpadMultiply = false;

        Keyboard_Controller.NumpadPeriod.performed += ctx => NumpadPeriod = true;
        Keyboard_Controller.NumpadPeriod.canceled += ctx => NumpadPeriod = false;

        Keyboard_Controller.NumpadPlus.performed += ctx => NumpadPlus = true;
        Keyboard_Controller.NumpadPlus.canceled += ctx => NumpadPlus = false;

        Keyboard_Controller.PageDown.performed += ctx => PageDown = true;
        Keyboard_Controller.PageDown.canceled += ctx => PageDown = false;

        Keyboard_Controller.PageUp.performed += ctx => PageUp = true;
        Keyboard_Controller.PageUp.canceled += ctx => PageUp = false;

        Keyboard_Controller.Pause.performed += ctx => Pause = true;
        Keyboard_Controller.Pause.canceled += ctx => Pause = false;

        Keyboard_Controller.Period.performed += ctx => Period = true;
        Keyboard_Controller.Period.canceled += ctx => Period = false;

        Keyboard_Controller.PrintScreen.performed += ctx => PrintScreen = true;
        Keyboard_Controller.PrintScreen.canceled += ctx => PrintScreen = false;

        Keyboard_Controller.Quote.performed += ctx => Quote = true;
        Keyboard_Controller.Quote.canceled += ctx => Quote = false;

        Keyboard_Controller.RightAlt.performed += ctx => RightAlt = true;
        Keyboard_Controller.RightAlt.canceled += ctx => RightAlt = false;

        Keyboard_Controller.RightArrow.performed += ctx => RightArrow = true;
        Keyboard_Controller.RightArrow.canceled += ctx => RightArrow = false;

        Keyboard_Controller.RightBracket.performed += ctx => RightBracket = true;
        Keyboard_Controller.RightBracket.canceled += ctx => RightBracket = false;

        Keyboard_Controller.RightCtrl.performed += ctx => RightCtrl = true;
        Keyboard_Controller.RightCtrl.canceled += ctx => RightCtrl = false;

        Keyboard_Controller.RightMeta.performed += ctx => RightMeta = true;
        Keyboard_Controller.RightMeta.canceled += ctx => RightMeta = false;

        Keyboard_Controller.RightShift.performed += ctx => RightShift = true;
        Keyboard_Controller.RightShift.canceled += ctx => RightShift = false;

        Keyboard_Controller.ScrollLock.performed += ctx => ScrollLock = true;
        Keyboard_Controller.ScrollLock.canceled += ctx => ScrollLock = false;

        Keyboard_Controller.Semicolon.performed += ctx => Semicolon = true;
        Keyboard_Controller.Semicolon.canceled += ctx => Semicolon = false;

        Keyboard_Controller.Slash.performed += ctx => Slash = true;
        Keyboard_Controller.Slash.canceled += ctx => Slash = false;

        Keyboard_Controller.Space.performed += ctx => Space = true;
        Keyboard_Controller.Space.canceled += ctx => Space = false;

        Keyboard_Controller.Tab.performed += ctx => Tab = true;
        Keyboard_Controller.Tab.canceled += ctx => Tab = false;

        Keyboard_Controller.UpArrow.performed += ctx => UpArrow = true;
        Keyboard_Controller.UpArrow.canceled += ctx => UpArrow = false;
    }

    public void OnEnable()
    {
        Keyboard_Controller.Enable();
    }

    public void OnDisable()
    {
        Keyboard_Controller.Disable();
    }

    public void ControlState(bool state)
    {
        if (state == true)
            keyboardController.Enable();
        else if (state == false)
            keyboardController.Disable();
    }
}
