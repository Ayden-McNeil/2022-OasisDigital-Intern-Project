using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;                       //Projectile Prefab
    [SerializeField] private Camera firstPersonCamera;  //Camera Gameobject
    [SerializeField] private Camera thirdPersonCamera;  //Camera Gameobject
    [SerializeField] private float distance = 1;        //Distance infront of the camera
    private Camera currentCamera;
    static private GameManager gameManagerScript;
    public int cameraVar;
    public Transform trackingSpace; // reference to the tracking space
    public OVRInput.Controller controller; // the controller to instantiate the object at


  private void Start()
    {
        gameManagerScript = FindObjectOfType<GameManager>();
        cameraVar = sceneVarPassover.pov;
        if(cameraVar == 3){
            currentCamera = thirdPersonCamera;
        }else{
            currentCamera = firstPersonCamera;
        }
    }

    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.One) && !gameManagerScript.isGameOver && !gameManagerScript.isGamePaused && gameManagerScript.isGameStarted)
        {
            SpawnProjectile();
        }
    }

    //Gets the postion of the camera and infront of it 
    public void SpawnProjectile(){
      Vector3 position = trackingSpace.TransformPoint(OVRInput.GetLocalControllerPosition(controller));
      Vector3 rotation = trackingSpace.TransformDirection(OVRInput.GetLocalControllerRotation(controller).eulerAngles);
      //Vector3 spawnPosition2 = currentCamera.transform.position + currentCamera.transform.forward * distance;
      Instantiate(projectile, position, Quaternion.Euler(rotation));
    }





}
