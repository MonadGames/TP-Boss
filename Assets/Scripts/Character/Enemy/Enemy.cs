using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

	public SpriteRenderer spriteRenderer;
	public float deadSpeed = 0.0000000000001f;
	public float timeOfDead = 1f;
	public int experience;
	public float cd = 0.5f;
	public float lastTime = 0.5f;
	public bool giveLoot;

	private Player player;
	private EnemyAI enemyAI;
	private LootSystem lootSystem;

	
	void Start () {
		health = gameObject.GetComponent<Health>();
		enemyAI = gameObject.GetComponent<EnemyAI>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		player = GameObject.FindObjectOfType<Player> ();
		textController = GameObject.FindObjectOfType<FloatingTextController> ();
		lootSystem = GameObject.FindObjectOfType<LootSystem> ();
		giveLoot = false;
	}

	void Update () {
		checkDead ();
		lastTime += Time.deltaTime;
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
				loot ();
				Destroy(gameObject, 1f);
			}
		}
	}

	public void loot() {
		if (!giveLoot) {
			player.addExperience (experience);
			textController.createGetExperience (experience.ToString(), player.transform);
			lootSystem.loot (gameObject.transform);
			giveLoot = true;
		}
	}

	public void move(){
	}

	public void checkForAnimation(){
	}

	public void attack(Player player){
		player.takeDamage(Random.Range(damage * 0.8f, damage), transform);
	}

	// TODO: Refactorizar esto a un Collision Stay con cooldown
	public void OnCollisionStay2D (Collision2D collision) {
		if (collision.gameObject.name == "Player" && lastTime >= cd) {
			attack (collision.gameObject.GetComponent<Player> ());
			lastTime = 0;
		}
	}
}
