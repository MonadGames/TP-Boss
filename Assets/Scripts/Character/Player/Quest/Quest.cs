using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour {

	protected string questName;
	protected Player player;

	public Quest(string questName, Player player){
		this.questName = questName;
		this.player = player;
	}

	public abstract void verifyProgress ();

	public abstract void applyReward ();

}
