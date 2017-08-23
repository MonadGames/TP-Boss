using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public float speed;

	private bool isDead = false;

	private bool isRight;

	private Rigidbody2D rb;

	private Animator anim;

	// Use this for initialization
	void Start () {
		isRight = true;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead) { 
			float horizontal = Input.GetAxis ("Horizontal");

			rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);

			if (rb.velocity.x != 0) {
				anim.SetTrigger ("Run");
			} else if (rb.velocity.x > 0 && rb.velocity.y > 0) {
				anim.SetTrigger ("JumpWithVelocity");
			} else {
				anim.SetTrigger ("Pause");
			}

			Flip (horizontal);
		}
	}

	void OnCollisionEnter2D (){
		isDead = false; 
	}

	private void Flip(float horizontal){
		if (horizontal > 0 && !isRight || horizontal < 0 && isRight) {
			isRight = !isRight;

			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}
	}
}
