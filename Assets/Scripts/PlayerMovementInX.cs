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
	private bool walking;

	void Start () {
		isRight = true;
		walking = false;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		if (!isDead) {
			checkForMove ();
			flip ();
		}
	}

	private void checkForMove(){

		// POR FAVOR SAQUEMOS ESTE CODIGO FEO FEO Y USEMOS CheckForActions QUE ESTA BONITO.
		if (shouldMove()) {
			anim.SetTrigger ("Walk");
			move ();
			walking = true;
		} else {
			anim.SetTrigger ("Idle");
			rb.velocity = new Vector2(0, rb.velocity.y);
			walking = false;
		}
	}

	private void checkForActions(){
		float speed = rb.velocity.x;

		if (speed.Equals(walkSpeed))
			anim.SetTrigger ("Walk");
		else if (speed.Equals(runSpeed))
			anim.SetTrigger ("Run");
		else {
			anim.SetTrigger ("Idle");
		}
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
