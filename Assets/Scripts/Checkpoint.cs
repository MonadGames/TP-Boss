using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	private GameSystem gameSystem;
	private FloatingTextController textController;
	private Player player;

	public Vector3 checkpointPosition;
	public KeyCode saveKey;

	void Start () {
		gameSystem  = GameObject.FindObjectOfType<GameSystem> ();
		textController  = GameObject.FindObjectOfType<FloatingTextController> ();
		player = GameObject.FindObjectOfType<Player> ();
	}

	void Update () {
		checkSavePosition ();		
	}

	public void checkSavePosition () {
		float distance = Vector2.Distance (transform.position, player.transform.position);

		if (distance <= 1f && Input.GetKeyDown (saveKey)) {
			save ();
		}
	}

	public void save() {
		textController.save (transform);
		gameSystem.save (checkpointPosition);
	}
}
