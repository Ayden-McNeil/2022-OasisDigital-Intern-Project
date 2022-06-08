using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  // Start is called before the first frame update

  private Rigidbody rb;                            //GameComponent RigidBody
  [SerializeField] private float speed = 100;       //Strength of the shot
  [SerializeField] private float lifeTime = 1;     //How long the gameobject lasts
  public GameObject thisGameObject;
  private Vector3 spawnLocation;


  void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb.velocity = transform.forward * speed;
    Destroy(gameObject, lifeTime);
    thisGameObject.transform.localScale = new Vector3((float).1, (float).1, (float).1);
    spawnLocation = thisGameObject.transform.position;
  }

  private void Update()
  {
    if (Vector3.Distance(spawnLocation, transform.position) > 1)
    {
      thisGameObject.transform.localScale = new Vector3((float).3, (float).3, (float).3);
    }
  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "Target")
    {
      Destroy(other.gameObject);
    }
  }
}
