using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {


	public int radiusOfMovement = 2;
	public float enemySpeed = 200;

	public bool isFacingRight;
	private float startPos;
	private float endPos;

	private bool isDetectEnemy;

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
		detectEnemy ();
	}

	public void normalMovement(){
		if (moveRight) {
			enemyRigidBody2D.AddForce(Vector2.right * enemySpeed * Time.deltaTime);
			if (!isFacingRight)
				flip();
		}

		if (enemyRigidBody2D.position.x >= endPos)
			moveRight = false;

		if (!moveRight) {
			enemyRigidBody2D.AddForce(-Vector2.right * enemySpeed * Time.deltaTime);
			if (isFacingRight)
				flip();
		}

		if (enemyRigidBody2D.position.x <= startPos)
			moveRight = true;
	}

	public void detectEnemy(){
		
	}

	public void flip() {
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		isFacingRight = transform.localScale.x > 0;
	}
}
