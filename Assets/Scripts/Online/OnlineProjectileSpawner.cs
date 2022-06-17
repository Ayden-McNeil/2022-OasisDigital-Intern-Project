using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;                       //Projectile Prefab
    [SerializeField] private Camera firstPersonCamera;  //Camera Gameobject
    [SerializeField] private Camera thirdPersonCamera;  //Camera Gameobject
    [SerializeField] private float distance = 1;        //Distance infront of the camera
    private Camera currentCamera;
    static private OnlineGameManager gameManagerScript;
    public int cameraVar;


    private void Start()
    {
        gameManagerScript = FindObjectOfType<OnlineGameManager>();
        cameraVar = sceneVarPassover.pov;
        if (cameraVar == 3){
            currentCamera = thirdPersonCamera;
        } else {
            currentCamera = firstPersonCamera;
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameManagerScript.isGameOver && !gameManagerScript.isGamePaused && gameManagerScript.isGameStarted)
        {
            SpawnProjectile();
        }
    }

    //Gets the postion of the camera and infront of it 
    public void SpawnProjectile(){
        Vector3 spawnPosition = currentCamera.transform.position + currentCamera.transform.forward * distance;
        Instantiate(projectile, spawnPosition, currentCamera.transform.rotation);
    }





}
