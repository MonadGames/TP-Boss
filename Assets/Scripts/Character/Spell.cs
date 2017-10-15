using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

	public AudioClip hitSound;
	public float damage;
	public GameObject hitEffect;
	public float costEnergy;


	private AudioSource source;
	bool shouldStopMoving = false;
	Vector2 position;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}

	public float cost(){
		return costEnergy;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void playHit(Collider2D collider){
		hitEffect.SetActive (true);
		position = new Vector2 (collider.transform.position.x, gameObject.transform.position.y);
		this.freezePosition ();
	}

	void applyDamage(Collider2D collider){
		Player player = GameObject.FindObjectOfType<Player> ();
		Enemy enemy = collider.gameObject.GetComponent<Enemy> ();
		enemy.takeDamage (player.totalDamage(this));
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Enemy") {
			this.shouldStopMoving = true;
			source.PlayOneShot (hitSound, 1f);
			this.playHit (collider);
			this.applyDamage (collider);
		}
	}

	void freezePosition(){
		gameObject.transform.position = position;
	}

	void LateUpdate(){
		if(shouldStopMoving){
			this.freezePosition ();
		}
	}
		
}
