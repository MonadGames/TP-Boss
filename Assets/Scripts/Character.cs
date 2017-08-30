using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public float health = 100f;
	public float energy = 20f;
	public float defense = 0f;
	protected Rigidbody2D myBody;
	protected Animator anim;

	public Character() {
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Start () {
	}

	void Update () {
		
	}
}
