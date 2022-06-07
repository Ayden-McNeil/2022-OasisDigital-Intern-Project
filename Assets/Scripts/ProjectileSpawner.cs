using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;                       //Projectile Prefab
    [SerializeField] private Camera firstPersonCamera;  //First person Camera Gameobject
    [SerializeField] private Camera thirdPersonCamera;  //Third person Camera Gameobject
    [SerializeField] private Camera currentCamera;      //Selected Camera Gameobject
    [SerializeField] private float distance = 1;        //Distance infront of the camera
    static private GameManager gameManagerScript;
    static public int CameraPov;

    private void Start()
    {
        CameraPov = sceneVarPassover.pov;
        gameManagerScript = FindObjectOfType<GameManager>();
        if(CameraPov == 3){
            currentCamera = thirdPersonCamera;
        }else{
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
