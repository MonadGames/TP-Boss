using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {

	private float damage;

	void Start () {
		damage = gameObject.GetComponent<Player> ().damage;
	}

	void Update () {
		if (Input.GetKey (KeyCode.LeftAlt)) {
			//GameObject.GetComponent<Enemy>().takeDamage(damage, transform);
		}
	}
}
