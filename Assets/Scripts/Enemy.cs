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

	public void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			//(collision.gameObject  as Player).damage (damage);
		}
	}

	public void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{

		}
	}

}
