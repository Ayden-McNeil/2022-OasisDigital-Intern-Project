using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{
    // Start is called before the first frame update

    private Rigidbody rb;                            //GameComponent RigidBody
    [SerializeField] private float forcePower = 50;  //Strength of the shot
    [SerializeField] private float lifeTime = 1;     //How long the gameobject lasts
    public bool hit;
 

    void Start()
    {
        hit = false;
        rb = GetComponent<Rigidbody>();
        DestroyObjectDelayed();
    }

    void FixedUpdate()
    {
        if(!hit)
        {
            rb.AddForce(transform.forward * forcePower, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);
        }
        hit = true;
    }

    // Kills the game object in a certin amount seconds after loading the object
    void DestroyObjectDelayed()
    {
        Destroy(gameObject, lifeTime);
    }

}
