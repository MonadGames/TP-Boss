using UnityEngine;
using System.Collections;

public class PlayerMovementInY : MonoBehaviour {

	[Range(1, 10)]
	public float jumpSpeed;

	private Animator anim;
	private bool isDead = false;
	private Rigidbody2D rb;

	void Start () {
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
		if (Input.GetKey(KeyCode.DownArrow) && itsDontMove()) {
			anim.SetTrigger ("Bend");
		}
	}

	public void checkForJump(){
		if (Input.GetKey(KeyCode.Space) && itsDontMove()) {
			rb.velocity = Vector2.up * jumpSpeed;
			anim.SetTrigger ("Jump");
		}
	}

	private bool itsDontMove(){
		return rb.velocity.y == 0;
	}
}
