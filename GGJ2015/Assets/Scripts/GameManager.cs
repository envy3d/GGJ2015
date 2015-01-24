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
    private List<int> currentInstructions;
    private EnemyController currentEnemy;


    void Awake()
    {
        DontDestroyOnLoad(this);
        allSkills = GetComponent<AllSkills>();
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        OnLevelWasLoaded(2);
    }

    void OnLevelWasLoaded(int level)
    {
        if (level >= numberOfFirstLevel)
        {
            pm.ReceiveNumberOfPlayers(numberOfPlayers);
            Init();
            pm.Init();
        }

    }

    public void Init()
    {
        
    }

    public void UseSkill(int skillNumber, int playerNum)
    {
        if (currentInstructions.Contains(skillNumber))
        {

            GenerateNewInstruction(playerNum);
        }
        else
        {
            FailInstruction(playerNum);
        }
    }

    public void FailInstruction(int failedPlayerNum)
    {
        teamHealth -= 1;
        if (teamHealth <= 0)
        {
            // Game Over
        }
        GenerateNewInstruction(failedPlayerNum);
    }

    public void GenerateNewInstruction(int playerNum)
    {
        pm.SetInstruction(playerNum, allSkills.skills[Random.Range(0, playersSkillsIdx.Count)]);
    }

    public void ReceiveNumberOfPlayers(int numOfPlayers)
    {
        numberOfPlayers = numOfPlayers;
    }

    public void SetSkills()
    {
        int numberOfSkills = numberOfPlayers * 4;
        playersSkillsIdx = new List<int>(numberOfSkills);
        for (int i = 0; i < numberOfSkills; i++)
        {
            int nextSkillIdx;

            do { nextSkillIdx = Random.Range(0, allSkills.skills.Count); }
            while (playersSkillsIdx.Contains(nextSkillIdx));

            playersSkillsIdx.Add(nextSkillIdx);
        }

        for (int ps = 0; ps < numberOfPlayers; ps++)
        {
            
        }
    }
}
