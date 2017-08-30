using UnityEngine;
using System.Collections;

public class PlayerMovementInX : MonoBehaviour {
	
	[Range(3, 6)]
	public float runSpeed;

	[Range(1, 2)]
	public float walkSpeed;

	public bool isDead = false;
	private bool isRight;
	private Rigidbody2D rb;
	private Animator anim;

	void Start () {
		isRight = true;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		if (!isDead) {
			move ();
			checkForActions ();
			flip ();
		}
	}

	private void checkForActions() {
		float speed = rb.velocity.x;
		if (shouldMove()) {
			if (speed < runSpeed)
				anim.SetTrigger ("Walk");
			else 
				anim.SetTrigger ("Run");
		} else {
			anim.SetTrigger ("Idle");
			rb.velocity = new Vector2(0, rb.velocity.y);
		}
/*		
		if (speed.Equals (walkSpeed))
			anim.SetTrigger ("Walk");
		else if (speed.Equals (runSpeed))
			anim.SetTrigger ("Run");
		else
			anim.SetTrigger ("Idle");
					*/
	}

	private void move(){
		var movement = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		if (Input.GetKey(KeyCode.LeftShift)) { 
			movePlayer(movement, runSpeed);
		} else {
			movePlayer(movement, walkSpeed);
		}
	}

	private void movePlayer(Vector3 movement, float speed){
		transform.position += movement * speed * Time.deltaTime;
	}

	private bool shouldMove(){
		return Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow);
	}

	private void flip(){
		float horizontal = Input.GetAxis ("Horizontal");
		if (horizontal > 0 && !isRight || horizontal < 0 && isRight) {
			isRight = !isRight;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}
	}

}
