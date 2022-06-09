using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{
    // Start is called before the first frame update

    private Rigidbody rb;                            //GameComponent RigidBody
    [SerializeField] private float speed = 100;      //Strength of the shot
    [SerializeField] private float lifeTime = 1;     //How long the gameobject lasts
     
    void Start()
    {
        rb = GetComponent<Rigidbody>();             
        gameObject.GetComponent<Renderer>().material.color = RandomColor();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);
        }
    }

    private Color RandomColor(){
        int r,b,g;
        r = Random.Range(40, 255);
        b = Random.Range(40, 255);
        g = Random.Range(40, 255);
        Color projectileColor = new Color32((byte)r,(byte)b,(byte)g, 1);
        return projectileColor;
    }
}

