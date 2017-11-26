using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level {

	private int level;
	private float actualExperience;
	private float neededExperienceForLevelUp;
	private Stats stats;
	private FloatingTextController textController;

	public Level(Stats stats){
		this.stats = stats;
		this.level = 1;
		this.actualExperience = 100f;
		this.neededExperienceForLevelUp = 1000f;
		textController = GameObject.FindObjectOfType<FloatingTextController> ();
	}

	public float getActualExperience(){
		return actualExperience;
	}

	public float getNeededExperienceForLevelUp(){
		return neededExperienceForLevelUp;
	}

	public int getLevel(){
		return level;
	}

	public void addExperience(float experience){
		actualExperience += experience;

		if (actualExperience >= neededExperienceForLevelUp) {
			levelUp ();
			actualExperience = 0;
			textController.createLevelUp (stats.transform);
		} else {
			textController.createGetExperience (experience.ToString (), stats.transform);	
		}
	}

	public void checkLevelUp() {
		
	}

	public void levelUp(){
		neededExperienceForLevelUp *= 1.7f;
		level++;
		stats.levelUp ();
	}
}
