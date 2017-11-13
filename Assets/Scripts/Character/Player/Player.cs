﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	//ui 
	public GameObject skillSelected;
	public float powerHurtForce = 2f;
	public float hurtForce = 10f;
	public float timeOfDead = 1f;

	private SpriteRenderer[] spritesRenderers;
	private Spell spellSelected = null;
	private float lastHit = 0f;
	private float secondsOfInvulnerability = 2f;
	private bool deadAnim = false;
	private CameraController cameraController;

	// core
	private Energy energy;
	private Stats stats; 
	private Quest mainQuest;
	private List<Quest> secondaryQuests;

	void Start () {
		//ui
		anim = GetComponent<Animator> ();
		cameraController = gameObject.GetComponentInChildren<CameraController>();
		spritesRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
		//spellSelected = skillSelected.GetComponent<Spell> ();

		//core
		health = gameObject.GetComponent<Health>();
		energy = gameObject.GetComponent<Energy>();
		stats = gameObject.GetComponent<Stats>();
		secondaryQuests = new List<Quest> ();
	}

	void Update () {
		if (!isDead ()) {
			checkVulnerability ();	
		} else {
			updateDeath ();
		}
	}

	public void revive() {
		anim.SetTrigger ("Revive");
		health.revive();
		energy.revive ();
	}

	public void checkVulnerability(){
		lastHit -= Time.deltaTime;

		foreach (SpriteRenderer sprite in spritesRenderers) {
			Color color = sprite.color;
			color.a = (lastHit > 0) ? Mathf.Sin (Random.Range(-1f, 1f)) : 1f;
			sprite.material.color = color;
		}
	}

	public void updateDeath () {
		timeOfDead -= Time.deltaTime;

		if (!deadAnim) {
			anim.SetTrigger ("Die");
			deadAnim = true;
		}

		if (timeOfDead > 0) {
			foreach (SpriteRenderer sprite in spritesRenderers) {
				Color color = sprite.color;
				color.a = timeOfDead;
				sprite.material.color = color;
			}
		} else {
			this.die ();
		}
	}

	public bool canUseSkill() {
		if(spellSelected == null){
			return false;
		}

		return energy.canUse (spellSelected.damage);
	}

	public GameObject getSkillSelected() {
		return skillSelected;
	}

	public void takeDamage(float damage, Transform transformE){
		hurtEffect (transformE);
		if (lastHit <= 0) {
			lastHit = secondsOfInvulnerability;
			base.takeDamage (damage);
			cameraController.takeDamage ();
		}
	}

	public void hurtEffect(Transform transformE){
		float side = (transformE.localScale.x > 0) ? 1 : -1;

		Vector3 hurtVector = new Vector3(side  * powerHurtForce, 0, 0);
		GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);
	}

	public Damage getDamage(Spell spell) {
		return stats.getDamage (spell);
	}

	public void addExperience(int exp) {
		stats.addExperience (exp);
	}

	public void addBadAction(){
		stats.addBadAction();
	}

	public void addGoodAction(){
		stats.addGoodAction();
	}

	public float getDefense() {
		return defense;
	}

	public void acceptQuest(Quest quest) {
		secondaryQuests.Add (quest);
	}

	public void completeQuest(Quest quest) {
		secondaryQuests.Remove (quest);
	}

	public void setMainQuest(Quest principalQuest){
		this.mainQuest = principalQuest;
	}

	public Quest getMainQuest(){
		return mainQuest;
	}

	public Energy getEnergy(){
		return energy;
	}

	public void addDamage(float newDamage){
		damage += newDamage;
	}

	public void addDefense(float newDefense){
		defense += newDefense;
	}

	public Stats getStats() {
		return stats;
	}
}
