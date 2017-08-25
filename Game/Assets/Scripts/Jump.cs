using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	[Range(1, 10)]
	public float jumpVelocity;

	private Animator anim;

	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update () {
		checkForJump ();
	}

	private void checkForJump(){
		if (Input.GetButtonDown ("Jump") && (rb.position.y < 0.5f)) {
			rb.velocity = Vector2.up * jumpVelocity;
			//anim.SetTrigger ("Jump");
		} else 
			if(rb.velocity.y == 0 && rb.velocity.x == 0){
			//anim.SetTrigger ("Pause");
		}
	}
}
