using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	public float damage = 20f;
	public float energy = 20f;
	public float defense = 0f;
	protected Rigidbody2D myBody;
	protected Animator anim;
	protected Health health;

	public Character() {
	}

	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	public void takeDamage(float damage,Transform transform){
		health.takeDamage(damage, transform);
	}

	void Update () {
		
	}
}
