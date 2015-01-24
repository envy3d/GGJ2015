using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;

    private int numberOfPlayers;
    private List<PlayerUI> playerUIs;


    public void Init()
    {
        for (int playerNum = 0; playerNum < numberOfPlayers; playerNum++)
        {
            GameObject player = Instantiate(playerPrefab) as GameObject;
            player.BroadcastMessage("ReceivePlayerNumber", playerNum);
            player.BroadcastMessage("Init");
            playerUIs.Add(player.GetComponent<PlayerUI>());
        }
    }

    public void ReceiveNumberOfPlayers(int numOfPlayers)
    {
        numberOfPlayers = numOfPlayers;
        playerUIs = new List<PlayerUI>(numOfPlayers);
    }

    public void FailInstruction(int playerNum)
    {
        playerUIs[playerNum].FailInstruction();
    }

    public void WinInstruction(int playerNum)
    {
        playerUIs[playerNum].WinInstruction();
    }

    public void SetInstruction(int playerNum, Skill instruction)
    {
        playerUIs[playerNum].SetInstruction(instruction);
    }

    public void SetSkills(int playerNum, int skill1, int skill2, int skill3, int skill4)
    {

    }
}
