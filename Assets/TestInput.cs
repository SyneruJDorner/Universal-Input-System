using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5;

    [Header("Looking")]
    private float PlayerDefinedSmoothDamp = 0.03333333f;
    public float PlayerDefinedSensitivity = 30;
    private float minimumX = -89.5f, maximumX = 89.5f;
    [HideInInspector] public float rotationX = 0f, rotationY = 0f;
    [HideInInspector] public float currentRotationX, currentRotationY, rotationXVelocity, rotationYVelocity;

    [Header("Cached Info")]
    public Transform camTrans;
    public GameObject camObj;
    public Camera cam;

    public void Awake()
    {
        camTrans = Camera.main.transform;
        camObj = camTrans.gameObject;
        cam = camTrans.GetComponent<Camera>();
    }

    public void Update()
    {
        /*
        if (Input.IsCapsLockOn() == true)
        {
            Debug.Log("Caps Lock is on!");
        }

        if (Input.IsNumLockOn() == true)
        {
            Debug.Log("Num Lock is on!");
        }

        if (Input.IsScrollLockOn() == true)
        {
            Debug.Log("Scroll Lock is on!");
        }
        */

        Movement();
        Looking();

        if (Input.GetFloat("Jump") == 1)
            Debug.Log("We are trying to jump!");


        if (Input.GetKeyDown("Movement"))
        {
            Debug.Log("Movement (Pressed Key)");
        }

        if (Input.GetKey("Movement"))
        {
            Debug.Log("Movement (Holding Key)");
        }

        if (Input.GetKeyUp("Movement"))
        {
            Debug.Log("Movement (Released Key)");
        }
    }

    void Looking()
    {
        Vector2 looking = Input.GetVector2("Looking");
        rotationX -= looking.y * (PlayerDefinedSensitivity * 0.016f);
        rotationY += looking.x * (PlayerDefinedSensitivity * 0.016f);
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
        currentRotationX = Mathf.SmoothDamp(currentRotationX, rotationX, ref rotationXVelocity, PlayerDefinedSmoothDamp);
        currentRotationY = Mathf.SmoothDamp(currentRotationY, rotationY, ref rotationYVelocity, PlayerDefinedSmoothDamp);
        transform.localRotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);
    }

    void Movement()
    {
        Vector2 movement = Input.GetVector2("Movement");
        camTrans.position += Quaternion.Euler(0, camTrans.eulerAngles.y, 0) * new Vector3(movement.x, 0, movement.y) * (speed * Time.deltaTime);
    }
}
