using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;                       //Projectile Prefab
    [SerializeField] private GameObject frontOfTheGun;
    [SerializeField] private GameObject pointer;
    private float speed = 100;


    public void SpawnProjectile(){
        GameObject spawnProjectile = Instantiate(projectile, frontOfTheGun.transform.position, Quaternion.identity);
        spawnProjectile.GetComponent<Rigidbody>().velocity = (pointer.transform.position - frontOfTheGun.transform.position).normalized * speed;
    }


  public GameObject hand;
  public float offsetAmount = (float)-.5;

  private void Start()
    {
      hand = GameObject.Find("mixamorig:RightHand");
    }
  private void Update()
    {
      Vector3 offset = hand.transform.position;
      //offset.z += (float)-.5;
      this.transform.position = offset;
    }
  }
