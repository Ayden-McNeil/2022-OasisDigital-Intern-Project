using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;                       //Projectile Prefab
    [SerializeField] private Camera firstPersonCamera;  //Camera Gameobject
    [SerializeField] private float distance = 5;        //Distance infront of the camera
    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) ){
            SpawnProjectile();
        }
    }

    //Gets the postion of the camera and infront of it 
    public void SpawnProjectile(){
       
        Vector3 spawnPosition = firstPersonCamera.transform.position + firstPersonCamera.transform.forward * distance;
        Instantiate(projectile, spawnPosition, firstPersonCamera.transform.rotation);
    }





}
