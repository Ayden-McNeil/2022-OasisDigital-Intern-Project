using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using LootLocker.Requests;
using System.Threading.Tasks;

public class Leaderboard : MonoBehaviour
{
    public int ID;
    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;
    private List<string> names;
    private List<string> scores;

    private void Start() {
        names = new List<string>();
        scores = new List<string>();
        ResetText();
        StartCoroutine(SetupRoutine());
    }

    private void Update() {
        string tempNames = "Names\n";
        string tempScores = "Scores\n";
        for (int i = 0; i < 10; i++) {
            tempNames += (i + 1).ToString() + ". " + names[i] + "\n";
            tempScores += scores[i] + "\n";
        }
        playerNames.text = tempNames;
        playerScores.text = tempScores;
    }

    IEnumerator SetupRoutine() {
        yield return LoginRoutine();
        yield return FetchTopHighscoresRoutine();
    }

    IEnumerator LoginRoutine() {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) => {
            if (response.success) {
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
            }
            done = true;
        });
        yield return new WaitWhile(() => done == false);
    }

    private void ResetText() {
        names.Clear();
        scores.Clear();
        for (int i = 0; i < 10; i++) {
            names.Add("");
            scores.Add("");
        }
    }

    string GetPlayerNameById(string id, int rank) {
        string printed = "";
        LootLockerSDKManager.LookupPlayerNamesByPlayerIds(new ulong[] { ulong.Parse(id) }, response =>
        {
            string name = "";
            if (response.success && response.players.Length != 0) name = response.players[0].name;
            printed = (name != "") ? name : id;
            names[rank-1] = printed;
        });
        return printed;
    }
    IEnumerator FetchTopHighscoresRoutine() {
        ResetText();
        bool done = false;
        LootLockerSDKManager.GetScoreList(ID, 10, 0, (response) => {
            if (response.success) {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;

                foreach (LootLockerLeaderboardMember member in members) {
                    tempPlayerNames += member.rank + ". ";
                    string id = member.member_id;
                    name = GetPlayerNameById(id, member.rank);
                    tempPlayerNames += name + "\n";
                    tempPlayerScores += member.score + "\n";
                    scores[member.rank - 1] = member.score.ToString();
                }
                done = true;
                // playerNames.text = tempPlayerNames;
                // playerScores.text = tempPlayerScores;
            }
            else {
                Debug.Log(response.text);
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}