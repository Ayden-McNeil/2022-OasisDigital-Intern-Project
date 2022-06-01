using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float delay;
    [SerializeField] private int gridHeight;
    [SerializeField] private int gridLength;
    [SerializeField] private int startingTargetNumber;

    private void Start()
    {
        for (int i = 0; i < startingTargetNumber; i++)
        {
            SpawnTargets();
        }
    }

    public void SpawnTargets()
    {
        Instantiate(target, GenerateRandomPosition(), target.transform.rotation);
    }

    Vector3 GenerateRandomPosition()
    {
        return new Vector3(Random.Range(-gridLength/2, gridLength/2), Random.Range(-gridHeight / 2, gridHeight / 2), 0);
    }
}

