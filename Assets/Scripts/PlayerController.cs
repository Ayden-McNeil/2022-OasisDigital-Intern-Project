using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody body;
    private float xMouse;
    private float yMouse;
    private float xRotation;
    private float yRotation;
    
    [SerializeField] private float xSensitivity = 10f;
    [SerializeField] private float ySensitivity = 10f;
    public Camera playerCameraFP;           //First Person Camera
    public Camera playerCameraTP;           //Third Person Camera
    private Camera mainCamera;
    public float sensVar;
    public int fovVar;
    public int povVar;
    private int xInput = 0;
    private int lastXInput = 0;
    private int zInput = 0;
    private int lastZInput = 0;
    public float speed = 10.0f;

    private bool isFirstPerson = false;
    private bool isThirdPerson = false;

    private Transform focalTransform;

    [SerializeField] private GameObject pointer;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        focalTransform = GameObject.Find("FocalPoint").GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;

        sensVar = sceneVarPassover.sens;
        fovVar = sceneVarPassover.fov;
        povVar = sceneVarPassover.pov;

        if(povVar == 3)
        {
            mainCamera = playerCameraTP;
            isThirdPerson = true;
        }
        else
        {
            mainCamera = playerCameraFP;
            isFirstPerson = true;

        }
        mainCamera.fieldOfView = fovVar;
        mainCamera.gameObject.SetActive(true);
        
    }

    private void Update()
    {
       DoRayCast();
       RotateCamera();
       Move();
        
    }

    void Move()
    {
        xInput = 0;
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            xInput = -lastXInput;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            xInput = -1;
            lastXInput = xInput;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            xInput = 1;
            lastXInput = xInput;
        }

        zInput = 0;
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))
        {
            zInput = -lastZInput;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            zInput = -1;
            lastZInput = zInput;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            zInput = 1;
            lastZInput = zInput;
        }
        Vector3 moveVector = (transform.forward * zInput * Time.deltaTime + transform.right * xInput * Time.deltaTime) * speed;
        moveVector.y = body.velocity.y;
        body.velocity = moveVector;
    }

    void RotateCamera()
    {
        xMouse = Input.GetAxis("Mouse X") * Time.deltaTime * xSensitivity * sensVar;
        yMouse = Input.GetAxis("Mouse Y") * Time.deltaTime * ySensitivity * sensVar;

        yRotation += xMouse;
        xRotation -= yMouse;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
        if (isFirstPerson)
        {
            mainCamera.gameObject.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        }
        if (isThirdPerson)
        {
            focalTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        }
    }

    void DoRayCast()
    {
        Vector2 centerScreenPosition = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = mainCamera.ScreenPointToRay(centerScreenPosition);
        if (Physics.Raycast(ray, out RaycastHit rayCastHit, float.MaxValue, layerMask))
        {
            pointer.transform.position = rayCastHit.point;
        }
    }
}
