using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class OnlineTargetSpawner: NetworkBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private int gridHeight;
    [SerializeField] private int gridLength;
    [SerializeField] private int startingTargetNumber;
    private List<Vector3> targetEmptyPositions = new List<Vector3>();

    private void Start()
    {
        if (isServer)
        {
            PopulateTargetEmptyPositions();
            for (int i = 0; i < startingTargetNumber; i++)
            {
                Vector3 position = GenerateRandomPosition();
                GameObject spawnedTarget = Instantiate(target, position, target.transform.rotation);
                NetworkServer.Spawn(spawnedTarget);
            }
        }
    }

    [Command(requiresAuthority = false)]
    public void ChangePosition(GameObject targetObject)
    {
        Vector3 oldPosition = targetObject.transform.position;
        targetObject.transform.position = GenerateRandomPosition();
        AddPostionToList(oldPosition);
    }

    Vector3 GenerateRandomPosition()
    {
        int randomNumber = Random.Range(0, targetEmptyPositions.Count - 1);
        Vector3 position = targetEmptyPositions[randomNumber];
        targetEmptyPositions.RemoveAt(randomNumber);
        return position;
    }

    public void AddPostionToList(Vector3 position)
    {
        targetEmptyPositions.Add(position);
    }

    private void PopulateTargetEmptyPositions()
    {
        for (int i = -gridLength; i < gridLength; i++)
        {
            for (int j = -gridHeight; j < gridHeight; j++)
            {
                targetEmptyPositions.Add(new Vector3(i, j, 0) + transform.position);
            }
        }
    }
}
