using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour {

	protected string description;
	protected string questName;
	protected Player player;
	protected Reward reward;

	public Quest(string questName, Player player, Reward reward){
		this.questName = questName;
		this.player = player;
		this.reward = reward; 
	}

	public abstract void verifyProgress ();

	public void applyReward (){
		// EL reward tambien deberia llamar a addGood o bad action;
		reward.applyReward (player);
	}

}
