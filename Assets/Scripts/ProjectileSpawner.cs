using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;                       //Projectile Prefab
    [SerializeField] private Camera firstPersonCamera;  //Camera Gameobject
    [SerializeField] private float distance = 1;        //Distance infront of the camera
    static private GameManager gameManagerScript;

    private void Start()
    {
        gameManagerScript = FindObjectOfType<GameManager>();
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
       
        Vector3 spawnPosition = firstPersonCamera.transform.position + firstPersonCamera.transform.forward * distance;
        Instantiate(projectile, spawnPosition, firstPersonCamera.transform.rotation);
    }





}
