using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public float speed;
	public float acceleration;
	private bool isDead = false;
	private bool isRight;
	private Rigidbody2D rb;
	private Animator anim;

	void Start () {
		isRight = true;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (!isDead) {
			checkForMove ();
			checkForActions ();
			flip ();
		}
	}

	private void checkForMove(){
		// faltaria hacer que la velocidad cambie usando la aceleracion. Asi pasa de caminar a correr
		var move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;
	}

	void OnCollisionEnter2D (){
		isDead = false; 
	}

	private void checkForActions(){
		if (rb.velocity.x > 0 && rb.velocity.x <= 2) {
			anim.SetTrigger ("Walk");
		} else if (rb.velocity.x > 2) {
			anim.SetTrigger ("Run");
		} else {
			anim.SetTrigger ("Idle");
		}
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
