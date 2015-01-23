using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;

    [SerializeField]
    private int numberOfPlayers;
    [SerializeField]
    private int numberOfFirstLevel = 1;

    void Start()
    {
        DontDestroyOnLoad(this);
        OnLevelWasLoaded(2);
    }

    void OnLevelWasLoaded(int level)
    {
        if (level >= numberOfFirstLevel)
        {
            for (int playerNum = 0; playerNum < numberOfPlayers; playerNum++)
            {
                GameObject player = Instantiate(playerPrefab) as GameObject;
                player.BroadcastMessage("ReceivePlayerNumber", playerNum);
            }
        }
    }
}
