using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Requirement : ScriptableObject {

	public bool isCompleted = false;
	public Player player;

	public bool isComplete (){
		checkProgress ();
		return isCompleted;
	}

	public virtual void checkProgress(){}
}
