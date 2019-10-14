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
        Movement();
        Looking();

        if (Input.GetKeyDown("Movement"))
        {
            //Debug.Log("Movement (currently use)");
        }

        if (Input.GetKey("Movement"))
        {
            //Debug.Log("Movement (currently not in use)");
        }
    }

    void Looking()
    {
        Vector2 looking = Input.GetVector2("Looking");
        rotationX -= looking.y * (PlayerDefinedSensitivity * Time.deltaTime);
        rotationY += looking.x * (PlayerDefinedSensitivity * Time.deltaTime);
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
