using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	private int countOfGoodActions = 0;
	private int countOfBadActions = 0;

	public Player(){
		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
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
		if (collision.gameObject.tag == "Enemy")
		{

		}
	}
}
