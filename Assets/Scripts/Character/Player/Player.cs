using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	private int countOfGoodActions = 0;
	private int countOfBadActions = 0;
	private Health health;


	void Start () {
		health = gameObject.GetComponent<Health>();
	}

	void Update () {
	}

	public void takeDamage(float damage,Transform transform){
		health.takeDamage(damage, transform);
	}
		
	public void OnCollisionEnter2D (Collision2D collision)
	{
		
	}


}
