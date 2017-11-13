using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

	public SpriteRenderer spriteRenderer;
	public float deadSpeed = 0.0000000000001f;
	public float timeOfDead = 1f;
	public int experience;

	private Player player;
	private EnemyAI enemyAI;

	
	void Start () {
		health = gameObject.GetComponent<Health>();
		enemyAI = gameObject.GetComponent<EnemyAI>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		player = GameObject.FindObjectOfType<Player> ();
	}

	void Update () {
		checkDead ();
	}
		
	public void checkDead(){
		if(isDead()) {
			Color color = spriteRenderer.material.color;
			if (timeOfDead > 0) {
				color.a = timeOfDead;
				timeOfDead -= Time.deltaTime;

				spriteRenderer.material.color = color;
			} else {
				this.die ();
				player.addExperience (experience);
				Destroy(gameObject, 1f);
			}
		}
	}

	public void move(){
	}

	public void checkForAnimation(){
	}

	public void attack(Player player){
		player.takeDamage(damage, transform);
	}

	// TODO: Refactorizar esto a un Collision Stay con cooldown
	public void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.name == "Player")
			attack (collision.gameObject.GetComponent<Player> ());
	}
}
