using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlatform : MonoBehaviour {

	public GameObject platform;
	public float visibleDistance;

	private Player player;

	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
	}

	void Update () {
		checkVisibility ();
	}

	public void checkVisibility() {
		float distance = Vector2.Distance (transform.position, player.transform.position);

		if (distance <= visibleDistance) {
			platform.SetActive (true);
		}
	}
}
