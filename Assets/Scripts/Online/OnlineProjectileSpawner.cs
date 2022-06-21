using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class OnlineProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;
    private float speed = 50;

    public void SpawnProjectileOnline(Vector3 spawnPosition, Vector3 direction){
        GameObject spawnedProjectile = Instantiate(projectile,spawnPosition, Quaternion.identity);
        spawnedProjectile.GetComponent<Rigidbody>().velocity = direction * speed;
        NetworkServer.Spawn(spawnedProjectile);
    }
}
