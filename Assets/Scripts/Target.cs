using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private int pointValue;
    static private SpawnManager spawnManagerScript;
    static private GameManager gameManagerScript;
    static public int numberOfTargetsDestroyed;
    public AudioSource targetFX;
    public AudioClip hitSound;

    private void Awake()
    {
        spawnManagerScript = FindObjectOfType<SpawnManager>();
        gameManagerScript = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        if (!(gameManagerScript.isGameOver || gameManagerScript.isGamePaused))
        {
            spawnManagerScript.SpawnTargets();
            spawnManagerScript.RemovePostionFromList(transform.position);
            gameManagerScript.ScoreKeeper(pointValue);
            targetFX.PlayOneShot(hitSound);
            numberOfTargetsDestroyed++;
            Destroy(gameObject);
        }
    }
}
