using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {
	
	void Start () {
		health = gameObject.GetComponent<Health>();
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
	}

}
