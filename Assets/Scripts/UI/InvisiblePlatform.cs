using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlatform : MonoBehaviour {

	public GameObject platform;
	public float visibleDistance;
	public Vector3 savePosition;

	private Player player;
	private GameSystem gameSystem;

	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
		gameSystem = GameObject.FindObjectOfType<GameSystem> ();
	}

	void Update () {
		checkVisibility ();
	}

	public void checkVisibility() {
		float distance = Vector2.Distance (platform.transform.position, player.transform.position);

		if (distance <= visibleDistance) {
			platform.SetActive (true);
			gameSystem.save (savePosition);
		}
	}
}
