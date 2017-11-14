using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level {

	private float level;
	private float actualExperience;
	private float neededExperienceForLevelUp;
	private Stats stats;


	public Level(Stats stats){
		this.stats = stats;
		this.level = 1;
		this.actualExperience = 100f;
		this.neededExperienceForLevelUp = 1000f;
	}

	public float getActualExperience(){
		return actualExperience;
	}

	public float getNeededExperienceForLevelUp(){
		return neededExperienceForLevelUp;
	}

	public float getLevel(){
		return level;
	}

	public void addExperience(float experience){
		actualExperience += experience;
		checkLevelUp ();
	}

	public void checkLevelUp() {
		if (actualExperience >= neededExperienceForLevelUp) {
			levelUp ();
			actualExperience = 0;
		} 
	}

	public void levelUp(){
		neededExperienceForLevelUp *= 1.7f;
		level++;
		stats.levelUp ();
		Debug.Log ("levelup");
	}
}
