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

    private void Awake()
    {
        spawnManagerScript = FindObjectOfType<SpawnManager>();
        gameManagerScript = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        if (!gameManagerScript.isGameOver && !gameManagerScript.isGamePaused && gameManagerScript.isGameStarted)
        {
            spawnManagerScript.SpawnTargets();
            spawnManagerScript.RemovePostionFromList(transform.position);
            gameManagerScript.ScoreKeeper(pointValue);
            numberOfTargetsDestroyed++;
            Destroy(gameObject);
        }
    }
}
