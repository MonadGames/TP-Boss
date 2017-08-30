using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {


	public int radiusOfMovement = 2;
	public float enemySpeed = 50f;

	public bool isFacingRight;
	private float startPos;
	private float endPos;

	private bool isDetectPlayer = false;

	Rigidbody2D enemyRigidBody2D;
	private GameObject player;

	public bool moveRight = true;

	void Start () {
		enemyRigidBody2D = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public void Awake() {
		startPos = transform.position.x;
		endPos = startPos + radiusOfMovement;
		isFacingRight = transform.localScale.x > 0;
	}
		
	public void Update() {
		normalMovement ();
		detectPlayer ();
	}

	public void normalMovement(){
		if (moveRight) {
			enemyRigidBody2D.AddForce(enemyRigidBody2D.position * enemySpeed * Time.deltaTime);
			if (!isFacingRight)
				flip();
		}

		if (enemyRigidBody2D.position.x >= endPos)
			moveRight = false;

		if (!moveRight) {
			enemyRigidBody2D.AddForce(enemyRigidBody2D.position * - enemySpeed * Time.deltaTime);
			if (isFacingRight)
				flip();
		}

		if (enemyRigidBody2D.position.x <= startPos)
			moveRight = true;
	}

	public void detectPlayer(){
		
	}

	public void flip() {
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		isFacingRight = transform.localScale.x > 0;
	}
}
