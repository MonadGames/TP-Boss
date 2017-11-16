using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

	public float maxEnergy = 50f;
	public float energy;
	public StatBar energyBar;

	void Start () {
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

	void Update(){
		energyBar.updateBar (energy, maxEnergy);
	}

	public void addMaxSp(float sp){
		maxEnergy += sp;
	}

	public void addSP(float value){
		if (energy + value >= maxEnergy) {
			energy = maxEnergy;
		} else {
			energy += value;
		}
	}
}
