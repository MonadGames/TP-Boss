using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BubbleLoot : MonoBehaviour {

	protected float value;

	private bool give = false;

	protected FloatingTextController textController;
	protected Player player;

	public AudioClip sound;
	private AudioSource source;

	void Start() {
		textController = GameObject.FindObjectOfType<FloatingTextController> ();
		player = GameObject.FindObjectOfType<Player> ();
		source = GetComponent<AudioSource> ();
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
