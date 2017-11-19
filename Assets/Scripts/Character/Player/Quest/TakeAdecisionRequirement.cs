using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDecisionRequirement", menuName = "Requirement/Take A Decision")]
public class TakeAdecisionRequirement : Requirement {

	public void takedecision() {
		isCompleted = true;
	}

}
