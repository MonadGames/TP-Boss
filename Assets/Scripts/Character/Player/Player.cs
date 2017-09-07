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
	}

	public void OnCollisionExit2D (Collision2D collision) {
	}


}
