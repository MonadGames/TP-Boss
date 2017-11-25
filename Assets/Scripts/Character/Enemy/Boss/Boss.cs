using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Character {
	
	public float cd = 0.5f;
	public float lastTime = 0.5f;
	public float rangeOfAwake;
	public AudioClip hitSound;
	public Vector3 originalPos;

	private BossState state;
	private AudioSource source;
	private ChargeEnemy iaAttack;
	private Player player;
	private Animator anim;
	private GameSystem gameSystem;
	private FloatingTextController textSystem;
	private ActiveFinalLvl finalLvl;


	void Start () {
		anim = GetComponent<Animator> ();
		iaAttack = GetComponent<ChargeEnemy> ();
		player = GameObject.FindObjectOfType<Player> ();
		state = new AsleepState (this);
		source = GetComponent<AudioSource> ();
		gameSystem = GameObject.FindObjectOfType<GameSystem> ();
		textSystem = GameObject.FindObjectOfType<FloatingTextController> ();
		finalLvl = GameObject.FindObjectOfType<ActiveFinalLvl> ();
	}

	void Update () {
		state.update ();
		lastTime += Time.deltaTime;
	}

	public void restartPos() {
		transform.position = originalPos;
	}

	public void warningMessage() {
		textSystem.createWarningMessage ("RAPIDO...CORRE!!!", player.transform);
	}

	public bool isAwake(){
		return state.isAwake ();
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

	public bool IsPlayingIdle() {
		return anim.GetCurrentAnimatorStateInfo(0).IsName ("Idle");
	}

	public void setState(BossState newState) {
		state = newState;
	}

	public void attack(Player player){
		player.takeDamage(Random.Range(damage * 0.8f, damage), transform);
	}

	public void OnCollisionStay2D (Collision2D collision) {
		if (iaAttack.enabled) {
			if (collision.gameObject.name == "Player" && lastTime >= cd && !player.isDead()) {
				attack (collision.gameObject.GetComponent<Player> ());
				source.PlayOneShot (hitSound, 1f);
				lastTime = 0;
			}

			if (collision.gameObject.tag == "DeathBoss") {
				finalLvl.surviveToBoss ();
				Destroy (gameObject);
			}
		}
	}
}
