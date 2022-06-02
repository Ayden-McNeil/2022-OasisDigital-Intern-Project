using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;
    [SerializeField] private Camera _camera;
// Adjust how far in front of the camera the object should spawn
    [SerializeField] private float distance = 5;
    // Start is called before the first frame update
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            SpawnProjectile();
        }
    }

    public void SpawnProjectile(){
        Instantiate(projectile, _camera.transform.position + _camera.transform.forward, _camera.transform.rotation);
    }





}
