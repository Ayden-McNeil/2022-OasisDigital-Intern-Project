using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class UIManager : NetworkBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI playerCountText;
    [SerializeField] public TMP_InputField usernameInput;
    int time = 0;

    private void Start()
    {
        if (isServer)
        {
            StartCoroutine(StartTimer());
        }
    }

    IEnumerator StartTimer()
    {
        while (true)
        {
            UpdateTimerClientRpc(time++);
            yield return new WaitForSeconds(1);
        }
    }

    [ClientRpc]
    public void UpdateTimerClientRpc(int time)
    {
        if (time % 60 < 10)
        {
            timerText.text = (time / 60).ToString() + ":0" + (time % 60).ToString();
        }
        else
        {
            timerText.text = (time / 60).ToString() + ":" + (time % 60).ToString();

        }
    }
    /*
    public void UpdatePlayerCountUI(int numberOfPlayers)
    {
        playerCountText.text = numberOfPlayers.ToString();
    }

    [Command(requiresAuthority = false)]
    public void UpdateUsernameCmd(string name, NetworkIdentity ID)
    {
        UpdateUsernameRpc(name, ID);
    }

    [ClientRpc]
    public void UpdateUsernameRpc(string name, NetworkIdentity ID)
    {
        ID.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = name;
    }
    */
}
