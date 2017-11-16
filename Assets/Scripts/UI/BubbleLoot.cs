using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BubbleLoot : MonoBehaviour {

	[Range(0, 3)]
	public float distance;

	[Range(1, 2)]
	public float speed;

	protected float value;
	private bool give = false;

	protected FloatingTextController textController;
	protected Player player;

	public AudioClip sound;
	private AudioSource source;
	private Vector3 target;

	void Start() {
		textController = GameObject.FindObjectOfType<FloatingTextController> ();
		player = GameObject.FindObjectOfType<Player> ();
		source = GetComponent<AudioSource> ();
		target = player.transform.position;
		target.y += 0.5f;
	}

	void Update() {
		checkFollow ();
	}

	public void checkFollow() {
		float range = Vector2.Distance (transform.position, player.transform.position);
		 
		if(range <= distance) {
			transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
		}
	}


	public void setValue(float value){
		this.value = value;
	}

	public void OnCollisionStay2D (Collision2D collision) {
		if (collision.gameObject.name == "Player" && !give) {
			takeValue (collision.gameObject.GetComponent<Player>());
			source.PlayOneShot (sound, 1f);
			Destroy(gameObject);
			give = true;
		}
	}

	public virtual void takeValue (Player player){}

}
