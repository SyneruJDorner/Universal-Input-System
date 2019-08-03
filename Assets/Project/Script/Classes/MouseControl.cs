using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MouseControl
{
    private KeyboardMouseController mouseController;
    private KeyboardMouseController.MouseActions Mouse_Controller;

    public bool BackButtonPressed;
    public Vector2 Delta;
    public bool ForwardButtonPressed;
    public bool LeftClickPressed;
    public bool MiddleClickPressed;
    public bool RightClickPressed;
    public Vector2 Scroll;

    public void Init()
    {
        mouseController = new KeyboardMouseController();
        Mouse_Controller = mouseController.Mouse;

        Mouse_Controller.BackButton.performed += ctx => BackButtonPressed = true;
        Mouse_Controller.BackButton.canceled += ctx => BackButtonPressed = false;

        Mouse_Controller.Delta.performed += ctx => Delta = ctx.ReadValue<Vector2>();
        Mouse_Controller.Delta.canceled += ctx => Delta = Vector2.zero;

        Mouse_Controller.ForwardButton.performed += ctx => ForwardButtonPressed = true;
        Mouse_Controller.ForwardButton.canceled += ctx => ForwardButtonPressed = false;

        Mouse_Controller.LeftClick.performed += ctx => LeftClickPressed = true;
        Mouse_Controller.LeftClick.canceled += ctx => LeftClickPressed = false;

        Mouse_Controller.MiddleClick.performed += ctx => MiddleClickPressed = true;
        Mouse_Controller.MiddleClick.canceled += ctx => MiddleClickPressed = false;

        Mouse_Controller.RightClick.performed += ctx => RightClickPressed = true;
        Mouse_Controller.RightClick.canceled += ctx => RightClickPressed = false;

        Mouse_Controller.Scroll.performed += ctx => Scroll = ctx.ReadValue<Vector2>();
        Mouse_Controller.Scroll.canceled += ctx => Scroll = Vector2.zero;
    }

    public void OnEnable()
    {
        Mouse_Controller.Enable();
    }

    public void OnDisable()
    {
        Mouse_Controller.Disable();
    }

    public void ControlState(bool state)
    {
        if (state == true)
            Mouse_Controller.Enable();
        else if (state == false)
            Mouse_Controller.Disable();
    }
}
