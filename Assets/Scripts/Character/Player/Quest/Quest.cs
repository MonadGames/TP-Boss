using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest", order = 1)]
public class Quest : ScriptableObject {

	public string questName;
	public string description;
	public string[] historyText;
	public string[] finishText;

	public Reward reward;
	public Requirement requirement;

	public bool isFinishQuest (Player player){
		return requirement.isComplete (player);
	}

	// Tendria sentido que el npc diga completar Mision
	public void completeQuest (Player player){
		player.getHealth ().revive ();
		reward.applyReward (player);
	}

	public string getDescription() {
		return description;
	}

	public string getName() {
		return questName;
	}

}
