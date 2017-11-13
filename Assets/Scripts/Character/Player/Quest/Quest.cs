using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : ScriptableObject {

	private string description;
	private string questName;
	private Player player;
	private Reward reward;
	private Requirement requirement;

	public Quest(string questName, string description, Player player, Requirement requirement, Reward reward){
		this.requirement = requirement;
		this.questName = questName;
		this.description = description;
		this.player = player;
		this.reward = reward; 
	}

	void Update () {
		//if (isFinishQuest ()) {
		//	applyReward ();
		//}
	}

	public bool isFinishQuest (){
		return requirement.isComplete ();
	}

	// Tendria sentido que el npc diga completar Mision
	public void applyReward (){
		reward.applyReward (player);
	}

	public string getDescription() {
		return description;
	}

	public string getName() {
		return questName;
	}

}
