using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xMouse;
    private float yMouse;
    private float xRotation;
    private float yRotation;
    float sensVar = mouseSensControl.sensVar;
    public Camera camera;
    //[SerializeField] private float xSensitivity = 10f;
   //[SerializeField] private float ySensitivity = 10f;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camera.fieldOfView = FOVController.FOVVar;
    }

    private void Update()
    {
        xMouse = Input.GetAxis("Mouse X") * Time.deltaTime * sensVar;
        yMouse = Input.GetAxis("Mouse Y") * Time.deltaTime * sensVar;
        xRotation -= yMouse;
        yRotation += xMouse;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
 