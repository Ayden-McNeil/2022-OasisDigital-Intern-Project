using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class OnlinePlayerController : NetworkBehaviour
{
    Rigidbody body;
    [SerializeField] private GameObject focalPoint;
    private float xMouse;
    private float yMouse;
    private float xRotation;
    private float yRotation;
    private float xSensitivity = 10f;
    private float ySensitivity = 10f;
    private int xInput = 0;
    private int lastXInput = 0;
    private int zInput = 0;
    private int lastZInput = 0;
    private float speed = 10.0f;
    private Vector3 moveVector;
    private float myProjectileSpeed = 75f;
    [Header("Passover Variables")]
    public float sensVar;
    public int fovVar;
    public int povVar;
    
    private Camera mainCamera;
    [Header("Cameras")]
    public Camera playerCameraFP;           //First Person Camera
    public Camera playerCameraTP;           //Third Person Camera

    private OnlineGameManager gameManagerScript;
    private NetworkIdentity networkIdentity;
    [Header("Gun Scene Variables")]
    [SerializeField] private GameObject pointer;
    [SerializeField] private GameObject frontOfTheGun;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private LayerMask layerMask;

    //[Header("Username Variables")]
    //[SerializeField] private TextMeshProUGUI usernameText;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        body = GetComponent<Rigidbody>();
        networkIdentity = GetComponent<NetworkIdentity>();
        gameManagerScript = FindObjectOfType<OnlineGameManager>();

        if (isLocalPlayer)
        {
            GetPassoverValues();
            //usernameText.text = sceneVarPassover.username;
        }
        else
        {
            Destroy(GetComponent<Rigidbody>());
        }
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            DoRayCast();
            if (!gameManagerScript.isGamePaused)
            {
                UpdateMyProjectileSpeed();
                RotateCamera();
                CheckShoot();
                Move();
            }
        }
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            body.angularVelocity = new Vector3(0,0,0);
            body.velocity = new Vector3(moveVector.x, body.velocity.y, moveVector.z);
        }
    }

    private void UpdateMyProjectileSpeed()
    {
        float mouseChange = Input.GetAxis("Mouse ScrollWheel");
        if (mouseChange != 0)
        {
            myProjectileSpeed += mouseChange * 25;
            myProjectileSpeed = Mathf.Clamp(myProjectileSpeed, 5, 75);
        }
    }

    void CheckShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gunAnimator.SetTrigger("TriggerRecoil");
            Vector3 spawnPosition = frontOfTheGun.transform.position;
            SpawnProjectileCmd(spawnPosition, GetRayCast(), myProjectileSpeed, networkIdentity.netId);
        }
    }

    [Command]
    void SpawnProjectileCmd(Vector3 spawnPosition, Vector3 endPosition, float projectileSpeed, uint ID)
    {
        SpawnProjectileRpc(spawnPosition, endPosition, projectileSpeed, ID);
    }

    [ClientRpc]
    void SpawnProjectileRpc(Vector3 spawnPosition, Vector3 endPosition, float projectileSpeed, uint ID)
    {
        GameObject spawnedProjectile = Instantiate(projectile, spawnPosition, Quaternion.identity);
        spawnedProjectile.GetComponent<Rigidbody>().velocity = (endPosition - spawnPosition).normalized * projectileSpeed;
        if (isLocalPlayer)
        {
            spawnedProjectile.GetComponent<OnlineProjectile>().myProjectile = ID == networkIdentity.netId;
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
        moveVector = (transform.forward * zInput + transform.right * xInput).normalized * speed;
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
    }
}
