using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	private float level;
	private float actualExperience;
	private float needExperienceForLevelUp;
	private Stats stats;


	public Level(Stats stats){
		this.stats = stats;
		this.level = 1;
		actualExperience = 0;
		needExperienceForLevelUp = 1000f;
	}


	public float getLevel(){
		return level;
	}

	public void addExperience(float experience){
		actualExperience += experience;
		checkLevelUp ();
	}

	public void checkLevelUp() {
		if (actualExperience >= needExperienceForLevelUp) {
			levelUp ();
			actualExperience -= needExperienceForLevelUp;
			checkLevelUp ();
		} 
	}

	public void levelUp(){
		needExperienceForLevelUp *= 1.7f;
		level++;
		stats.levelUp ();
		checkLevelUp ();
	}
}
