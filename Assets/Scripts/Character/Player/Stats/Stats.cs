﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	private Level level;
	private Sanity sanity;
	private Player player;
	private Inventory inventory;

	public Stats(Player player){
		this.player = player;
		level = new Level(this);
		sanity = new Kind (this, 0, 0);
		inventory = new Inventory();
	}

	public void addGoodAction(){
		sanity.addGoodAction ();
	}

	public void addBadAction(){
		sanity.addBadAction ();
	}

	public Damage getDamage(Spell spell){
		return new Damage (spell, this);
	}

	public void takeDamage(Damage damage){
		float newDamage = Mathf.Max (0, damage.getDamage () - player.getDefense());
		player.getHealth().takeDamage(newDamage);
	}

	public void setSanity(Sanity sanity) {
		this.sanity = sanity;
		changedSanity ();
	}

	public void addExperience(int exp){
		level.addExperience (exp);
	}

	public void changedSanity() {
		// Aca cambiaria todo lo que el sanity afecta 
	}

	public void levelUp(){
		// actualizar el weight
		// Si luego tenemos stats posta aca deberiamos acutalizarlos por lvlup.
	}

	public bool addItem(Item item){
		return inventory.addItem (item);
	}

	public bool haveItem(Item item){
		return inventory.haveItem (item);
	}

	public void useItem(Item item){
		inventory.useItem (item);
	}

	public Player getPlayer() {
		return player;
	}
}

