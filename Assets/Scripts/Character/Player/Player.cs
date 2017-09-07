using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	private int countOfGoodActions = 0;
	private int countOfBadActions = 0;

	void Start () {
		health = gameObject.GetComponent<Health>();
	}

	void Update () {
	}
		
	public void OnCollisionEnter2D (Collision2D collision) {
		// Esto desp vuela, es para probar. El player no debe poder sacarle vida al mob chocandolo.
		if (collision.gameObject.tag == "Enemy")
			collision.gameObject.GetComponent<Enemy>().takeDamage(damage, transform);
	}

	public void OnCollisionExit2D (Collision2D collision) {
	}


}
