using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Requirement {

	protected bool isCompleted;
	protected Player player;

	public Requirement(Player player) {
		this.player = player;
	}

	void Start () {
		isCompleted = false;
	}

	public bool isComplete (){
		checkProgress ();
		return isCompleted;
	}

	public virtual void checkProgress(){}
}
