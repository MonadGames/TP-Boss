using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Requirement : ScriptableObject {

	public bool isCompleted = false;

	public bool isComplete (Player player){
		checkProgress (player);
		return isCompleted;
	}

	public virtual void checkProgress(Player player){}

	public virtual void notify(string message){}

	void OnEnable() {
		isCompleted = false;
	}
}
