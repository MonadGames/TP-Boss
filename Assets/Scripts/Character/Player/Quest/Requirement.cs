using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirement : MonoBehaviour {

	protected bool isCompleted;
	protected Player player;

	public Requirement(Player player) {
		this.player = player;
	}

	void Start () {
		isCompleted = false;
	}

	void Update () {
		checkProgress ();
	}

	public bool isComplete (){
		return isCompleted;
	}

	public void checkProgress(){}
}
