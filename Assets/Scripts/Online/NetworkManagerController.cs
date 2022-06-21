using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManagerController : MonoBehaviour
{
    [SerializeField] private GameObject networkManager;
    static private bool isNetworkManagerSpawned = false;

    public void Awake()
    {
        if (!isNetworkManagerSpawned)
        {
            Instantiate(networkManager);
            isNetworkManagerSpawned = true;
        }
    }

    public void ConnectToServer()
    {
        GameObject.Find("NetworkManager(Clone)").GetComponent<NetworkManagerScript>().ConnectPlayer();
    }
}
