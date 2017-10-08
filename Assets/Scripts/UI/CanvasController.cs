using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

	public GameObject player;
	public GameObject panel;

	private bool visible;

	// Use this for initialization
	void Start () {
		visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		checkGameOver ();
	}

	void checkGameOver (){
		if (player.gameObject.GetComponent<Player> ().isDead () && !visible) {
			visible = true;
			panel.SetActive (true);
		}
	}
}
