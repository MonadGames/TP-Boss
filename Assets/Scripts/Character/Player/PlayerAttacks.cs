using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {

	private float damage;

	void Start () {
		//damage = gameObject.GetComponent<Player> ().damage;
	}

	void Update () {
		if (Input.GetKey (KeyCode.LeftAlt)) {
			//gameObject.GetComponent<Enemy>().takeDamage(2, transform);
		}
	}
}
