using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    static private SpawnManager spawnManagerScript;

    private void Awake()
    {
        spawnManagerScript = FindObjectOfType<SpawnManager>();
    }

    private void OnMouseDown()
    {
        spawnManagerScript.SpawnTargets();
        spawnManagerScript.RemovePostionFromList(transform.position);
        Destroy(gameObject);

    }
}
