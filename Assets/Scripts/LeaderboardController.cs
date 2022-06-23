using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using LootLocker.Requests;

public class LeaderboardController : MonoBehaviour
{
    public int ID;

    public void SubmitScore(int score) {
        string playerId = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerId, score, ID, (response) => {});
    }

}