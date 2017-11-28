using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutral : Sanity {

	public Neutral(Stats stats, int countOfGoodActions, int countOfBadActions) :base(stats, countOfGoodActions, countOfBadActions){}


	public override void checkIfChange (){
		if (countOfBadActions >= countOfGoodActions) {
			stats.setSanity (new Evil (stats, countOfGoodActions, countOfBadActions));
		} else if (countOfGoodActions >= countOfBadActions) {
			stats.setSanity (new Kind (stats, countOfGoodActions, countOfBadActions));
		}	
	}

	public new bool isNetrual() {
		return true;
	}
}
