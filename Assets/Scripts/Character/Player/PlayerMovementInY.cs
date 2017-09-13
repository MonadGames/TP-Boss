using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovementInY : MonoBehaviour {

	[Range(1, 10)]
	public float jumpSpeed;
	public bool grounded = false;
	public bool jumpBoostGround = false;

	private float speed;
	private Animator anim;
	private bool isDead = false;
	private Rigidbody2D rb;


	void Start () {
		speed = jumpSpeed;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (!isDead) {
			checkForMove();
		}
	}

	private void checkForMove(){
		checkForJump ();
		checkForBend ();
	}

	public void checkForBend(){
		if (Input.GetKey(KeyCode.DownArrow) && grounded) {
			anim.SetTrigger ("Bend");
		}
	}

	public void checkForJump(){
		if (Input.GetKey(KeyCode.Space) && grounded) {
			changeSpeed ();
			rb.velocity = Vector2.up * speed;
			anim.SetTrigger ("Jump");
		}
	}

	private void changeSpeed() {
		float factor = jumpBoostGround ? 1.5f : 1;
		speed = jumpSpeed * factor;
	}

	public void OnCollisionEnter2D (Collision2D collision) {
		switch (collision.gameObject.tag) {
		case "ground":
			grounded = true;
			break;
		case "impulseGround":
			grounded = true;
			jumpBoostGround = true;
			break;
		default:
			break;
		}
	}

	public void OnCollisionExit2D (Collision2D collision) {
		switch (collision.gameObject.tag) {
		case "ground":
			grounded = false;
			break;
		case "impulseGround":
			grounded = false;
			jumpBoostGround = false;
			break;
		default:
			break;
		}
	}

}
