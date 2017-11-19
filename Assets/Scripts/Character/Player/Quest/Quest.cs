using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest", order = 1)]
public class Quest : ScriptableObject {

	public string questName;
	public string description;
	private Player player;
	public Reward reward;
	public Requirement requirement;

	public bool isFinishQuest (){
		return requirement.isComplete ();
	}

	// Tendria sentido que el npc diga completar Mision
	public void completeQuest (){
		reward.applyReward (player);
	}

	public string getDescription() {
		return description;
	}

	public string getName() {
		return questName;
	}

	public void setPlayer(Player player){
		this.player = player;
	}

}
