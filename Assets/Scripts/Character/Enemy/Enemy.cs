using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

	private EnemyAI enemyAI;
	
	void Start () {
		health = gameObject.GetComponent<Health>();
		enemyAI = gameObject.GetComponent<EnemyAI>();
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
			Player player = GameObject.FindObjectOfType<Player> ();
			takeDamage (player.totalDamage(spell), transform);
		}
	}

	public void OnCollisionExit2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player"){}
		if (collision.gameObject.tag == "spell") {
			enemyAI.takeDamage ();
		}
	}

}
