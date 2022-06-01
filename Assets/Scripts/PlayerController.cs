using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xMouse;
    private float yMouse;
    private float xRotation;
    private float yRotation;
    [SerializeField] private float xSensitivity = 10f;
    [SerializeField] private float ySensitivity = 10f;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        xMouse = Input.GetAxis("Mouse X") * Time.deltaTime * xSensitivity;
        yMouse = Input.GetAxis("Mouse Y") * Time.deltaTime * ySensitivity;

        xRotation -= yMouse;
        yRotation += xMouse;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
