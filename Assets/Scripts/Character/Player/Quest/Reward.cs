using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reward : ScriptableObject {

	public void addExp(int exp, Player player) {
		player.addExperience (exp);
	}

	public void addMaxHp(float hp, Player player) {
		player.getHealth ().addMaxHp (hp);
	}

	public void addMaxSp(float sp, Player player) {
		player.getEnergy ().addMaxSp (sp);
	}

	public void addDamage(float attack, Player player) {
		player.addDamage (attack);
	} 

	public void addDefense(float defense, Player player) {
		player.addDefense (defense);
	}

	public void addGoodAction(Player player) {
		player.getStats ().addGoodAction ();
	}

	public void addBadAction(Player player) {
		player.getStats ().addBadAction ();
	}

	public abstract void applyReward(Player player);
}
