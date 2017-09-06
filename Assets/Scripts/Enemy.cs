using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

	void Start () {
	}

	public void move(){
	}

	public void checkForAnimation(){
	}

	public void OnCollisionEnter2D (Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			collision.gameObject.GetComponent<Health> ().TakeDamage (damage, transform);
			//(collision.gameObject  as Player).damage (damage);
		}
	}

	public void OnCollisionExit2D (Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{

		}
	}

}
