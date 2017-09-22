using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {
	
	void Start () {
		health = gameObject.GetComponent<Health>();
	}

	void Update () {
		if(health.health <= 0)
			Destroy(gameObject, 1f);
	}

	public void move(){
	}

	public void checkForAnimation(){
	}

	public void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.name == "Player")
			collision.gameObject.GetComponent<Player>().takeDamage(damage, transform);
		
		if (collision.gameObject.tag == "spell") {
			Spell spell = collision.gameObject.GetComponent<Spell> ();
			takeDamage (spell.damage, transform);
		}
	}

	public void OnCollisionExit2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player"){}
	}

}
