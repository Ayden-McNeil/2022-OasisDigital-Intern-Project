using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class OnlinePlayerController : NetworkBehaviour
{
    Rigidbody body;
    private float xMouse;
    private float yMouse;
    private float xRotation;
    private float yRotation;
    [SerializeField] private float xSensitivity = 10f;
    [SerializeField] private float ySensitivity = 10f;
    private int xInput = 0;
    private int lastXInput = 0;
    private int zInput = 0;
    private int lastZInput = 0;
    public float speed = 10.0f;
    private Vector3 moveVector;

    public float sensVar;
    public int fovVar;
    public int povVar;
    
    private Camera mainCamera;
    public Camera playerCameraFP;           //First Person Camera
    public Camera playerCameraTP;           //Third Person Camera
    static private bool doesNotHaveCamera = true;

    private OnlineGameManager gameManagerScript;
    private NetworkIdentity networkIdentity;

    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject pointer;
    [SerializeField] private GameObject frontOfTheGun;
    [SerializeField] private GameObject projectile;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject targetSpawner;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        body = GetComponent<Rigidbody>();
        networkIdentity = GetComponent<NetworkIdentity>();
        gameManagerScript = FindObjectOfType<OnlineGameManager>();


        if (isLocalPlayer && doesNotHaveCamera)
        {
            GetPassoverValues();
        }
        else
        {
            playerCameraFP.gameObject.SetActive(false);
            playerCameraTP.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            DoRayCast();
            if (!gameManagerScript.isGamePaused)
            {
                RotateCamera();
                CheckShoot();
                Move();
            }
        }
    }

    private void FixedUpdate()
    {
        body.angularVelocity = new Vector3(0,0,0);
        if (isLocalPlayer)
        {
            body.velocity = moveVector;
        }
    }

    void CheckShoot()
    {
        if (Input.GetMouseButtonDown(0) && !gameManagerScript.isGameOver && !gameManagerScript.isGamePaused)
        {
            Vector3 spawnPosition = frontOfTheGun.transform.position;
            Vector3 direction = (GetRayCast() - frontOfTheGun.transform.position).normalized;
            SpawnProjectileCmd(spawnPosition, direction, networkIdentity.netId);
        }
    }

    [Command]
    void SpawnProjectileCmd(Vector3 spawnPosition, Vector3 direction, uint ID)
    {
        SpawnProjectileRpc(spawnPosition, direction, ID);
    }

    [ClientRpc]
    void SpawnProjectileRpc(Vector3 spawnPosition, Vector3 direction, uint ID)
    {
        GameObject spawnedProjectile = Instantiate(projectile, spawnPosition, Quaternion.identity);
        spawnedProjectile.GetComponent<OnlineProjectile>().myProjectile = ID == networkIdentity.netId;
        spawnedProjectile.GetComponent<Rigidbody>().velocity = direction * 50;
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
        moveVector = (transform.forward * zInput + transform.right * xInput).normalized * speed;
        moveVector.y = body.velocity.y;
    }

    void RotateCamera()
    {
        xMouse = Input.GetAxis("Mouse X") * Time.deltaTime * xSensitivity * sensVar;
        yMouse = Input.GetAxis("Mouse Y") * Time.deltaTime * ySensitivity * sensVar;

        yRotation += xMouse;
        xRotation -= yMouse;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        focalPoint.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
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

    Vector3 GetRayCast()
    {
        Vector2 centerScreenPosition = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = mainCamera.ScreenPointToRay(centerScreenPosition);
        if (Physics.Raycast(ray, out RaycastHit rayCastHit, float.MaxValue, layerMask))
        {
           return rayCastHit.point;
        }
        return new Vector3(0,0,0);
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
        doesNotHaveCamera = true;
    }
}
