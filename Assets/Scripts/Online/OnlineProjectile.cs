using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineProjectile : MonoBehaviour{

    [SerializeField] private float lifeTime = 5;     //How long the gameobject lasts
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private ParticleSystem explosionParticle;
    static private OnlineTargetSpawner onlineTargetSpawner;


    public bool myProjectile;

    private AudioSource audioSource;

    void Start()
    {
        onlineTargetSpawner = FindObjectOfType<OnlineTargetSpawner>();
        gameObject.GetComponent<Renderer>().material.color = RandomColor();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(shootSound);
        Destroy(gameObject, lifeTime);
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

