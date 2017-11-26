using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	private Level level;
	private Sanity sanity;
	private Player player;
	private Inventory inventory;
	private float timeRecovery = 0f;

	private AudioSource audioSource;
	public StatBar experienceBar;
	public AudioClip lvlup;



	void Start(){
		this.player = gameObject.GetComponent<Player>();
		level = new Level(this);
		sanity = new Kind (this, 0, 0);
		inventory = new Inventory();
		audioSource = GetComponent<AudioSource>();
	}

	void Update(){
		updateExperience (level.getActualExperience(), level.getNeededExperienceForLevelUp());

		checkSpRecovery ();
	}

	public void checkSpRecovery() {
		if (timeRecovery >= 1f) {
			spRecovery ();
			timeRecovery -= 1f;
		}

		timeRecovery += Time.deltaTime;
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
		experienceBar.updateBar (exp, maxExp);
	}

	public void changedSanity() {
		// Aca cambiaria todo lo que el sanity afecta 
	}

	public void spRecovery() {
		float sp = 0.5f * level.getLevel ();
		player.getEnergy ().addSP (sp);
	}

	public void levelUp() {
		// actualizar el weight
		audioSource.PlayOneShot (lvlup, 1f);
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

	public int getLevel() {
		return level.getLevel ();
	}
}

