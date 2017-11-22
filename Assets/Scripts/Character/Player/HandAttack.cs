using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttack : MonoBehaviour {

	private Player player;

	void Start () {
		player = GameObject.FindObjectOfType<Player> ();	
	}

	void Update () {
		
	}
		
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Enemy") {
			Enemy enemy = collision.gameObject.GetComponent<Enemy> ();
			enemy.takeDamage (player.getNormalAttack ());
		}
	}
}
