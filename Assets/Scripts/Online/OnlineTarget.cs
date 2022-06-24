using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class OnlineTarget : NetworkBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private AudioClip hitSound;
    private AudioSource audioSource;
    static private OnlineTargetSpawner onlineTargetSpawner;


    private void Awake()
    {
        onlineTargetSpawner = FindObjectOfType<OnlineTargetSpawner>();
        audioSource = GetComponent<AudioSource>();


    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            onlineTargetSpawner.ChangePosition(gameObject);
            Destroy(Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation), 1);
            audioSource.PlayOneShot(hitSound);
            if (other.gameObject.GetComponent<OnlineProjectile>().myProjectile)
            {
                GameObject.Find("OnlineGameManager").GetComponent<OnlineGameManager>().DestroyedTarget();
            }
        }
    }
}
