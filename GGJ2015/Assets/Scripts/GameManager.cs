using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public List<int> playersSkillsIdx;
    public AllSkills allSkills;

    [SerializeField]
    private int teamHealth = 10;
    [SerializeField]
    private int numberOfFirstLevel = 1;
    [SerializeField]
    private int numberOfPlayers;
    private PlayerManager pm;


    void Awake()
    {
        DontDestroyOnLoad(this);
        allSkills = GetComponent<AllSkills>();
        pm = GetComponent<PlayerManager>();
        OnLevelWasLoaded(2);
    }

    void OnLevelWasLoaded(int level)
    {
        if (level >= numberOfFirstLevel)
        {
            BroadcastMessage("ReceiveNumberOfPlayers", numberOfPlayers);
            BroadcastMessage("Init");
        }

    }

    public void Init()
    {
        //pm.Init();
    }

    public void UseSkill(int skillNumber)
    {

    }

    public void FailInstruction(int failedPlayerNum)
    {

    }

    public void ReceiveNumberOfPlayers(int numOfPlayers)
    {
        numberOfPlayers = numOfPlayers;
    }
}
