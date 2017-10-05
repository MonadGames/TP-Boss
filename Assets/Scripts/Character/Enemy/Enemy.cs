using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

	private EnemyAI enemyAI;
	public SpriteRenderer spriteRenderer;
	public float deadSpeed = 0.0000000000001f;
	public float timeOfDead = 1f;
	private bool isAlive;
	
	void Start () {
		health = gameObject.GetComponent<Health>();
		enemyAI = gameObject.GetComponent<EnemyAI>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		isAlive = true;
	}

	void Update () {
		checkDead ();
	}
		
	public void checkDead(){
		if(isDead()) {
			Color color = spriteRenderer.material.color;
			print (color.a);
			if (timeOfDead > 0) {
				color.a = timeOfDead;
				timeOfDead -= Time.deltaTime;

				spriteRenderer.material.color = color;
			} else {
				Destroy(gameObject, 0f);
			}
		}
	}

	public void die(){
		// No esta llegando aca
		isAlive = false;
		//Aca definir la accion de la muerte del enemy
	}

	public void move(){
	}

	public void checkForAnimation(){
	}

	public void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.name == "Player")
			collision.gameObject.GetComponent<Player>().takeDamage(damage, transform);
	}

	public void OnCollisionExit2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player"){}
		if (collision.gameObject.tag == "spell") {
			enemyAI.takeDamage ();
		}
	}

}
