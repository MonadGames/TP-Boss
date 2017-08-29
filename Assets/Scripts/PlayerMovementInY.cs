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
		checkForDown ();
	}

	public void checkForDown(){
		if (Input.GetKey(KeyCode.DownArrow) && isColliderWithFloor()) {
			// anim of down character
		}
	}

	public void checkForJump(){
		if (Input.GetKey(KeyCode.Space) && isColliderWithFloor()) {
			rb.velocity = Vector2.up * jumpSpeed;
			//anim.SetTrigger ("Jump");
		}
	}

	public bool isColliderWithFloor(){
		Collider2D collider = GetComponent<BoxCollider2D>();
		return true;
		//return (collider.gameObject.tag == "Floor");
		// pense que esto iba a andar y por alguna razon colisiona con algo de tag "Player"
	}
}
