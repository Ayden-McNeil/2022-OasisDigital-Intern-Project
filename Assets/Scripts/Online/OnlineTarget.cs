using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineTarget : MonoBehaviour
{
    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explosionParticle;
    static private SpawnManager spawnManagerScript;
    static private OnlineGameManager gameManagerScript;
    static public int numberOfTargetsDestroyed;

    private void Awake()
    {
        spawnManagerScript = FindObjectOfType<SpawnManager>();
        gameManagerScript = FindObjectOfType<OnlineGameManager>();
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Projectile")
        {
            spawnManagerScript.SpawnTargets();
            spawnManagerScript.RemovePostionFromList(transform.position);
            gameManagerScript.ScoreKeeper(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            numberOfTargetsDestroyed++;
            gameManagerScript.accrucaryText.text = ((int)(OnlineTarget.numberOfTargetsDestroyed / (float)gameManagerScript.numberOfTimesMouseClicked * 100)).ToString() + "%";
        }
    }


}
