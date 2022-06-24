using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class OnlineTarget : NetworkBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;
    static private OnlineTargetSpawner onlineTargetSpawner;

    private void Awake()
    {
        onlineTargetSpawner = FindObjectOfType<OnlineTargetSpawner>();

    }
    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Projectile")
        {
            onlineTargetSpawner.ChangePosition(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }


}
