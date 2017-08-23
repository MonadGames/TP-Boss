using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	[Range(1, 10)]
	public float jumpVelocity;

	[Range(-5, 2)]
	public float maxJump;

	private Animator anim;

	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump") && (rb.position.y < maxJump)) {
			rb.velocity = Vector2.up * jumpVelocity;
			anim.SetTrigger ("Jump");
		} else if(rb.position.y < 0){
			anim.SetTrigger ("Pause");
		}
	}
}
