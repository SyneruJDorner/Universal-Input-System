using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

[System.Serializable]
public class TouchscreenControl
{
    private TouchscreenController touchscreenController;
    private TouchscreenController.ToushscreenActions Touchscreen_Controller;

    private readonly List<TouchState> touchCollection = new List<TouchState>(10)
    {
        new TouchState(), new TouchState(), new TouchState(), new TouchState(), new TouchState(),
        new TouchState(), new TouchState(), new TouchState(), new TouchState(), new TouchState()
    };

    public GameObject touchPointPrefab;
    private List<RectTransform> touchPoints = new List<RectTransform>();

    public void Init()
    {
        touchscreenController = new TouchscreenController();
        Touchscreen_Controller = touchscreenController.Toushscreen;

        Touchscreen_Controller.Touch0.performed += ctx => touchCollection[0] = ctx.ReadValue<TouchState>();
        Touchscreen_Controller.Touch1.performed += ctx => touchCollection[1] = ctx.ReadValue<TouchState>();
        Touchscreen_Controller.Touch2.performed += ctx => touchCollection[2] = ctx.ReadValue<TouchState>();
        Touchscreen_Controller.Touch3.performed += ctx => touchCollection[3] = ctx.ReadValue<TouchState>();
        Touchscreen_Controller.Touch4.performed += ctx => touchCollection[4] = ctx.ReadValue<TouchState>();
        Touchscreen_Controller.Touch5.performed += ctx => touchCollection[5] = ctx.ReadValue<TouchState>();
        Touchscreen_Controller.Touch6.performed += ctx => touchCollection[6] = ctx.ReadValue<TouchState>();
        Touchscreen_Controller.Touch7.performed += ctx => touchCollection[7] = ctx.ReadValue<TouchState>();
        Touchscreen_Controller.Touch8.performed += ctx => touchCollection[8] = ctx.ReadValue<TouchState>();
        Touchscreen_Controller.Touch9.performed += ctx => touchCollection[9] = ctx.ReadValue<TouchState>();

        for (int i = 0; i < 10; i++)
        {
            GameObject createdPoint = GameObject.Instantiate(touchPointPrefab, UniversalInput.Instance.canvas.transform);
            createdPoint.name += " " + (i + 1);
            touchPoints.Add(createdPoint.GetComponent<RectTransform>());
            createdPoint.SetActive(false);
        }
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
        if (Touchscreen.current != null)
        {
            for (int i = 0; i < 10; i++)
            {
                if (touchCollection[i].isInProgress)
                {
                    touchPoints[i].gameObject.SetActive(true);
                    touchPoints[i].position = touchCollection[i].position;
                }
                else
                    touchPoints[i].gameObject.SetActive(false);
            }
        }
    }
}
