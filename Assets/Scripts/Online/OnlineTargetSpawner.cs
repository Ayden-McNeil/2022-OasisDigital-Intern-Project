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
        AddPostionFromList(oldPosition);
    }

    Vector3 GenerateRandomPosition()
    {
        int randomNumber = Random.Range(0, targetEmptyPositions.Count - 1);
        Vector3 position = targetEmptyPositions[randomNumber];
        targetEmptyPositions.RemoveAt(randomNumber);
        return position;
    }

    public void AddPostionFromList(Vector3 position)
    {
        targetEmptyPositions.Add(position);
    }

    private void PopulateTargetEmptyPositions()
    {
        for (int i = -gridHeight; i < gridHeight; i++)
        {
            for (int j = -gridLength; j < gridLength; j++)
            {
                targetEmptyPositions.Add(new Vector3(j, i, 0) + transform.position);
            }
        }
    }
}

/*private void Start()
{
    private Dictionary<int, GameObject> targetDictionary = new Dictionary<int, GameObject>();
    if (isServer)
    {
        PopulateTargetEmptyPositions();
        SpawnTargetsCmd();
    }
}

[Command]
private void SpawnTargetsCmd()
{
    for (int i = 0; i < startingTargetNumber; i++)
    {
        Debug.Log("spawned a target on the server");
        Vector3 position = GenerateRandomPosition();
        GameObject spawnedTarget = Instantiate(target, position, target.transform.rotation);
        targetDictionary.Add(spawnedTarget.GetComponent<OnlineTarget>().ID, spawnedTarget);
    }
}

[Command(requiresAuthority = false)]
public void OnPlayerJoins(GameObject player)
{
    for (int i = 0; i < startingTargetNumber; i++)
    {
        SpawnTargetRpc(player.GetComponent<NetworkIdentity>().connectionToClient, targetDictionary[i].transform.position);
    }
}

[TargetRpc]
private void SpawnTargetRpc(NetworkConnection player, Vector3 position)
{
    GameObject spawnedTarget = Instantiate(target, position, target.transform.rotation);
    targetDictionary.Add(spawnedTarget.GetComponent<OnlineTarget>().ID, spawnedTarget);
}

[Command(requiresAuthority = false)]
public void ChangeTagetPositionCmd(int ID)
{
    Vector3 position = GenerateRandomPosition();
    targetDictionary[ID].transform.position = position;
    ChangeTargetPositionRpc(ID, position);
    targetEmptyPositions.Add(targetDictionary[ID].transform.position);


}

[ClientRpc]
private void ChangeTargetPositionRpc(int ID, Vector3 newPosition)
{
    targetDictionary[ID].transform.position = newPosition;
}*/

