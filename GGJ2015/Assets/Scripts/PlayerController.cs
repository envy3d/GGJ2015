using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameManager gm;
	public int[] playerSkillSetIdx;
	public Skill[] playerSkillSet;

	public KeyCode key1;
	public KeyCode key2;
	public KeyCode key3;
	public KeyCode key4;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(key1)){
			gm.UseSkill(playerSkillSetIdx[0]);
		}
		if(Input.GetKeyDown(key2)){
			gm.UseSkill(playerSkillSetIdx[1]);
		}
		if(Input.GetKeyDown(key3)){
			gm.UseSkill(playerSkillSetIdx[2]);
		}
		if(Input.GetKeyDown(key4)){
			gm.UseSkill(playerSkillSetIdx[3]);
		}
	}

	public Skill RetrievePlayerSkills (int skillIdx) {
		return playerSkillSet[skillIdx];
	}
}
