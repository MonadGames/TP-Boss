using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

	public float maxEnergy;
	public float energy;

	void Start () {
		maxEnergy = 50f;
		energy = maxEnergy;	
	}

	public void revive() {
		energy = maxEnergy;
	}

	public bool canUse (float skillCost){
		if (energy >= skillCost) {
			energy -= skillCost;
			return true;
		}
		return false;
	}	

	public void addMaxSp(float sp){
		maxEnergy += sp;
	}
}
