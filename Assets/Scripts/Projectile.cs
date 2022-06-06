using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{
    // Start is called before the first frame update

    private Rigidbody rb;                            //GameComponent RigidBody
    [SerializeField] private float speed = 100;       //Strength of the shot
    [SerializeField] private float lifeTime = 1;     //How long the gameobject lasts


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);
        }
    }
}
