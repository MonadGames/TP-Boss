using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public float rangeOfAwake;
	private BossState state;

	private ChargeEnemy iaAttack;
	private Player player;
	private Animator anim;


	void Start () {
		anim = GetComponent<Animator> ();
		iaAttack = GetComponent<ChargeEnemy> ();
		player = GameObject.FindObjectOfType<Player> ();
		state = new AsleepState (this);
	}

	void Update () {
		state.update ();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "StopBoss") {
			Destroy (gameObject);
		}
	}

	public Player getPlayer(){
		return player;
	}

	public Animator getAnim() {
		return anim;
	}

	public ChargeEnemy getAI() {
		return iaAttack;
	}

	public void setState(BossState newState) {
		state = newState;
	}
}
