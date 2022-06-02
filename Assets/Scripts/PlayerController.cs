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
    public Camera playerCamera;
    public float sensVar;
  public int fovVar;
  sceneVarPassover scenePassoverObject;

  private void Awake()
    {
        scenePassoverObject = GameObject.Find("VarPassoverEmptyGameObject").GetComponent<sceneVarPassover>();
        Cursor.lockState = CursorLockMode.Locked;
        playerCamera.fieldOfView = fovVar;
        sensVar = scenePassoverObject.sens;
        fovVar = scenePassoverObject.fov;
        Debug.Log(fovVar);
    }

    private void Update()
    {
        xMouse = Input.GetAxis("Mouse X") * Time.deltaTime * xSensitivity * sensVar;
        yMouse = Input.GetAxis("Mouse Y") * Time.deltaTime * ySensitivity * sensVar;
        

        xRotation -= yMouse;
        yRotation += xMouse;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
