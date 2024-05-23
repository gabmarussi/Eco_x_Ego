using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAround : MonoBehaviour
{
    float rotationY = 0f;
    float rotationX = 0f;

    public float sensitivity = 15f;


    // Update is called once per frame
    void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0); 
    }
}
