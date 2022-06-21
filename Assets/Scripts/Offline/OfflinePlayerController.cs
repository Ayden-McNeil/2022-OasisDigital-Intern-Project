using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflinePlayerController : MonoBehaviour
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
    private Vector3 moveVector;

    private Transform focalTransform;

    [SerializeField] private GameObject pointer;
    [SerializeField] private OfflineGameManager gameManagerScript;
    [SerializeField] private OfflineProjectileSpawner projectileSpawner;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        focalTransform = GameObject.Find("FocalPoint").GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;

       GetPassoverValues();
    }

    private void Update()
    {
       DoRayCast();
       RotateCamera();
       Move();
       CheckShoot();
        
    }

    private void FixedUpdate()
    {
        body.velocity = moveVector;
    }

    private void CheckShoot()
    {
        if(Input.GetMouseButtonDown(0) && !gameManagerScript.isGameOver && !gameManagerScript.isGamePaused && gameManagerScript.isGameStarted)
        {
            projectileSpawner.SpawnProjectile();
        }
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
        moveVector = (transform.forward * zInput + transform.right * xInput) * speed;
        moveVector.y = body.velocity.y;
    }

    void RotateCamera()
    {
        xMouse = Input.GetAxis("Mouse X") * Time.deltaTime * xSensitivity * sensVar;
        yMouse = Input.GetAxis("Mouse Y") * Time.deltaTime * ySensitivity * sensVar;

        yRotation += xMouse;
        xRotation -= yMouse;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
        focalTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
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

    void GetPassoverValues()
    {
        sensVar = sceneVarPassover.sens;
        fovVar = sceneVarPassover.fov;
        povVar = sceneVarPassover.pov;

        if (povVar == 3)
        {
            mainCamera = playerCameraTP;
        }
        else
        {
            mainCamera = playerCameraFP;
        }
        mainCamera.fieldOfView = fovVar;
        mainCamera.gameObject.SetActive(true);
    }
}
