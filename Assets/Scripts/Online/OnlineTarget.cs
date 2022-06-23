using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class OnlineTarget : NetworkBehaviour
{
    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explosionParticle;
    static private OnlineTargetSpawner onlineTargetSpawner;
    static private OnlineGameManager gameManagerScript;
    static public int numberOfTargetsDestroyed;
    static private int IDCounter = 0;
    public int ID;

    private void Awake()
    {
        onlineTargetSpawner = FindObjectOfType<OnlineTargetSpawner>();
        gameManagerScript = FindObjectOfType<OnlineGameManager>();
        ID = IDCounter++;
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Projectile")
        {
            onlineTargetSpawner.ChangePosition(gameObject);
            gameManagerScript.ScoreKeeper(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            numberOfTargetsDestroyed++;
            gameManagerScript.accrucaryText.text = ((int)(OnlineTarget.numberOfTargetsDestroyed / (float)gameManagerScript.numberOfTimesMouseClicked * 100)).ToString() + "%";
        }
    }


}
