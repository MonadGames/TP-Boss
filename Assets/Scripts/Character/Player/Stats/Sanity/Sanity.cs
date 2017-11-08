using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanity : MonoBehaviour {

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

	public abstract void checkIfChange ();
}
