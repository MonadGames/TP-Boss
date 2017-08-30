using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	private float health;
	private float energy;
	private float defense;

	public Player(){
		health = 100f;
		energy = 20f;
		defense = 0f;
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
