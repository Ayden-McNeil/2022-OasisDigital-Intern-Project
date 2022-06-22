using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ServerSceneLoader : NetworkBehaviour
{
    [SerializeField] private GameObject sceneLoader;
    void Start()
    {
        if (isServerOnly)

        {
            if (isClient)
            {
                return;
            }
            sceneLoader.GetComponent<LoadingScenes>().LoadScene("OnlineScene");
            Debug.Log("Server loaded online scene");
        }
    }

}
