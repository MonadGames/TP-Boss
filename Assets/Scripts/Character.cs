using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public float speed;
	public float acceleration;
	private bool isDead = false;
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
		// move();
		// faltaria hacer que la velocidad cambie usando la aceleracion. Asi pasa de caminar a correr
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

	void OnCollisionEnter2D (){
		isDead = false; 
	}

	private void checkForActions(){
		if (rb.velocity.x > 0) {
			anim.SetTrigger ("Walk");
		} else if(rb.velocity.x == 0){
			anim.SetTrigger ("Idle");
		}
	}

	private void move(){
		var move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;
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
