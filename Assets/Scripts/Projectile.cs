using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{
    // Start is called before the first frame update

    private Rigidbody rb;
    [SerializeField] private float forcePower = 50;
    public bool hit;
 

    void Start()
    {
        hit = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!hit){
            rb.AddForce(transform.forward * forcePower, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision other) {
        Destroy(other.gameObject);
        hit = true;
    }

}
