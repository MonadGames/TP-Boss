using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evil : Sanity {

	public Evil(Stats stats, int countOfGoodActions, int countOfBadActions) :base(stats, countOfGoodActions, countOfBadActions){}

	public override void checkIfChange (){
		if (countOfGoodActions >= countOfBadActions) {
			stats.setSanity (new Kind (stats, countOfGoodActions, countOfBadActions));
		}	
	}
}
