﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	public float maxHealth = 100f;
	public float health;					// The player's health.
	public Character character;
	public float repeatDamagePeriod = 2f;		// How frequently the player can be damaged.
	protected float lastHitTime;					// The time at which the player was last hit.
	public HealthBar healthBar;

	void Awake () {
		character = gameObject.GetComponent<Character> (); 
		health = maxHealth;
	}

	void Update(){
		if (health <= 0) {
			character.die ();
		}
	}

	public void revive() {
		health = maxHealth;
	}

	public void takeDamage (float damage) {
		if (health > 0f && damage > 0) {
			health -= damage;
			UpdateHealthBar();
		}
	}

	public void hide(){
		healthBar.hide();
	}

	public void show(){
		healthBar.show();
	}

	public void UpdateHealthBar(){
		healthBar.updateHealthBar (health, maxHealth);
	}

	public void addMaxHp(float hp){
		maxHealth += hp;
	}

	public void addHP(float hp) {
		health += hp;
	}

}

