using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAdecisionRequirement : Requirement {

	public TakeAdecisionRequirement(Player player) : base(player) {
	}

	public void takedecision() {
		isCompleted = true;
	}

}
