using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sanity {

	protected int countOfGoodActions;
	protected int countOfBadActions;

	protected Stats stats;

	public Sanity(Stats stats, int countOfGoodActions, int countOfBadActions) {
		this.stats = stats;
		this.countOfBadActions = countOfBadActions;
		this.countOfGoodActions = countOfGoodActions;
	}

	public void addGoodAction(){
		countOfGoodActions++;
		checkIfChange ();
	}

	public void addBadAction (){
		countOfBadActions++;
		checkIfChange ();
	}

	public float modifyDefense(float def) {
		return def;
	}

	public float modifyAttack(float attack) {
		return attack;
	}

	public abstract void checkIfChange ();
}
