using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    public float speed = 5;
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
        Vector2 movement = Input.GetVector2("Movement");
        camTrans.position += new Vector3(movement.x, 0, movement.y) * (speed * Time.deltaTime);

        if (Input.IsKeyDown("Movement"))
        {
            //Debug.Log("Movement (currently use)");
        }

        if (Input.IsKeyUp("Movement"))
        {
            //Debug.Log("Movement (currently not in use)");
        }

        /*
        if (Input.InitiatedPressed("Movement"))
        {
            //Debug.Log("Pressed Init: Movement");
        }

        if (Input.IsPressed("Movement"))
        {
            //Debug.Log("Pressed: Movement");
        }

        if (Input.IsReleased("Movement"))
        {
            //Debug.Log("Released: Movement");
        }
        */
    }
}
