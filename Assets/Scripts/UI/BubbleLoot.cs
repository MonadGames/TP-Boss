﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BubbleLoot : MonoBehaviour {

	[Range(0, 3)]
	public float distance;

	[Range(1, 2)]
	public float speed;
	public AudioClip soundEffect;
	protected float value;
	private bool give = false;

	protected FloatingTextController textController;
	protected Player player;

	protected AudioSource audioSource;
	private Vector3 target;

	void Start() {
		textController = GameObject.FindObjectOfType<FloatingTextController> ();
		player = GameObject.FindObjectOfType<Player> ();
		audioSource = GetComponent<AudioSource>();
		target = player.transform.position;
		target.y += 1f;
	}

	void Update() {
		checkFollow ();
	}

	public void checkFollow() {
		float range = Vector2.Distance (transform.position, player.transform.position);
		 
		if(range <= distance) {
			transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
		}
	}


	public void setValue(float value){
		this.value = value;
	}

	public void OnCollisionStay2D (Collision2D collision) {
		if (collision.gameObject.name == "Player" && !give) {
			takeValue (collision.gameObject.GetComponent<Player>());
			applySound ();
			Destroy(gameObject);
			give = true;
		}
	}

	public virtual void applySound() {
		audioSource.PlayOneShot(soundEffect, 1f);
	}

	public virtual void takeValue (Player player){}

}
