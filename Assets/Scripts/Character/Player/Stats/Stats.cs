using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	private Level level;
	private Sanity sanity;
	private Player player;
	private Inventory inventory;

	public Stats(){
		player = gameObject.GetComponentsInChildren<Player>();
		level = new Level();
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
		// calculo de daño y generacion de damage.
	}

	public void takeDamage(Damage damage){
		// calculo de resta de vida 
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
}

