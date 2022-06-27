using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineTarget : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explosionParticle;
    static private OfflineTargetSpawner spawnManagerScript;
    static private OfflineGameManager gameManagerScript;
    static public int numberOfTargetsDestroyed;

    private void Awake()
    {
        spawnManagerScript = FindObjectOfType<OfflineTargetSpawner>();
        gameManagerScript = FindObjectOfType<OfflineGameManager>();
    }

    private void OnMouseDown()
    {
        //spawnManagerScript.SpawnTargets();
        //spawnManagerScript.RemovePostionFromList(transform.position);
        //gameManagerScript.ScoreKeeper(pointValue);
        //Destroy(gameObject);
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Projectile")
        {
            spawnManagerScript.SpawnTargets();
            spawnManagerScript.RemovePostionFromList(transform.position);
            gameManagerScript.ScoreKeeper(pointValue);
            Destroy(Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation), 1);
            numberOfTargetsDestroyed++;
            gameManagerScript.accrucaryText.text = ((int)(OfflineTarget.numberOfTargetsDestroyed / (float)gameManagerScript.numberOfTimesMouseClicked * 100)).ToString() + "%";

        }
    }


}
