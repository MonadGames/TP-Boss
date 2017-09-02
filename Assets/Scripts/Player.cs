using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	private int countOfGoodActions = 0;
	private int countOfBadActions = 0;

	void Start () {
		
	}

	void Update () {
		
	}

	public void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{

		}
	}

	public void OnCollisionExit(Collision collision)
	{

		Destroy(collision.gameObject);
//		if (collision.gameObject.tag == "Enemy")
//		{
//			print ("Attack");
//		}
	}
		
	public void damage(float enemyDamage){
		health = health - (enemyDamage - defense);
	}
}
