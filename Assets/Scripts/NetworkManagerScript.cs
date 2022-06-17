using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkManagerScript : MonoBehaviour
{
    NetworkManager manager;

    private void Start()
    {
        manager = GetComponent<NetworkManager>();
    }
    public void ConnectPlayer()
    {
        manager.StartClient();
    }
}
