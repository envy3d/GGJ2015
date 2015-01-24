using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;

    private int numberOfPlayers;


    public void Init()
    {
        for (int playerNum = 0; playerNum < numberOfPlayers; playerNum++)
        {
            GameObject player = Instantiate(playerPrefab) as GameObject;
            player.BroadcastMessage("ReceivePlayerNumber", playerNum);
            player.BroadcastMessage("Init");
        }
    }

    public void ReceiveNumberOfPlayers(int numOfPlayers)
    {
        numberOfPlayers = numOfPlayers;
    }
}
