using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LootLocker.Requests;

public class PlayerNamer : MonoBehaviour
{
    public string playerName = "";

    public void SetNameInternally(string playerName) {
        this.playerName = playerName;
    }

    public void SetPlayerName() {
        string id = PlayerPrefs.GetString("PlayerID");
        System.Random rnd = new System.Random();
        if (id is null || id == "") id = rnd.Next().ToString();
        if (playerName == "") playerName = "Guest " + id;
        LootLockerSDKManager.SetPlayerName(playerName, (response) => {
            Debug.Log(response);
        });
    }
}
