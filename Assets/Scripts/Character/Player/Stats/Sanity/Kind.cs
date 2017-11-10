﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kind : Sanity {

	public Kind(Stats stats, int countOfGoodActions, int countOfBadActions) :base(stats, countOfGoodActions, countOfBadActions){}

	public override void checkIfChange (){
		if (countOfBadActions >= countOfGoodActions) {
			stats.setSanity (new Evil (stats, countOfGoodActions, countOfBadActions));
		}		
	}

	public new float modifyAttack(float att) {
		return att / 1.2f;
	}

	public new float modifyDefense(float def) {
		return def * 1.2f;
	}
}