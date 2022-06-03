using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private int gridHeight;
    [SerializeField] private int gridLength;
    [SerializeField] private int startingTargetNumber;
    private List<Vector3> targetFilledPositions = new List<Vector3>();

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
        Vector3 position;
        do
        {
            position = new Vector3(Random.Range(-gridLength / 2, gridLength / 2), Random.Range(-gridHeight / 2, gridHeight / 2), 0) + transform.position;
        }
        while (CheckIfPositionsIsInTargetFilledPositions(position));
        targetFilledPositions.Add(position);
        return position;
    }

    public void RemovePostionFromList(Vector3 position)
    {
        targetFilledPositions.Remove(position);
    }

    private bool CheckIfPositionsIsInTargetFilledPositions(Vector3 position)
    {
        for (int i = 0; i < targetFilledPositions.Count; i++)
        {
            if (position == targetFilledPositions[i])
            {
                return true;
            }
        }
        return false;
    }
}

