using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {


	public int radiusOfMovement = 2;
	public float radiusOfVision = 2f;
	public float enemySpeed = 1f;
	public bool isFacingRight;
	public bool moveRight = true;
	public bool enemyDetected = false;

	private Animator anim;
	private Vector2 startPos;
	private Vector2 endPos;
	private Rigidbody2D enemyRigidBody2D;
	private GameObject player;


	void Start () {
		enemyRigidBody2D = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player");
		anim = GetComponent<Animator> ();
		anim.SetTrigger ("Walk");
	}

	public void Awake() {
		startPos = transform.position;
		endPos = startPos;
		endPos.x = endPos.x + radiusOfMovement;
		isFacingRight = transform.localScale.x > 0;
	}
		
	public void Update() {
		detectPlayer ();
		normalMovement ();
	}

	public void normalMovement(){
		if (!enemyDetected) {
			if (moveRight) {
				enemyRigidBody2D.velocity = new Vector2 (enemySpeed, 0);
				if (!isFacingRight)
					flip ();
			} else {
				enemyRigidBody2D.velocity = new Vector2 (-enemySpeed, 0);
				if (isFacingRight)
					flip ();
			}
		}

		if (enemyRigidBody2D.position.x >= endPos.x)
			moveRight = false;
		else if (enemyRigidBody2D.position.x <= startPos.x)
			moveRight = true;
	}

	public void detectPlayer(){
		float range = Vector2.Distance (transform.position, player.transform.position);

		if (range <= radiusOfVision) {
			enemyDetected = true;
			flipToPlayer ();
			transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
		} else
			enemyDetected = false;
	}

	public void flipToPlayer (){
		float myX = transform.position.x ;
		float playerX = player.transform.position.x;
		float myScaleX = transform.localScale.x;

		if (myX > playerX && myScaleX > 0 || myX < playerX && myScaleX < 0)
			flip ();
	}

	public void flip() {
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		isFacingRight = transform.localScale.x > 0;
	}
}
