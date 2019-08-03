using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TouchscreenControl
{
    private TouchscreenController touchscreenController;
    private TouchscreenController.ToushscreenActions Touchscreen_Controller;

    //public bool BackButtonPressed;

    public Vector2 Position;
    public List<RectTransform> touchPoints = new List<RectTransform>();

    /*
    public bool ForwardButtonPressed;
    public bool LeftClickPressed;
    public bool MiddleClickPressed;
    public bool RightClickPressed;
    public Vector2 Scroll;
    */

    public void Init()
    {
        touchscreenController = new TouchscreenController();
        Touchscreen_Controller = touchscreenController.Toushscreen;

        Touchscreen_Controller.Position.performed += ctx => Position = ctx.ReadValue<Vector2>();
        Touchscreen_Controller.Position.canceled += ctx => Position = Vector2.zero;

        for (int i = 0; i < 10; i++)
        {
            touchPoints.Add(GameObject.Find("Touch Point " + (i + 1)).GetComponent<RectTransform>());
            //Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
        }

        /*
        Touchscreen_Controller.BackButton.performed += ctx => BackButtonPressed = true;
        Touchscreen_Controller.BackButton.canceled += ctx => BackButtonPressed = false;

        Touchscreen_Controller.Delta.performed += ctx => Delta = ctx.ReadValue<Vector2>();
        Touchscreen_Controller.Delta.canceled += ctx => Delta = Vector2.zero;

        Touchscreen_Controller.ForwardButton.performed += ctx => ForwardButtonPressed = true;
        Touchscreen_Controller.ForwardButton.canceled += ctx => ForwardButtonPressed = false;

        Touchscreen_Controller.LeftClick.performed += ctx => LeftClickPressed = true;
        Touchscreen_Controller.LeftClick.canceled += ctx => LeftClickPressed = false;

        Touchscreen_Controller.MiddleClick.performed += ctx => MiddleClickPressed = true;
        Touchscreen_Controller.MiddleClick.canceled += ctx => MiddleClickPressed = false;

        Touchscreen_Controller.RightClick.performed += ctx => RightClickPressed = true;
        Touchscreen_Controller.RightClick.canceled += ctx => RightClickPressed = false;

        Touchscreen_Controller.Scroll.performed += ctx => Scroll = ctx.ReadValue<Vector2>();
        Touchscreen_Controller.Scroll.canceled += ctx => Scroll = Vector2.zero;
        */
    }

    public void OnEnable()
    {
        Touchscreen_Controller.Enable();
    }

    public void OnDisable()
    {
        Touchscreen_Controller.Disable();
    }

    public void ControlState(bool state)
    {
        if (state == true)
            Touchscreen_Controller.Enable();
        else if (state == false)
            Touchscreen_Controller.Disable();
    }

    public void UpdateForRemote()
    {
        HideTouches();

        if (Input.touchCount <= 0)
            return;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPosition = Input.touches[i].position;
            touchPoints[i].gameObject.SetActive(true);
            touchPoints[i].position = touchPosition;
        }
    }

    private void HideTouches()
    {
        for (int i = 9; i >= Input.touchCount; i--)
        {
            touchPoints[i].gameObject.SetActive(false);
        }
    }
}
