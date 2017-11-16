using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	private Level level;
	private Sanity sanity;
	private Player player;
	private Inventory inventory;

	public StatBar experienceBar;

	void Start(){
		this.player = gameObject.GetComponent<Player>();
		level = new Level(this);
		sanity = new Kind (this, 0, 0);
		inventory = new Inventory();
	}

	void Update(){
		updateExperience (level.getActualExperience(), level.getNeededExperienceForLevelUp());
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
		float newDamage = Mathf.Max (0, damage.getDamage () - (sanity.modifyDefense(player.getDefense())));
		player.getHealth().takeDamage(newDamage);
	}

	public void setSanity(Sanity sanity) {
		this.sanity = sanity;
		changedSanity ();
	}

	public void addExperience(int exp){
		level.addExperience (exp);
	}

	public void updateExperience(float exp, float maxExp){
		float normalizedExp = mapRange(exp, 0f, maxExp, 0f, 100f );
		experienceBar.updateBar (normalizedExp, 100f);
	}

	private float mapRange(float value, float minFrom, float maxFrom, float minTo, float maxTo){
		return (value - minFrom) / (maxFrom - minFrom) * (maxTo - minTo) + minTo;
	}

	public void changedSanity() {
		// Aca cambiaria todo lo que el sanity afecta 
	}

	public void levelUp() {
		// actualizar el weight
		player.getEnergy ().addMaxSp(10);
		player.getHealth ().addMaxHp (5);
		player.addDefense (3);
		player.addDamage (5);
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

	public Sanity getSanity() {
		return sanity;
	}
}

