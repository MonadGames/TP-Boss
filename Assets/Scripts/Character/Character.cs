using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	
	public float damage = 20f;
	public float defense = 0f;

	public GameObject soulEffect;
	protected Rigidbody2D myBody;
	protected Animator anim;
	protected Health health;

	public Character() {}

	public bool isDead(){
		return this.health.health <= 0;
	}

	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		soulEffect.SetActive (false);
	}

	public void takeDamage(float damage){
		float newDamage = Mathf.Max (0, damage - defense);
		health.takeDamage(newDamage);
	}

	void Update () {}

	public void die(){
		if (soulEffect != null) {
			gameObject.layer = 12;
			health.hide ();
			soulEffect.SetActive (true);
			Destroy(soulEffect, 1f);    
		}
	}

	public Health getHealth() {
		return this.health;
	}
}
