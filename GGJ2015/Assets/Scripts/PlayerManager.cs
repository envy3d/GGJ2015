using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;

    private int numberOfPlayers;
    private List<PlayerUI> players;


    public void Init()
    {
        for (int playerNum = 0; playerNum < numberOfPlayers; playerNum++)
        {
            GameObject player = Instantiate(playerPrefab) as GameObject;
            player.BroadcastMessage("ReceivePlayerNumber", playerNum);
            player.BroadcastMessage("Init");
            players.Add(player.GetComponent<PlayerUI>());
        }
    }

    public void ReceiveNumberOfPlayers(int numOfPlayers)
    {
        numberOfPlayers = numOfPlayers;
        players = new List<PlayerUI>(numOfPlayers);
    }

    public void FailInstruction(int playerNum)
    {
        players[playerNum].FailInstruction();
    }

    public void WinInstruction(int playerNum)
    {
        players[playerNum].WinInstruction();
    }

    public void SetInstruction(int playerNum, Skill instruction)
    {
        players[playerNum].SetInstruction(instruction);
    }
}
