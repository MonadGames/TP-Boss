using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kind : Sanity {

	public Kind(Stats stats, int countOfGoodActions, int countOfBadActions) :base(stats, countOfGoodActions, countOfBadActions){}

	public override void checkIfChange (){
		if (countOfBadActions >= countOfGoodActions) {
			stats.setSanity (new Evil (stats, countOfGoodActions, countOfBadActions));
		}		
	}
}
